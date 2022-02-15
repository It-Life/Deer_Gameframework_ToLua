﻿// ================================================
//描 述 :  
//作 者 : 杜鑫 
//创建时间 : 2021-07-10 15-34-55  
//修改作者 : 杜鑫 
//修改时间 : 2021-07-10 15-34-55  
//版 本 : 0.1 
// ===============================================
#if UNITY_EDITOR
using LuaInterface;
using Sirenix.OdinInspector;
using Sirenix.Utilities.Editor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditor.Experimental.SceneManagement;
using UnityEngine;

namespace Deer
{
    [ExecuteAlways]
    public partial class UIComponentBinder : MonoBehaviour
    {

        [NoToLua]
        public enum PClass
        {
            UIBaseClass = 0,
            UISubBaseClass = 1,
            UILuaUnit = 2,
            LuaUnit = 3,
        }
        [NoToLua]
        [HorizontalGroup(Width = 0.35f), LabelWidth(85)]
        public PClass LuaClass = PClass.UIBaseClass;

        [HorizontalGroup(Width = 0.45f), ShowInInspector, LabelWidth(55)]
        private string Search = "";


        private void Awake()
        {
            EditorApplication.hierarchyWindowItemOnGUI += HierarchyItemCB;
        }

        private void OnGUI()
        {
        }

        private void OnDestroy()
        {
            EditorApplication.hierarchyWindowItemOnGUI -= HierarchyItemCB;
        }


        private void HierarchyItemCB(int instanceid, Rect selectionrect)
        {
            var obj = EditorUtility.InstanceIDToObject(instanceid) as GameObject;
            if (obj != null)
            {
                GUIStyle style = new GUIStyle
                {
                    normal = { textColor = Color.green },
                    hover = { textColor = Color.cyan },
                    alignment = TextAnchor.MiddleRight,
                };
                for (var i = 0; i < _uIComponentBinderInfos.Count; i++)
                {
                    UIComponentBinderInfo _uIComponentBinderInfo = _uIComponentBinderInfos[i];
                    if (_uIComponentBinderInfo.Object == obj)
                    {
                        var r = new Rect(selectionrect);

                        GUI.Label(r, $"=>'{_uIComponentBinderInfo.Name}'        ", style);
                    }
                }
            }
        }


        [HorizontalGroup, Button(ButtonSizes.Small)]
        private void Open()
        {

            var obj = _uIComponentBinderInfos.Where(info => info.Name == Search);
            foreach (var uiComponentBinderInfo in obj)
            {
                _uIComponentBinderInfos.Remove(uiComponentBinderInfo);
                _uIComponentBinderInfos.Insert(0, uiComponentBinderInfo);
                GUIHelper.OpenInspectorWindow(uiComponentBinderInfo.Object);
                break;
            }
        }


        private const string FieldStart = "--------------AutoGenerated--------------";
        private const string FieldEnd = "--------------Do not modify!-------------";

        [NoToLua]
        [HorizontalGroup("func"), Button(ButtonSizes.Small)]
        public void GenCode()
        {
            PrefabStage prefabStage = PrefabStageUtility.GetPrefabStage(gameObject);
            if (prefabStage == null)
            {
                EditorUtility.DisplayDialog("", "必须在prefab编辑模式下点击", "CANCEL");
                return;
            }

            EditorUtility.SetDirty(gameObject);
            List<string> names = new List<string>();
            foreach (var uiComponentBinderInfo in _uIComponentBinderInfos)
            {
                if (names.Contains(uiComponentBinderInfo.Name))
                {
                    if (EditorUtility.DisplayDialog("注意", $"存在重复key：{uiComponentBinderInfo.Name}", "确定", "取消"))
                    {
                        return;
                    }
                }
                else
                {
                    names.Add(uiComponentBinderInfo.Name);
                }
            }

            List<string> fieldStrList = new List<string>();
            Dictionary<string, string> clickFuncDict = new Dictionary<string, string>();
            string scriptPath = filePath;
            string parentClass = LuaClass.ToString();
            string s = "\n---================================================\n" +
                "---描 述 : \n" +
                "---作 者 : $Author \n" +
                "---创建时间 : $CreateTime \n" +
                "---修改作者 : $ChangeAuthor \n" +
                "---修改时间 : $ChangeTime \n" +
                "---版 本 : $Version \n" +
                "---===============================================\n";
            s += "$UI_NAME = $UI_NAME --$UI_RES\n";
            s += "---@class $UI_NAME:$P_Class\n";
            s += FieldStart;
            s += "\n";
            fieldStrList.Add(FieldStart);
            for (int i = _uIComponentBinderInfos.Count - 1; i >= 0; i--)
            {
                var inf = _uIComponentBinderInfos[i];
                string fieldStr = $"---@field {inf.Name} {inf.componet.GetType().FullName}\n";
                s += fieldStr;
                fieldStrList.Add(fieldStr.Remove(fieldStr.Length - 1));
                if (inf.canClick)
                {
                    var funcName = string.Format($"OnClick{inf.Name.ToUpperFirst()}Btn");
                    var funcStr = @"---@param button UIButtonSuper
function $UI_NAME:$BTN_NAME(button)

end
";
                    funcStr = funcStr.Replace("$UI_NAME", Path.GetFileNameWithoutExtension(scriptPath));
                    funcStr = funcStr.Replace("$BTN_NAME", funcName);
                    clickFuncDict[funcName] = funcStr;
                    if (inf.canDoubleClick)
                    {
                        funcStr = @"---@param button UIButtonSuper
function $UI_NAME:$BTN_NAME(button)

end
";
                        funcName = string.Format($"OnDoubleClick{inf.Name.ToUpperFirst()}Btn");
                        funcStr = funcStr.Replace("$UI_NAME", Path.GetFileNameWithoutExtension(scriptPath));
                        funcStr = funcStr.Replace("$BTN_NAME", funcName);
                        clickFuncDict[funcName] = funcStr;
                    }
                    if (inf.canPress)
                    {
                        funcStr = @"---@param button UIButtonSuper
function $UI_NAME:$BTN_NAME(button)

end
";
                        funcName = string.Format($"OnLongPress{inf.Name.ToUpperFirst()}Btn");
                        funcStr = funcStr.Replace("$UI_NAME", Path.GetFileNameWithoutExtension(scriptPath));
                        funcStr = funcStr.Replace("$BTN_NAME", funcName);
                        clickFuncDict[funcName] = funcStr;
                    }
                }
            }

            s += FieldEnd;
            fieldStrList.Add(FieldEnd);
            CovertString(ref s, parentClass);

            if (scriptPath.Length == 0)
            {
                EditorUtility.DisplayDialog("", "请输入正确的文件名", "CANCEL");
                return;
            }
            if (!scriptPath.StartsWith("/"))
            {
                scriptPath = "/" + scriptPath;
            }

            if (!scriptPath.EndsWith(".lua"))
            {
                scriptPath += ".lua";
            }
            var fileName = Path.GetFileName(scriptPath);
            Regex regex = new Regex(@"^([a-zA-Z]:\\)?[^\/\:\*\?\""\<\>\|\,]*$");
            Match m = regex.Match(fileName);
            if (!m.Success)
            {
                EditorUtility.DisplayDialog("", "文件名包含非法字符", "CANCEL");
                return;
            }
            scriptPath = LuaConst.luaDir + scriptPath;


            s = s.Replace("$UI_NAME", Path.GetFileNameWithoutExtension(scriptPath));
            s = s.Replace("$Author", Environment.UserName);
            s = s.Replace("$Time", DateTime.Now.ToString());
            s = s.Replace("$P_Class", parentClass);
            s = s.Replace("$CreateTime",DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss"));
            s = s.Replace("$ChangeTime",DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss"));
            s = s.Replace("$ChangeAuthor", Environment.UserName);
            //把#Author# 替换
            /*            s = s.Replace("$Author",
                            GameEditorConfig.author);*/
            //把#ChangeAuthor# 替换
            /*            s = s.Replace("$ChangeAuthor",
                            GameEditorConfig.author);*/
            //把#Version# 替换
            /*            s = s.Replace("$Version",
                            GameEditorConfig.version);*/

            GameObject openPrefabThatContentsIsPartOf =
                AssetDatabase.LoadAssetAtPath<GameObject>(prefabStage.prefabAssetPath);
            string prefabPath = AssetDatabase.GetAssetPath(openPrefabThatContentsIsPartOf);

            s = s.Replace("$UI_RES", prefabPath);

            var returnStr = "return " + Path.GetFileNameWithoutExtension(scriptPath);

            if (FileUtils.ExistsFile(scriptPath))
            {
                bool stopWrite = false;
                bool writeNewOver = false;
                string[] strArr = File.ReadAllLines(scriptPath);
                List<string> strList = new List<string>();
                for (int i = 0; i < strArr.Length; i++)
                {
                    string str = strArr[i];

                    if (str.Equals(FieldStart))
                    {
                        stopWrite = true;
                    }

                    if (!stopWrite)
                    {
                        strList.Add(str);
                    }
                    else
                    {
                        if (!writeNewOver)
                        {
                            for (int j = 0; j < fieldStrList.Count; j++)
                            {
                                strList.Add(fieldStrList[j]);
                            }

                            //writeNew
                            writeNewOver = true;
                        }
                    }


                    if (str.Equals(FieldEnd))
                    {
                        stopWrite = false;
                    }
                }

                foreach (KeyValuePair<string, string> pair in clickFuncDict)
                {
                    bool contain = false;
                    for (int kIndex = 0; kIndex < strList.Count; kIndex++)
                    {
                        string str = strList[kIndex];

                        if (str.Contains(pair.Key))
                        {
                            contain = true;
                            break;
                        }
                    }


                    if (!contain)
                    {
                        strList.Add(pair.Value);
                    }
                }


                {
                    for (var i = strList.Count - 1; i >= 0; i--)
                    {
                        var str = strList[i];
                        if (str.Contains(returnStr))
                        {
                            strList.Remove(str);
                        }
                    }
                }

                strList.Add(returnStr);

                File.WriteAllLines(scriptPath, strList.ToArray());
            }
            else
            {
                foreach (KeyValuePair<string, string> pair in clickFuncDict)
                {
                    s += pair.Value;
                }

                s += returnStr;
 /*               File.CreateText(scriptPath);
                File.WriteAllText(scriptPath, s);*/
                FileUtils.CreateFile(scriptPath, s, true);
            }

            OpenCode();


/*            bool isFinish = FileUtils.CreateFile(scriptPath, s, true);
            if (isFinish)
            {
            }*/
            //GenRequireLuaRequireFile();
        }

        private static void GenRequireLuaRequireFile()
        {
            Dictionary<UIComponentBinder, string> pathDict = new Dictionary<UIComponentBinder, string>();
            var uiComponentBinders = AssetDatabase
                .FindAssets("t:prefab")
                .Select(AssetDatabase.GUIDToAssetPath)
                .Select(x =>
                {
                    if (x.Contains($"{AssetBundlePathResolver.BundlePathPrefix}Prefabs/UI")
                        || x.Contains($"{AssetBundlePathResolver.BundlePathPrefix}Prefabs/UITest") || x.Contains($"{AssetBundlePathResolver.BundlePathPrefix}Prefabs/Battle"))
                    {
                        var ret = AssetDatabase.LoadAssetAtPath<UIComponentBinder>(x);
                        if (ret != null)
                        {
                            pathDict[ret] = x.Replace(AssetBundlePathResolver.BundlePathPrefix, "").Replace(".prefab", "").ToLower();
                        }

                        return ret;
                    }

                    return null;
                })
                .Where(x => x != null && !string.IsNullOrEmpty(x.filePath))
                .ToArray();


            StringBuilder stringBuilder = new StringBuilder();
            foreach (var uiComponentBinder in uiComponentBinders)
            {
                var lets = uiComponentBinder.GetComponentsInChildren<UIComponentBinder>(true);
                lets = lets.Where(x => x != null && !string.IsNullOrEmpty(x.filePath)).ToArray();

                foreach (var let in lets)
                {
                    var luaGlobalStringName = let.filePath.Substring(let.filePath.LastIndexOf("/") + 1);
                    var requirePath = $"\"logic/{let.filePath}\"";
                    stringBuilder.Append($"_G[\"{luaGlobalStringName}\"] = {requirePath}\n");
                }
            }

            stringBuilder.Append("_G.__UIPrefabPath = {\n");

            foreach (var uiComponentBinder in uiComponentBinders)
            {
                var luaGlobalStringName = uiComponentBinder.filePath.Substring(uiComponentBinder.filePath.LastIndexOf("/") + 1);
                stringBuilder.Append($"    {luaGlobalStringName} = \"{pathDict[uiComponentBinder]}\",\n");
            }

            stringBuilder.Append("}\n");

            LuaInterface.Debugger.Log(string.Format("{1}:[{0}]", stringBuilder.ToString(), "stringBuilder.ToString()"));
            //FileUtils.WriteAllText("Assets/../LuaSrc/UIRequireTable.lua", stringBuilder.ToString());
        }
        private static string CovertString(ref string s, string pcls)
        {
            if (pcls == "UIBaseClass")
            {
                s += @"
local $UI_NAME = Class('$UI_NAME', $P_Class)

function $UI_NAME:OnAwake()
    self.super.OnAwake(self)
    self:RegisterEvent()

end

function $UI_NAME:OnEnable()
    self.super.OnEnable(self)
    
end

function $UI_NAME:OnStart()
    self.super.OnStart(self)
    
end

function $UI_NAME:OnDisable()
    self.super.OnDisable(self)
   
end

function $UI_NAME:OnDestroy()
    self.super.OnDestroy(self)
    self:UnRegisterEvent()

end

function $UI_NAME:RegisterEvent()
    
end

function $UI_NAME:UnRegisterEvent()

end

-----------------------------logic----------------------------------

-----------------------------event----------------------------------

-----------------------------button----------------------------------
";
            }
            else if (pcls == "LuaOutlet" || pcls == "UILuaOutlet")
            {


                s = "$UI_NAME = $UI_NAME --$UI_RES\n" + s;
                s += @"
local $UI_NAME = class('$UI_NAME', $P_Class)

function $UI_NAME:onCtor()
    
end

function $UI_NAME:onLoaded()

end

function $UI_NAME:onDestruct()
    $UI_NAME.super.onDestruct(self)
end

";
            }
            else if (pcls == "BattleWidget")
            {
                s = "$UI_NAME = $UI_NAME --$UI_RES\n" + s;
                s += @"
local $UI_NAME = class('$UI_NAME', $P_Class)

function $UI_NAME:onCtor()
    
end

function $UI_NAME:initWithGo(go)
    $UI_NAME.super.initWithGo(self,go)
end

function $UI_NAME:onLoaded()
    $UI_NAME.super.onLoaded(self)
end

function $UI_NAME:onDestruct()
    $UI_NAME.super.onDestruct(self)
end

function $UI_NAME:onActive(...)
    $UI_NAME.super.onActive(self,...)
end

function $UI_NAME:onDeActive()
    $UI_NAME.super.onDeActive(self)
end

function $UI_NAME:setActive(isActive, ...)
    $UI_NAME.super.setActive(self,isActive,...)
end

function $UI_NAME:isActive()
    return $UI_NAME.super.isActive(self)
end

function $UI_NAME:getView()
    return self.go
end

function $UI_NAME:setVisible(visible)
    self:setActive(visible)
end

function $UI_NAME:isVisible()
    return self:isActive()
end

function $UI_NAME:onDestruct()
    $UI_NAME.super.onDestruct(self)
end

";
            }

            return s;
        }


        [HorizontalGroup("func"), Button(ButtonSizes.Small)]
        void OpenCode()
        {
            string fileName = LuaConst.luaDir + "/" + filePath + ".lua";
            IDEUtils.OpenFileWith(fileName);
        }

        [HorizontalGroup("func"), Button(ButtonSizes.Small)]
        void Sort()
        {
            _uIComponentBinderInfos.Sort(((info, outletInfo) => info.ComponentType.CompareTo(outletInfo.ComponentType)));
        }

        class AssetBundlePathResolver
        {
            public static string BundlePathPrefix = "";
        }
    }
}
#endif
