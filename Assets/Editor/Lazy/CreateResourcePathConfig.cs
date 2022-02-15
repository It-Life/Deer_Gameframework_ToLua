using System.Collections.Generic;
using System.IO;
using System.Text;
using Deer;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class CreateResourcePathConfig : Editor
{

    private static List<string> m_StartPath = new List<string>()
    {
        ResourcePathPrefix.Lua
    };

    [MenuItem("MyTools/Resource/CreateResourcePath")]
    public static void CreateResourcePath()
    {
        Dictionary<string, List<string>> m_Paths = new Dictionary<string, List<string>>();

        string[] allAssetsNames = UnityEditor.AssetDatabase.GetAllAssetPaths();
        foreach (var startPath in m_StartPath)
        {
            List<string> assetNames = new List<string>();
            foreach (var assetName in allAssetsNames)
            {
                if (assetName.LastIndexOf(".") == -1)
                {
                    continue;
                }
                if (assetName.StartsWith(startPath))
                {
                    assetNames.Add(assetName);
                }
            }
            m_Paths.Add(startPath, assetNames);
        }

        try
        {
            StringBuilder sbr = new StringBuilder();
            foreach (var info in m_Paths)
            {
                foreach (var item in info.Value)
                {
                    string strLine = string.Format("{0}|{1}", info.Key, item);
                    sbr.AppendLine(strLine);

                    if (File.Exists(ResourcesPathData.ResourcePathConfig))
                    {
                        File.Delete(ResourcesPathData.ResourcePathConfig);
                    }
                    using (FileStream fs = File.Create(ResourcesPathData.ResourcePathConfig))
                    {
                        using (StreamWriter sw = new StreamWriter(fs))
                        {
                            sw.Write(sbr.ToString());
                        }
                    }
                }
            }

            //UnityEngine.Debug.Log("生成资源文件列表成功。");
        }
        catch
        {
            if (File.Exists(ResourcesPathData.ResourcePathConfig))
            {
                File.Delete(ResourcesPathData.ResourcePathConfig);
            }
            UnityEngine.Debug.LogError("生成资源文件列表失败。");
        }
        AssetDatabase.Refresh();
    }
}
