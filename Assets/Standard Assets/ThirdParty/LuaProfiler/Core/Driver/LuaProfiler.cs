/*
               #########                       
              ############                     
              #############                    
             ##  ###########                   
            ###  ###### #####                  
            ### #######   ####                 
           ###  ########## ####                
          ####  ########### ####               
         ####   ###########  #####             
        #####   ### ########   #####           
       #####   ###   ########   ######         
      ######   ###  ###########   ######       
     ######   #### ##############  ######      
    #######  #####################  ######     
    #######  ######################  ######    
   #######  ###### #################  ######   
   #######  ###### ###### #########   ######   
   #######    ##  ######   ######     ######   
   #######        ######    #####     #####    
    ######        #####     #####     ####     
     #####        ####      #####     ###      
      #####       ###        ###      #        
        ###       ###        ###               
         ##       ###        ###               
__________#_______####_______####______________
                我们的未来没有BUG                
* ==============================================================================
* Filename: LuaProfiler
* Created:  2018/7/13 14:29:22
* Author:   エル・プサイ・コングリィ
* Purpose:  
* ==============================================================================
*/

#if UNITY_EDITOR_WIN || USE_LUA_PROFILER
using System;
using System.Collections.Generic;
using System.Reflection;
using RefDict = System.Collections.Generic.Dictionary<string, System.Collections.Generic.HashSet<string>>;
using UnityEngine;
#if UNITY_5_5_OR_NEWER
using UnityEngine.Profiling;
#endif

namespace MikuLuaProfiler
{
    public static class LuaProfiler
    {
        #region member
        private static IntPtr _mainL = IntPtr.Zero;
        private static readonly Stack<Sample> beginSampleMemoryStack = new Stack<Sample>();
        private static int m_currentFrame = 0;
        private static int m_gcFrame = 0;
        private static long m_gcMemory = 0;
        public static int mainThreadId = -100;
        const long MaxB = 1024;
        const long MaxK = MaxB * 1024;
        const long MaxM = MaxK * 1024;
        const long MaxG = MaxM * 1024;

        private static Action<Sample> m_onReceiveSample;
        private static Action<LuaRefInfo> m_onReceiveRef;
        private static Action<LuaDiffInfo> m_onReceiveDiff;
        public static void RegisterOnReceiveSample(Action<Sample> onReceive)
        {
            m_onReceiveSample = onReceive;
        }
        public static void RegisterOnReceiveRefInfo(Action<LuaRefInfo> onReceive)
        {
            m_onReceiveRef = onReceive;
        }
        public static void RegisterOnReceiveDiffInfo(Action<LuaDiffInfo> onReceive)
        {
            m_onReceiveDiff = onReceive;
        }

        public static void UnRegistReceive()
        {
            m_onReceiveSample = null;
            m_onReceiveRef = null;
            m_onReceiveDiff = null;
        }
        #endregion

        #region property
        public static bool m_hasL = false;
        public static IntPtr mainL
        {
            get
            {
                return _mainL;
            }
            set
            {
                if (value != IntPtr.Zero)
                {
                    m_hasL = true;
                    LuaDLL.luaL_initlibs(value);
                }
                else
                {
                    m_hasL = false;
                }
                _mainL = value;
            }
        }
        public static bool IsMainThread
        {
            get
            {
                return System.Threading.Thread.CurrentThread.ManagedThreadId == mainThreadId;
            }
        }
        #endregion

        #region sample
        public static void BeginSampleCSharp(string name)
        {
            BeginSample(_mainL, name);
        }
        public static void EndSampleCSharp()
        {
            EndSample(_mainL);
        }

        public static long getcurrentTime
        {
            get
            {
                return System.Diagnostics.Stopwatch.GetTimestamp();
            }
        }
        public static void BeginSample(IntPtr luaState, string name, bool needShow = false)
        {
            if (!IsMainThread)
            {
                return;
            }
            try
            {
                int frameCount = SampleData.frameCount;
                long memoryCount = LuaLib.GetLuaMemory(luaState);
                if (frameCount - m_gcFrame >= 300 && memoryCount >= m_gcMemory)
                {
                    LuaDLL.lua_gc_unhook(luaState, LuaGCOptions.LUA_GCCOLLECT, 0);
                    memoryCount = LuaLib.GetLuaMemory(luaState);
                    m_gcFrame = frameCount;
                    m_gcMemory = memoryCount * 3 / 2;
                }

                if (m_currentFrame != frameCount)
                {
                    LuaDLL.lua_gc_unhook(luaState, LuaGCOptions.LUA_GCSTOP, 0);
                    m_currentFrame = frameCount;
                    PopAllSampleWhenLateUpdate(luaState);
                }
                Sample sample = Sample.Create(getcurrentTime, (int)memoryCount, name);
                sample.needShow = needShow;
                beginSampleMemoryStack.Push(sample);
            }
            catch(Exception e)
            {
                Debug.LogError(e);
            }
        }
        private static List<Sample> popChilds = new List<Sample>();
        public static void PopAllSampleWhenLateUpdate(IntPtr luaState)
        {
            while(beginSampleMemoryStack.Count > 0)
            {
                EndSample(luaState);
            }
        }
        public static void EndSample(IntPtr luaState)
        {
            if (!IsMainThread)
            {
                return;
            }

            if (beginSampleMemoryStack.Count <= 0)
            {
                return;
            }
            long nowMemoryCount = LuaLib.GetLuaMemory(luaState);
            long nowMonoCount = GC.GetTotalMemory(false);
            Sample sample = beginSampleMemoryStack.Pop();

            sample.costTime = (int)(getcurrentTime - sample.currentTime);
            var monoGC = nowMonoCount - sample.currentMonoMemory;
            var luaGC = nowMemoryCount - sample.currentLuaMemory;
            sample.currentLuaMemory = (int)nowMemoryCount;
            sample.currentMonoMemory = (int)nowMonoCount;
            sample.costLuaGC = (int)luaGC;
            sample.costMonoGC = (int)monoGC;

            if (!sample.CheckSampleValid())
            {
                sample.Restore();
                return;
            }
            sample.fahter = beginSampleMemoryStack.Count > 0 ? beginSampleMemoryStack.Peek() : null;
            //UnityEngine.Debug.Log(sample.name);
            if (beginSampleMemoryStack.Count == 0)
            {
                var setting = LuaDeepProfilerSetting.Instance;
                if (setting == null) return;
                if (setting != null && setting.isNeedCapture)
                {
                    //迟钝了
                    if (sample.costTime >= (1 / (float)(setting.captureFrameRate)) * 10000000)
                    {
                        sample.captureUrl = Sample.Capture();
                    }
                    else if (sample.costLuaGC > setting.captureLuaGC)
                    {
                        sample.captureUrl = Sample.Capture();
                    }
                    else if (sample.costMonoGC > setting.captureMonoGC)
                    {
                        sample.captureUrl = Sample.Capture();
                    }
                    else
                    {
                        sample.captureUrl = null;
                    }
                }
                if (!setting.isLocal)
                {
                    NetWorkClient.SendMessage(sample);
                }
                else if(m_onReceiveSample != null)
                {
                    m_onReceiveSample(sample);
                }
            }
            //释放掉被累加的Sample
            if (beginSampleMemoryStack.Count != 0 && sample.fahter == null)
            {
                sample.Restore();
            }
        }

        public static void SendFrameSample()
        {
            var setting = LuaDeepProfilerSetting.Instance;
            long memoryCount = LuaLib.GetLuaMemory(_mainL);
            Sample sample = Sample.Create(getcurrentTime, (int)memoryCount, "");
            if (!setting.isLocal)
            {
                NetWorkClient.SendMessage(sample);
            }
            else if (m_onReceiveSample != null)
            {
                m_onReceiveSample(sample);
            }
        }

        #endregion

        #region ref
        private static Dictionary<byte, RefDict> m_refDict = new Dictionary<byte, RefDict>(4);

        public static void AddRef(string refName, string refAddr, byte type)
        {
            RefDict refDict;
            if (!m_refDict.TryGetValue(type, out refDict))
            {
                refDict = new RefDict(2048);
                m_refDict.Add(type, refDict);
            }

            HashSet<string> addrList;
            if (!refDict.TryGetValue(refName, out addrList))
            {
                addrList = new HashSet<string>();
                refDict.Add(refName, addrList);
            }
            if (!addrList.Contains(refAddr))
            {
                addrList.Add(refAddr);
            }
            SendAddRef(refName, refAddr, type);
        }
        public static void SendAddRef(string funName, string funAddr, byte type)
        {
            LuaRefInfo refInfo = LuaRefInfo.Create(1, funName, funAddr, type);
            var setting = LuaDeepProfilerSetting.Instance;
            if (!setting.isLocal)
            {
                NetWorkClient.SendMessage(refInfo);
            }
            else if (m_onReceiveRef != null)
            {
                m_onReceiveRef(refInfo);
            }
        }
        public static void RemoveRef(string refName, string refAddr, byte type)
        {
            if (string.IsNullOrEmpty(refName)) return;
            RefDict refDict;

            if (!m_refDict.TryGetValue(type, out refDict))
            {
                return;
            }

            HashSet<string> addrList;
            if (!refDict.TryGetValue(refName, out addrList))
            {
                return;
            }
            if (!addrList.Contains(refAddr))
            {
                return;
            }
            addrList.Remove(refAddr);
            if (addrList.Count == 0)
            {
                refDict.Remove(refName);
            }
            SendRemoveRef(refName, refAddr, type);
        }
        public static void SendRemoveRef(string funName, string funAddr, byte type)
        {
            LuaRefInfo refInfo = LuaRefInfo.Create(0, funName, funAddr, type);
            var setting = LuaDeepProfilerSetting.Instance;
            if (!setting.isLocal)
            {
                NetWorkClient.SendMessage(refInfo);
            }
            else if (m_onReceiveRef != null)
            {
                m_onReceiveRef(refInfo);
            }
        }
        public static void SendAllRef()
        {
            foreach (var dictItem in m_refDict)
            {
                foreach (var hashList in dictItem.Value)
                {
                    foreach (var item in hashList.Value)
                    {
                        SendAddRef(hashList.Key, item, dictItem.Key);
                    }
                }
            }
        }
        #endregion

    }
}
#endif

