using UnityEditor;
using UnityEngine;
using System;
using System.IO;
using UnityEditor.ProjectWindowCallback;
using System.Text;
using System.Text.RegularExpressions;

public class CreateTemplateScript
{
    //脚本模板路径
    private const string TemplateScriptPath = "Assets/Editor/Lazy/GenScriptTool/Template/MyTemplateScript.cs.txt";
    private const string TemplateProcedureScriptPath = "Assets/Editor/Lazy/GenScriptTool/Template/MyTemplateProcedureScript.cs.txt";
    private const string TemplateLuaScriptPath = "Assets/Editor/Lazy/GenScriptTool/Template/MyTemplateLua.lua.txt";

    //菜单项
    [MenuItem("Assets/Create/C# FrameScript", false, 1)]
    static void CreateScript()
    {
        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0, ScriptableObject.CreateInstance<CreateScriptAsset>(),
        GetSelectedPathOrFallback() + "/New BehaviourScript.cs",
        null, TemplateScriptPath);
    }
    [MenuItem("Assets/Create/C# FrameProcedureScript", false, 2)]
    static void CreateProcedureScript()
    {
        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0, ScriptableObject.CreateInstance<CreateScriptAsset>(),
        GetSelectedPathOrFallback() + "/New ProcedureScript.cs",
        null, TemplateProcedureScriptPath);
    }

    [MenuItem("Assets/Create/Lua Script", false, 3)]
    public static void CreatNewLua()
    {
        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0, ScriptableObject.CreateInstance<CreateScriptAsset>(),
            GetSelectedPathOrFallback() + "/New Lua.lua", null, TemplateLuaScriptPath);
    }
    public static string GetSelectedPathOrFallback()
    {
        string path = "Assets";
        foreach (UnityEngine.Object obj in Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.Assets))
        {
            path = AssetDatabase.GetAssetPath(obj);
            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                path = Path.GetDirectoryName(path);
                break;
            }
        }
        return path;
    }
}
class CreateScriptAsset : EndNameEditAction
{
    private static string annotationCSStr =
"// ================================================\r\n"
+ "//描 述 :  \r\n"
+ "//作 者 : #Author# \r\n"
+ "//创建时间 : #CreatTime#  \r\n"
+ "//修改作者 : #ChangeAuthor# \r\n"
+ "//修改时间 : #ChangeTime#  \r\n"
+ "//版 本 : #Version# \r\n"
+ "// ===============================================\r\n";
    private static string annotationLuaStr =
"\r\n"
+ "---================================================\r\n"
+ "---描 述 :  \r\n"
+ "---作 者 : #Author# \r\n"
+ "---创建时间 : #CreatTime#  \r\n"
+ "---修改作者 : #ChangeAuthor# \r\n"
+ "---修改时间 : #ChangeTime#  \r\n"
+ "---版 本 : #Version# \r\n"
+ "---===============================================\r\n";
    public override void Action(int instanceId, string newScriptPath, string templatePath)
    {
        UnityEngine.Object obj = CreateTemplateScriptAsset(newScriptPath, templatePath);
        ProjectWindowUtil.ShowCreatedAsset(obj);
    }

    public static UnityEngine.Object CreateTemplateScriptAsset(string newScriptPath, string templatePath)
    {
        string fullPath = Path.GetFullPath(newScriptPath);
        StreamReader streamReader = new StreamReader(templatePath);
        string text = streamReader.ReadToEnd();
        streamReader.Close();
        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(newScriptPath);
        string fileTemplateName = Path.GetFileNameWithoutExtension(templatePath);

        //替换模板的文件名
        text = Regex.Replace(text, "MyTemplateScript", fileNameWithoutExtension);
        string annotationStr = annotationCSStr;
        if (fileTemplateName == "MyTemplateLua.lua")
        {
            annotationStr = annotationLuaStr;
        }
        annotationStr += text;
        //把#CreateTime#替换成具体创建的时间
        annotationStr = annotationStr.Replace("#CreatTime#",
            System.DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss"));
        annotationStr = annotationStr.Replace("#ChangeTime#",
            System.DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss"));
        //把#Author# 替换
        annotationStr = annotationStr.Replace("#Author#",
            GameEditorConfig.author);
        //把#ChangeAuthor# 替换
        annotationStr = annotationStr.Replace("#ChangeAuthor#",
            GameEditorConfig.author);
        //把#Version# 替换
        annotationStr = annotationStr.Replace("#Version#",
            GameEditorConfig.version);
        //把内容重新写入脚本
        bool encoderShouldEmitUTF8Identifier = false;
        bool throwOnInvalidBytes = false;
        UTF8Encoding encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier, throwOnInvalidBytes);
        bool append = false;
        StreamWriter streamWriter = new StreamWriter(fullPath, append, encoding);
        streamWriter.Write(annotationStr);
        streamWriter.Close();
        AssetDatabase.ImportAsset(newScriptPath);
        return AssetDatabase.LoadAssetAtPath(newScriptPath, typeof(UnityEngine.Object));
    }

}