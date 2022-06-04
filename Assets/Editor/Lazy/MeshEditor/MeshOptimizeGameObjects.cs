// ================================================
//描 述:
//作 者:XinDu
//创建时间:2022-05-26 14-46-42
//修改作者:XinDu
//修改时间:2022-05-26 14-46-42
//版 本:0.1 
// ===============================================
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Please modify the description.
/// </summary>
public class MeshOptimizeGameObjects
{
    [MenuItem("Assets/Mesh/SetOptimizeGameObjects")]
    public static void Optimize()
    {
        var fbxGo = Selection.activeGameObject;
        var fbxPath = AssetDatabase.GetAssetPath(fbxGo);
        var importer = AssetImporter.GetAtPath(fbxPath) as ModelImporter;
        if (importer == null)
        {
            return;
        }
        importer.optimizeGameObjects = true;
        importer.SaveAndReimport();
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
    [MenuItem("Assets/Mesh/UndoOptimizeGameObjects")]
    public static void UndoOptimize()
    {
        var fbxGo = Selection.activeGameObject;
        var fbxPath = AssetDatabase.GetAssetPath(fbxGo);//获取fbx在Project中的路径
        var importer = AssetImporter.GetAtPath(fbxPath) as ModelImporter;
        if (importer == null)
        {
            return;
        }
        importer.optimizeGameObjects = false;
        importer.SaveAndReimport();
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}