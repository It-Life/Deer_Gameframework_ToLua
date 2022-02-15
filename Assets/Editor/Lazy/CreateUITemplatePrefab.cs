// ================================================
//描 述 :  
//作 者 : 杜鑫 
//创建时间 : 2021-08-12 00-05-17  
//修改作者 : 杜鑫 
//修改时间 : 2021-08-12 00-05-17  
//版 本 : 0.1 
// ===============================================
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEditor.Presets;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

namespace Deer.Editor
{
    public class CreateUITemplatePrefab
    {
        [MenuItem("GameObject/UI/U_Progress",false,1)]
        static void CreateProgressObj(MenuCommand menuCommand)
        {
            SaveObject(menuCommand, "Progress");
        }
        [MenuItem("GameObject/UI/U_UIPanel",false,0)]
        static void CreateUIPanelObj(MenuCommand menuCommand)
        {
            SaveObject(menuCommand, "UIPanel");
        }
        static void SaveObject(MenuCommand menuCommand, string prefabName,string objName = "") 
        {
            var path = FileUtils.GetPath($@"Assets\Deer\Asset\UI\UIPrefab\UITemplate\{ prefabName }.prefab");
            GameObject prefab = (GameObject)AssetDatabase.LoadMainAssetAtPath(path);
            if (prefab)
            {
                GameObject inst = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
                if (!string.IsNullOrEmpty(objName))
                {
                    inst.gameObject.name = objName;
                }
                var img = inst.GetComponent<Image>();
                if (img)
                {
                    img.color = new Color(1, 1, 1, 1);
                }
                var text = inst.GetComponent<Text>();
                if (text)
                {
                    text.text = "";
                }
                GameObjectUtility.SetParentAndAlign(inst, menuCommand.context as GameObject);
                Undo.RegisterCreatedObjectUndo(inst, $"Create {inst.name}__" + inst.name);
                Selection.activeObject = inst;
                AssetDatabase.Refresh();
                AssetDatabase.SaveAssets();
            }
        }
    }
}