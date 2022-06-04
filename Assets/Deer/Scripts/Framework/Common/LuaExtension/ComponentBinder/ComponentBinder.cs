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
    public partial class ComponentBinder : MonoBehaviour
    {
        public List<ComponentBinderInfo> _componentBinderInfos = new List<ComponentBinderInfo>();
        public List<SubPanelInfo> _subPanelInfo = new List<SubPanelInfo>();
        public List<PanelItemInfo> _panelItemInfo = new List<PanelItemInfo>();
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
            ComponentBinderInfo componentBinderInfo = null;
            string funName = "";
            for (var i = 0; i < _componentBinderInfos.Count; i++)
            {
                componentBinderInfo = _componentBinderInfos[i];
                if (componentBinderInfo.Object != null)
                {
                    luaTable[componentBinderInfo.Name] = componentBinderInfo.componet;

                    if (componentBinderInfo.canClick)
                    {
                        UIButtonSuper btn = componentBinderInfo.componet as UIButtonSuper;
                        funName = string.Format($"OnClick{componentBinderInfo.Name.ToUpperFirst()}Btn");
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
            if (_subPanelInfo.Count>0)
            {
                SubPanelInfo subPanelInfo = null;
                funName = "__InstantiationAllSubPanel";
                for (int i = 0; i < _subPanelInfo.Count; i++)
                {
                    subPanelInfo = _subPanelInfo[i];
                    luaTable[subPanelInfo.Name] = subPanelInfo.Name;
                    luaTable.GetLuaFunction(funName).Call(luaTable, subPanelInfo.Name, subPanelInfo.Object, subPanelInfo.SubPanelNode);
                }
            }
            if (_panelItemInfo.Count > 0)
            {
                PanelItemInfo panelItemInfo = null;
                funName = "__InstantiationAllPanelUnit";
                for (int i = 0; i < _panelItemInfo.Count; i++)
                {
                    panelItemInfo = _panelItemInfo[i];
                    luaTable[panelItemInfo.Name] = panelItemInfo.Name;
                    luaTable.GetLuaFunction(funName).Call(luaTable, panelItemInfo.Name, panelItemInfo.Object);
                }
            }
        }

    }
}