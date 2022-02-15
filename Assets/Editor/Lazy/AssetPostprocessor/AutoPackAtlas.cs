// ================================================
//描 述 :  
//作 者 : 杜鑫 
//创建时间 : 2021-08-05 23-29-41  
//修改作者 : 杜鑫 
//修改时间 : 2021-08-05 23-29-41  
//版 本 : 0.1 
// ===============================================
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;
using System.Linq;
namespace Deer.Editor
{
    public class AutoPackAtlas : AssetPostprocessor
    {
        void OnPreprocessTexture()
        {
            //自动设置类型;
            TextureImporter textureImporter = (TextureImporter)assetImporter;
            string dirName = Path.GetDirectoryName(assetPath);
            string atlasName = Path.GetFileNameWithoutExtension(assetPath);
            string folderStr = Path.GetFileName(dirName);
            if (assetPath.Contains("Assets/Deer/Asset/UI/UIArt/Atlas"))
            {
                EditorCoroutineRunner.StartEditorCoroutine(WaitForSeconds(atlasName, assetPath, dirName));
            }else if (assetPath.Contains("Assets/Deer/Asset/UI/UIArt/Sprite"))
            {
                textureImporter.textureType = TextureImporterType.Sprite;
                //EditorCoroutineRunner.StartEditorCoroutine(WaitForSeconds(atlasName, assetPath, dirName));
            }
        }

        public IEnumerator WaitForSeconds(string atlasName, string assetPath, string dirName) 
        {
            yield return new WaitForSeconds(0.1f);//0.1秒后继续执行
            CreateAtlasPrefab(atlasName, assetPath, dirName);
        }

        public static void CreateAtlasPrefab(string atlasName, string path, string dirName)
        {
            List<Sprite> _texs = new List<Sprite>();
            _texs.AddRange(AssetDatabase.LoadAllAssetsAtPath(path).OfType<Sprite>().ToArray());
            if (_texs.Count != 0)
            {
                AtlasScriptableObject atlasScriptableObject = ScriptableObject.CreateInstance<AtlasScriptableObject>();
                atlasScriptableObject.SetSP = _texs.ToArray();
                string path1 = dirName + "/" + atlasName + ".asset";
                AssetDatabase.CreateAsset(atlasScriptableObject, path1);
                AssetDatabase.SaveAssets();
            }
            Resources.UnloadUnusedAssets();
            AssetDatabase.Refresh();
        }
    }
}