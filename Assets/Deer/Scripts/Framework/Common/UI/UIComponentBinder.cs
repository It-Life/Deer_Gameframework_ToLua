// ================================================
//描 述 :  
//作 者 : 杜鑫 
//创建时间 : 2021-07-10 12-12-48  
//修改作者 : 杜鑫 
//修改时间 : 2021-07-10 12-12-48  
//版 本 : 0.1 
// ===============================================
using LuaInterface;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Deer
{
    [RequireComponent(typeof(UIEventBinder))]
    public partial class UIComponentBinder : MonoBehaviour
    {
        public List<UIComponentBinderInfo> _uIComponentBinderInfos = new List<UIComponentBinderInfo>();

        private UIEventBinder _uiEventBinder;

        [LabelWidth(55)]
        public string FilePath = "";
        public string filePath => FilePath;

        public UIEventBinder GetUIEventBinder()
        {
            if (!_uiEventBinder)
            {
                _uiEventBinder = GetComponent<UIEventBinder>();
            }

            return _uiEventBinder;
        }
        public void BindLua(LuaTable luaTable)
        {
            UIComponentBinderInfo componentBinderInfo = null;
            for (var i = 0; i < _uIComponentBinderInfos.Count; i++)
            {
                componentBinderInfo = _uIComponentBinderInfos[i];
                if (componentBinderInfo.Object != null)
                {
                    luaTable[componentBinderInfo.Name] = componentBinderInfo.componet;

                    if (componentBinderInfo.canClick)
                    {
                        UIButtonSuper btn = componentBinderInfo.componet as UIButtonSuper;
                        string funName = string.Format($"OnClick{componentBinderInfo.Name.ToUpperFirst()}Btn");
                        GetUIEventBinder().AddPress(btn, luaTable, luaTable.GetLuaFunction(funName),PressType.onClick, componentBinderInfo.m_soundId);
                        if (componentBinderInfo.canDoubleClick)
                        {
                            funName = string.Format($"OnDoubleClick{componentBinderInfo.Name.ToUpperFirst()}Btn");
                            GetUIEventBinder().AddPress(btn, luaTable, luaTable.GetLuaFunction(funName),PressType.onDoubleClick, componentBinderInfo.m_soundId);
                        }
                        if (componentBinderInfo.canPress)
                        {
                            funName = string.Format($"OnLongPress{componentBinderInfo.Name.ToUpperFirst()}Btn");
                            GetUIEventBinder().AddPress(btn, luaTable, luaTable.GetLuaFunction(funName),PressType.onLongPress, componentBinderInfo.m_soundId);
                        }
                    }

                }
            }
        }

    }
}