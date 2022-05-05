// ================================================
//描 述 :  
//作 者 : 杜鑫 
//创建时间 : 2021-07-11 23-02-20  
//修改作者 : 杜鑫 
//修改时间 : 2021-07-11 23-02-20  
//版 本 : 0.1 
// ===============================================
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
public class IDEUtils
{
    private const string EXTERNAL_EDITOR_PATH_KEY = "mTv8";
    private const string LUA_PROJECT_ROOT_FOLDER_PATH_KEY = "obUd";
    public static void OpenFileWith(string fileName, int line = 1)
    {
        string luaDirPath = LuaConst.luaDir;
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX
        string editorPath = EditorPrefs.GetString(PrefsKey.EDITOR_LUA_IDE_PATH);
#endif
#if UNITY_EDITOR_WIN
        System.Diagnostics.Process proc = new System.Diagnostics.Process();
        proc.StartInfo.FileName = editorPath;
        string procArgument = "";
        //Debug.Log(editorPath);
        if (StringUtils.IsNullOrEmpty(editorPath))
        {
            Log.Error("请先去设置编辑器路径");
            return;
        }

        if (editorPath.IndexOf("idea") != -1)
        {
            procArgument = string.Format("{0} --line {1} {2}",luaDirPath , line, fileName);
        }
        else if (editorPath.IndexOf("Rider") != -1)
        {
            procArgument = string.Format("{0} --line {1} {2}", luaDirPath, line, fileName);
        }
        else if (editorPath.IndexOf("Code") != -1)
        {
            procArgument = string.Format("-g {0}:{1}", fileName, line);
        }
        else
        {
            procArgument = string.Format("{0}:{1}:0", fileName, line);
        }
        proc.StartInfo.Arguments = procArgument;
        proc.Start();
#elif UNITY_EDITOR_OSX
        System.Diagnostics.Process proc = new System.Diagnostics.Process();
        proc.StartInfo.FileName = editorPath;
        string procArgument = string.Format("{0} --line {1} {2}", luaDirPath, line, fileName);
        LuaInterface.Debugger.Log(string.Format("{1}:[{0}]", procArgument, "procArgument"));

        proc.StartInfo.Arguments = procArgument;
        proc.Start();
#endif
    }

}
