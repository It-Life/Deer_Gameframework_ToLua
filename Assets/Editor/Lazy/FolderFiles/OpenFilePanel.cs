using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OpenFilePanel
{
    [MenuItem("MyTools/SetPath/SetLuaIde")]
    public static void setLuaIdePath() 
    {
        //记录上次选择目录
        string folderPath = EditorPrefs.GetString(PrefsKey.EDITOR_LUA_IDE_PATH);
        string searchPath = EditorUtility.OpenFilePanel("select Lua IDE exe", folderPath, "exe");

        if (!StringUtils.IsNullOrEmpty(searchPath))
        {
            EditorPrefs.SetString(PrefsKey.EDITOR_LUA_IDE_PATH, searchPath);
        }

    }
}
