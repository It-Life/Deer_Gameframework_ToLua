// ================================================
//描 述 :  
//作 者 : 杜鑫 
//创建时间 : 2021-10-06 16-05-46  
//修改作者 : 杜鑫 
//修改时间 : 2021-10-06 16-05-46  
//版 本 : 0.1 
// ===============================================

using System.IO;
using System.Text;
using Deer;
using GameFramework;
using UnityEditor;
using UnityEngine;
using UnityGameFramework.Editor.ResourceTools;

public class DXBuildEventHandler100 : IBuildEventHandler
{
    public bool ContinueOnFailure => false;

    private string CommitResourcesPath = Application.dataPath + "/../CommitResources/100/";
    private VersionInfo m_VersionInfo = new VersionInfo();
    public void OnPreprocessAllPlatforms(string productName, string companyName, string gameIdentifier,
        string gameFrameworkVersion, string unityVersion, string applicableGameVersion, int internalResourceVersion,
        BuildAssetBundleOptions buildAssetBundleOptions, bool zip, string outputDirectory, string workingPath,
        bool outputPackageSelected, string outputPackagePath, bool outputFullSelected, string outputFullPath,
        bool outputPackedSelected, string outputPackedPath, string buildReportPath)
    {
        m_VersionInfo.InternalResourceVersion = internalResourceVersion;
        string streamingAssetsPath = Utility.Path.GetRegularPath(Path.Combine(Application.dataPath, "StreamingAssets"));
        string[] fileNames = Directory.GetFiles(streamingAssetsPath, "*", SearchOption.AllDirectories);
        foreach (string fileName in fileNames)
        {
            if (fileName.Contains(".gitkeep"))
            {
                continue;
            }

            File.Delete(fileName);
        }

        Utility.Path.RemoveEmptyDirectory(streamingAssetsPath);
    }

    public void OnPreprocessPlatform(Platform platform, string workingPath, bool outputPackageSelected, string outputPackagePath,
        bool outputFullSelected, string outputFullPath, bool outputPackedSelected, string outputPackedPath)
    {
    }

    public void OnBuildAssetBundlesComplete(Platform platform, string workingPath, bool outputPackageSelected,
        string outputPackagePath, bool outputFullSelected, string outputFullPath, bool outputPackedSelected,
        string outputPackedPath, AssetBundleManifest assetBundleManifest)
    {
    }

    public void OnOutputUpdatableVersionListData(Platform platform, string versionListPath, int versionListLength,
        int versionListHashCode, int versionListZipLength, int versionListZipHashCode)
    {
        m_VersionInfo.VersionListLength = versionListLength;
        m_VersionInfo.VersionListHashCode = versionListHashCode;
        m_VersionInfo.VersionListZipLength = versionListZipLength;
        m_VersionInfo.VersionListZipHashCode = versionListZipHashCode;
    }

    public void OnPostprocessPlatform(Platform platform, string workingPath, bool outputPackageSelected, string outputPackagePath,
        bool outputFullSelected, string outputFullPath, bool outputPackedSelected, string outputPackedPath, bool isSuccess)
    {
        string streamingAssetsPath = Path.Combine(Application.dataPath, "StreamingAssets");
        if (!Directory.Exists(streamingAssetsPath))
        {
            Directory.CreateDirectory(streamingAssetsPath);
        }
        if (outputPackedSelected)
        {
            string[] fileNames = Directory.GetFiles(outputPackedPath, "*", SearchOption.AllDirectories);
            foreach (string fileName in fileNames)
            {
                string destFileName = Path.Combine(streamingAssetsPath, fileName.Substring(outputPackedPath.Length));
                FileInfo destFileInfo = new FileInfo(destFileName);
                if (destFileInfo.Directory != null && !destFileInfo.Directory.Exists)
                {
                    destFileInfo.Directory.Create();
                }
                File.Copy(fileName, destFileName, true);
            }
            Debug.Log("拷贝资源文件成功！");
        }
        if (outputPackageSelected)
        {
            string[] fileNames = Directory.GetFiles(outputPackagePath, "*", SearchOption.AllDirectories);
            foreach (string fileName in fileNames)
            {
                string destFileName = Path.Combine(streamingAssetsPath, fileName.Substring(outputPackagePath.Length));
                FileInfo destFileInfo = new FileInfo(destFileName);
                if (destFileInfo.Directory != null && !destFileInfo.Directory.Exists)
                {
                    destFileInfo.Directory.Create();
                }

                File.Copy(fileName, destFileName, true);
            }
            Debug.Log("拷贝单机资源文件成功！");
        }
        //更新包文件
        if (outputFullSelected)
        {
            m_VersionInfo.ForceUpdateGame = false;
            m_VersionInfo.GameUpdateUrl = "";
            m_VersionInfo.LatestGameVersion = "";
            string versionInfoJson = JsonUtility.ToJson(m_VersionInfo);
            FileUtils.CreateFile(Path.Combine(outputFullPath,ResourcesPathData.ResourceVersionFile),versionInfoJson);
            string commitPath = CommitResourcesPath + "/" + platform;
            string[] fileNames = Directory.GetFiles(outputFullPath, "*", SearchOption.AllDirectories);
            foreach (string fileName in fileNames)
            {
                string destFileName = Path.Combine(commitPath, fileName.Substring(outputFullPath.Length));
                FileInfo destFileInfo = new FileInfo(destFileName);
                if (destFileInfo.Directory != null && !destFileInfo.Directory.Exists)
                {
                    destFileInfo.Directory.Create();
                }
                File.Copy(fileName, destFileName, true);
            }
            /*string path = Path.GetFullPath(CommitResourcesPath).Replace("1.0", "100.0");
            System.Diagnostics.Process.Start("explorer.exe", path);*/
            Application.OpenURL(CommitResourcesPath);
            Debug.Log("更新资源文件拷贝完毕！");
        }
    }

    public void OnPostprocessAllPlatforms(string productName, string companyName, string gameIdentifier,
        string gameFrameworkVersion, string unityVersion, string applicableGameVersion, int internalResourceVersion,
        BuildAssetBundleOptions buildAssetBundleOptions, bool zip, string outputDirectory, string workingPath,
        bool outputPackageSelected, string outputPackagePath, bool outputFullSelected, string outputFullPath,
        bool outputPackedSelected, string outputPackedPath, string buildReportPath)
    {
    }
}
