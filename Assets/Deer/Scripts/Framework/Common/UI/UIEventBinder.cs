using System;
using UnityEngine;
using System.Collections.Generic;
using LuaInterface;
using UnityEngine.UI;

namespace Deer
{
    public enum PressType
    {
        onClick = 0,
        onDoubleClick,
        onLongPress,
    }

    public class UIEventBinder : MonoBehaviour
    {
        private Dictionary<UIButtonSuper, LuaBaseRef> _lClickFuncs;
        private Dictionary<UIButtonSuper, LuaBaseRef> _lClickTbs;

        private Dictionary<UIButtonSuper, LuaBaseRef> _lPressFuncs;
        private Dictionary<UIButtonSuper, LuaBaseRef> _lPressTbs;

        private Dictionary<UIButtonSuper, LuaBaseRef> _lDoubleFuncs;
        private Dictionary<UIButtonSuper, LuaBaseRef> _lDoubleTbs;

        /*private Dictionary<UIButtonSuper, LuaBaseRef> _lDragOutFuncs;
        private Dictionary<UIButtonSuper, LuaBaseRef> _lDragOutTbs;*/


        
        public void AddPress(UIButtonSuper button, LuaTable ltb, LuaFunction luafunc ,PressType pressType,string soundType)
        {
            if (button == null || luafunc == null) return;
            RemoveClick(button,pressType);
            switch (pressType)
            {
                case PressType.onClick:
                    if (_lClickFuncs == null)
                    {
                        _lClickFuncs = new Dictionary<UIButtonSuper, LuaBaseRef>();
                        _lClickTbs = new Dictionary<UIButtonSuper, LuaBaseRef>();
                    }
                    AddToLuaDict(_lClickTbs, button, ltb);
                    AddToLuaDict(_lClickFuncs, button, luafunc);
                    button.onClick.AddListener(delegate ()
                    {
                        //LuaManager.lua.DoString($"GameUtil.playUIEventBinderSound(\"{soundType}\")");
                        luafunc.Call(ltb, button);
                    });
                    break;
                case PressType.onDoubleClick:
                    if (_lDoubleFuncs == null)
                    {
                        _lDoubleFuncs = new Dictionary<UIButtonSuper, LuaBaseRef>();
                        _lDoubleTbs = new Dictionary<UIButtonSuper, LuaBaseRef>();
                    }
                    AddToLuaDict(_lDoubleTbs, button, ltb);
                    AddToLuaDict(_lDoubleFuncs, button, luafunc);
                    button.onDoubleClick.AddListener(delegate ()
                    {
                        //LuaManager.lua.DoString($"GameUtil.playUIEventBinderSound(\"{soundType}\")");
                        luafunc.Call(ltb, button);
                    });
                    break;
                case PressType.onLongPress:
                    if (_lPressFuncs == null)
                    {
                        _lPressFuncs = new Dictionary<UIButtonSuper, LuaBaseRef>();
                        _lPressTbs = new Dictionary<UIButtonSuper, LuaBaseRef>();
                    }
                    AddToLuaDict(_lPressTbs, button, ltb);
                    AddToLuaDict(_lPressFuncs, button, luafunc);
                    button.onPress.AddListener(delegate ()
                    {
                        //LuaManager.lua.DoString($"GameUtil.playUIEventBinderSound(\"{soundType}\")");
                        luafunc.Call(ltb, button);
                    });
                    break;
                default:
                    break;
            }
        }

        void _AddPlaySound(GameObject go)
        {
            // var uiplaySound = go.GetComponent<UIPlaySound>();
            // if (!uiplaySound)
            // {
            //     uiplaySound = go.AddComponent<UIPlaySound>();
            //     uiplaySound.trigger = UIPlaySound.Trigger.OnPress;
            //     uiplaySound.audioClip = AudioManager.Instance.buttonDefaultAudioClip;
            // }
        }

        public void RemoveClick(UIButtonSuper button,PressType pressType)
        {
            if (button == null) return;
            switch (pressType)
            {
                case PressType.onClick:
                    RemoveFromLuaDict(_lClickFuncs, button);
                    RemoveFromLuaDict(_lClickTbs, button);
                    button.onClick.RemoveAllListeners();
                    button.onClick.Invoke();
                    break;
                case PressType.onDoubleClick:
                    RemoveFromLuaDict(_lDoubleFuncs, button);
                    RemoveFromLuaDict(_lDoubleTbs, button);
                    button.onDoubleClick.RemoveAllListeners();
                    button.onDoubleClick.Invoke();
                    break;
                case PressType.onLongPress:
                    RemoveFromLuaDict(_lPressFuncs, button);
                    RemoveFromLuaDict(_lPressTbs, button);
                    button.onPress.RemoveAllListeners();
                    button.onPress.Invoke();
                    break;
                default:
                    break;
            }
        }

        // public void AddDragOut(GameObject go, LuaTable ltb, LuaFunction luafunc)
        // {
        //     if (go == null || luafunc == null) return;
        //
        //     if (_lDragOutFuncs == null)
        //     {
        //         _lDragOutFuncs = new Dictionary<GameObject, LuaBaseRef>();
        //         _lDragOutTbs = new Dictionary<GameObject, LuaBaseRef>();
        //     }
        //
        //     RemoveDragOut(go);
        //     AddToLuaDict(_lDragOutFuncs, go, luafunc);
        //     AddToLuaDict(_lDragOutTbs, go, ltb);
        //
        //     GetEventListener(go).onDragOut = delegate(GameObject o) { luafunc.Call(ltb, go); };
        // }


        // public void RemoveDragOut(GameObject go)
        // {
        //     if (go == null) return;
        //     RemoveFromLuaDict(_lDragOutFuncs, go);
        //     RemoveFromLuaDict(_lDragOutTbs, go);
        //     GetEventListener(go).onDragOut = null;
        // }


        private static void AddToLuaDict<T>(Dictionary<UIButtonSuper, T> refDict, UIButtonSuper button, T luaBaseRef) where T : LuaBaseRef
        {
            if (button && luaBaseRef != null)
            {
                refDict.Add(button, luaBaseRef);
            }
        }

        private static void RemoveFromLuaDict<T>(Dictionary<UIButtonSuper, T> refDict, UIButtonSuper button) where T : LuaBaseRef
        {
            if (refDict == null)
                return;
            T ltb;
            if (refDict.TryGetValue(button, out ltb))
            {
                refDict.Remove(button);
                ltb.Dispose();
            }
        }


        public void ClearLuaBaseRefDict<T>(Dictionary<UIButtonSuper, T> refDict) where T : LuaBaseRef
        {
            if (refDict == null)
                return;
            foreach (var de in refDict)
            {
                if (de.Value != null)
                {
                    de.Value.Dispose();
                }
            }
            refDict.Clear();
        }


        /// <summary>
        /// 清除单击事件
        /// </summary>
        public void ClearClick()
        {
            if (_lClickFuncs != null)
            {
                ClearLuaBaseRefDict(_lClickFuncs);
                ClearLuaBaseRefDict(_lClickTbs);
            }


            // if (_lDoubleFuncs != null)
            // {
            //     ClearLuaBaseRefDict(_lDoubleFuncs);
            //     ClearLuaBaseRefDict(_lDoubleTbs);
            // }
            //
            //
            // if (_lPressFuncs != null)
            // {
            //     ClearLuaBaseRefDict(_lPressFuncs);
            //     ClearLuaBaseRefDict(_lPressTbs);
            // }
            //
            // if (_lDragOutFuncs != null)
            // {
            //     ClearLuaBaseRefDict(_lDragOutFuncs);
            //     ClearLuaBaseRefDict(_lDragOutTbs);
            // }
        }

        //-----------------------------------------------------------------
        protected void OnDestroy()
        {
            ClearClick();
        }
    }
}