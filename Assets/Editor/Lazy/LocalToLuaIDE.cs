#if  UNITY_EDITOR

using UnityEditor;
using System.IO;
using System.Reflection;
using System;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using LuaInterface;
using Debug = UnityEngine.Debug;
using UnityEngine;

using UnityEditor.Callbacks;
using UnityEngine.UI;
using Deer;

namespace Deer.Editor
{
    public class LocalToLuaIDE
{
    private static readonly string[] LUA_IGNORE_LINE = { "[C]:", "[string \"PLoop/Core\"]:", "[string \"Common/Debug\"]:" };
    private static readonly string[] CS_IGNORE_LINE = { "UnityEngine.Debug:", "UEEngine.UELog:", "UEEngine.UELogMan:" };

    private const string EXTERNAL_EDITOR_PATH_KEY = "mTv8";
    private const string LUA_PROJECT_ROOT_FOLDER_PATH_KEY = "obUd";
    private static int msDefaultOpenInstanceID = -1;
    private static int msDefaultOpenLine = -1;

    
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    private static void Init()
    {
        _isNetLog = false;
    }
    
    /// <summary>
    /// 双击console的回调
    /// </summary>
    /// <param name="instanceID"></param>
    /// <param name="line"></param>
    /// <returns></returns>
//    [OnOpenAssetAttribute(2)]
    [OnOpenAsset(0)]
    public static bool OnOpen(int instanceID, int line)
    {
        if (!GetConsoleWindowListView() || (object)EditorWindow.focusedWindow != consoleWindow)
        {
            return false;
        }
        string fileName = GetListViewRowCount(ref line);


        if (fileName == null)
        {
            if (OnOpenByDefault(instanceID, line))
            {
                return true;
            }
            return false;
        }


        if (fileName == "__EditorCheckSvnExcel")
        {
            return true;
        }
        

        
        OnOpenAsset(fileName, line);

        return true;
    }

    public static bool OnOpenAsset(string file, int line)
    {
        string filePath = file;

/*        string luaFolderRoot = EditorUserSettings.GetConfigValue(LUA_PROJECT_ROOT_FOLDER_PATH_KEY);
        if (string.IsNullOrEmpty(luaFolderRoot))
        {
            SetLuaProjectRoot();
            luaFolderRoot = EditorUserSettings.GetConfigValue(LUA_PROJECT_ROOT_FOLDER_PATH_KEY);
        }*/
        filePath = filePath.Trim();//+ ".lua";

        return OpenFileAtLineExternal(filePath, line);
    }

    static bool OpenFileAtLineExternal(string fileName, int line)
    {

        OpenFileInIdea(fileName, line);
        return true;
    }

    [DllImport("user32.dll")]  
    public static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);  
    [DllImport("user32.dll")]  
    static extern IntPtr GetForegroundWindow();  
    const int SW_SHOWMINIMIZED = 2; //{最小化, 激活}  
    const int SW_SHOWMAXIMIZED = 3;//最大化  
    const int SW_SHOWRESTORE = 1;//还原  
    [DllImport("user32.dll", EntryPoint = "FindWindow")]
    private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
    
    public static void OpenFileInIdea(string fileName, int line)
    {
        if (_isNetLog)
        {
            _isNetLog = false;
        }
        else
        {
            // ShowWindow(GetForegroundWindow(), SW_SHOWMINIMIZED);  
        }
        string pathName = $"{LuaConst.luaDir}/{fileName}";

        IDEUtils.OpenFileWith(pathName, line);

    }

    [MenuItem("Assets/Open Lua Project In IDE" , false , 300)]
    static void OpenLuaProjectInIdea( )
    {
        //默认打开Main.lua文件
        string path = "Main.lua";
        OpenFileInIdea(path , 0);
    }

    //[MenuItem("Tools/Set Your Luaproject Root")]
    static string SetLuaProjectRoot()
    {
        string path = EditorUserSettings.GetConfigValue(LUA_PROJECT_ROOT_FOLDER_PATH_KEY);
        path = EditorUtility.OpenFolderPanel("Select Your Luaproject Root", path, "");

        if (!string.IsNullOrEmpty(path))
        {
            EditorUserSettings.SetConfigValue(LUA_PROJECT_ROOT_FOLDER_PATH_KEY, path);
            Debug.Log("Set Luaproject Root Path: " + path);
        }
        return path;
    }

    private static object consoleWindow;
    private static object logListView;
    private static FieldInfo logListViewCurrentRow;
    private static MethodInfo LogEntriesGetEntry;
    private static MethodInfo StartGettingEntries;
    private static MethodInfo EndGettingEntries;
    private static object logEntry;
    private static FieldInfo logEntryCondition;
    private static bool GetConsoleWindowListView()
        {
            if (logListView == null)
            {
                Assembly unityEditorAssembly = Assembly.GetAssembly(typeof(EditorWindow));
                Type consoleWindowType = unityEditorAssembly.GetType("UnityEditor.ConsoleWindow");
                FieldInfo fieldInfo = consoleWindowType.GetField("ms_ConsoleWindow", BindingFlags.Static | BindingFlags.NonPublic);                
                consoleWindow = fieldInfo.GetValue(null);

                if (consoleWindow == null)
                {
                    logListView = null;
                    return false;
                }

                FieldInfo listViewFieldInfo = consoleWindowType.GetField("m_ListView", BindingFlags.Instance | BindingFlags.NonPublic);
                logListView = listViewFieldInfo.GetValue(consoleWindow);
                logListViewCurrentRow = listViewFieldInfo.FieldType.GetField("row", BindingFlags.Instance | BindingFlags.Public);
#if UNITY_2017_1_OR_NEWER
                Type logEntriesType = unityEditorAssembly.GetType("UnityEditor.LogEntries");                
                LogEntriesGetEntry = logEntriesType.GetMethod("GetEntryInternal", BindingFlags.Static | BindingFlags.Public);                
                Type logEntryType = unityEditorAssembly.GetType("UnityEditor.LogEntry");                                
#else
                Type logEntriesType = unityEditorAssembly.GetType("UnityEditorInternal.LogEntries");                
                LogEntriesGetEntry = logEntriesType.GetMethod("GetEntryInternal", BindingFlags.Static | BindingFlags.Public);
                Type logEntryType = unityEditorAssembly.GetType("UnityEditorInternal.LogEntry");                
#endif           
                logEntryCondition = logEntryType.GetField("message", BindingFlags.Instance | BindingFlags.Public);
                
                StartGettingEntries = logEntriesType.GetMethod("StartGettingEntries", BindingFlags.Static | BindingFlags.Public);
                EndGettingEntries = logEntriesType.GetMethod("EndGettingEntries", BindingFlags.Static | BindingFlags.Public);
                logEntry = Activator.CreateInstance(logEntryType);
            }

            return true;
        }

    private static bool _isNetLog = false;
    
    private static bool IsNetLog(string condition)
    {
        try
        {
            _isNetLog = false;

            string[] lines = null;
            string firstLine = null;
            string upLine = "↑[<color=#3EB562FF>";
            string downLine = "↓[<color=#00FFFFFF>";
         
            if (condition.Contains(upLine))
            {
                lines = condition.Split('\n');
                firstLine = lines[0];
                int index = firstLine.IndexOf(": ↑");
                // LuaInterface.Debugger.Log(string.Format("{1}:[{0}]",index,"index"));
             
                string key = firstLine.Substring(firstLine.IndexOf(": ↑")+2).Trim();
                // LuaInterface.Debugger.Log(string.Format("{1}:[{0}]",key,"key"));
                var luaFunction = GameEntry.Lua.GetMainState().GetFunction("SocketCache.dump");
                luaFunction.Call(key);
                _isNetLog = true;
            }
         
            if (condition.Contains(downLine))
            {
                lines = condition.Split('\n');
                firstLine = lines[0];
                int index = firstLine.IndexOf(": ↓");
                // LuaInterface.Debugger.Log(string.Format("{1}:[{0}]",index,"index"));
             
                string key = firstLine.Substring(firstLine.IndexOf(": ↓")+2).Trim();
                // LuaInterface.Debugger.Log(string.Format("{1}:[{0}]",key,"key"));
                var luaFunction =GameEntry.Lua.GetMainState().GetFunction("SocketCache.dump");
                luaFunction.Call(key);
                _isNetLog = true;
            }
        }
        catch(Exception e)
        {
            LuaInterface.Debugger.Log(string.Format("{1}:[{0}]",e,"e"));
            return _isNetLog;
        }
        
        return _isNetLog;
    }

    private static bool IsExcelLog(string condition)
    {
//        策划表: resource_resource,缺失数据: 1150003
        return condition.Contains("策划表:") && condition.Contains("缺失数据:");
    }

    private static void GetExcelSVNAuthor(string condition)
    {
//         #if UNITY_EDITOR_WIN
//         
//         var str = condition;
//         int start = str.IndexOf("策划表: ");
//         int end = str.IndexOf(",");
//         var excelFileName = str.Substring(start+5,end - start - 5);
// //        LuaInterface.Debugger.Log(string.Format("{1}:[{0}]",excelFileName,"excelFileName"));
// 		
//         string path = Application.dataPath + "/../LuaSrc/data/"+excelFileName+".lua";
// //        LuaInterface.Debugger.Log(string.Format("{1}:[{0}]",path,"path"));
// 		
//         var author = SVNUtils.GetFileAuthor(path);
// //        LuaInterface.Debugger.Log(string.Format("{1}:[{0}]",author,"author"));
//         
//         var ok = EditorUtility.DisplayDialog (excelFileName+".lua最后提交人：", author, "拷贝并发送给他","查看svn日志");
//
//         condition = condition.Replace("<color=#FFAE00FF>", "");
//         condition = condition.Replace("</color>", "");
//         
//         NGUITools.clipboard = string.Format("[Bug] {0}", condition.Replace("双击找人。",string.Format("{1}负责人：{0}",author,"\n")));
//         if (!ok)
//         {
//             SVNUtils.ShowLuaDataLog(path);
//         }
// #endif
    }
    
    private static string GetListViewRowCount(ref int line)
    {
#if UNITY_2017_1_OR_NEWER
        object rows = StartGettingEntries.Invoke(null, null);
#endif
        int row = (int)logListViewCurrentRow.GetValue(logListView);
        
        LogEntriesGetEntry.Invoke(null, new object[] { row, logEntry });
        string condition = logEntryCondition.GetValue(logEntry) as string;

        if (IsExcelLog(condition))
        {
            GetExcelSVNAuthor(condition);
            return "__EditorCheckSvnExcel";
        }
        
        if (IsNetLog(condition))
        {
            return null;
        }
        condition = condition.Substring(0, condition.IndexOf('\n'));
        condition = condition.Replace ("[string \"event\"]","");
        condition = condition.Replace ("[string \"System/coroutine\"]","");

        int start = condition.IndexOf("[")+1;
        int end = condition.IndexOf(".lua:");
        if (condition.Contains("LuaException:"))
        {
            //"LuaException: event:171: System/coroutine:95:"
            //"LuaException: event:171: System/coroutine:27:"
            //"LuaException: System/coroutine:27:"
            //"LuaException: event:171:"
            //"LuaException:"
            condition = condition.Replace ("LuaException:","");
            condition = Regex.Replace(condition, "(\\s*)event:(\\d*):","");
            condition = Regex.Replace(condition, "(\\s*)System/coroutine:(\\d*):","");
            string result = Regex.Match(condition, "(?<=.:).*?(?=:)").Value;
            
            Int32.TryParse(result, out line);
            
            end = condition.IndexOf(":");
           
            int stringLength = end;
            string file = condition.Substring(0, stringLength);
            
            if (!file.EndsWith(".lua")) {
                file = file+".lua";
            }
            return file;
        }
        else if ( condition.Contains("[ERR]") )
        {
            //todo 新类型的lua报错
            condition = condition.Replace ("[ERR]","");
            //[ERR]  handlePack error:models/user/CurrencyModel:22: attempt to index global 'RewardType' (a nil value)
            condition = Regex.Replace(condition, "(\\s*)handlePack error:","");
            string result = Regex.Match(condition, "(?<=.:).*?(?=:)").Value;
            
            Int32.TryParse(result, out line);
            
            end = condition.IndexOf(":");
            
            int stringLength = end;
            string file = condition.Substring(0, stringLength);
            
            if (!file.EndsWith(".lua")) {
                file = file+".lua";
            }
             return file;
        }
        else
        {
            int stringLength = end - start;
            if (stringLength <= 0)
            {
                return null;
            }
   
            string file = condition.Substring(start, stringLength); ///这里取的行数只适配tolua
        
            string result=Regex.Match(condition,"(?<=.lua:).*?(?=]:)").Value;
            Int32.TryParse(result, out line);
            if (!file.EndsWith(".lua")) {
                file = file+".lua";
            }
            return file;
        }
    }

    public static string GetLuaFilePath(string condition,out int line)
    {
        if (IsNetLog(condition))
        {
            line = 0;
            return null;
        }
        condition = condition.Replace ("[string \"event\"]","");
        condition = condition.Replace ("[string \"System/coroutine\"]","");

        int start = condition.IndexOf("[")+1;
        int end = condition.IndexOf(".lua:");
        
        if (condition.Contains("LuaException: event:171: System/coroutine:95:"))
        {
            start = condition.IndexOf("LuaException: event:171: System/coroutine:95:");
            condition = condition.Replace ("LuaException: event:171: System/coroutine:95:","");
            Debug.Log(string.Format("{1}:[{0}]",condition,"condition"));
            
            end = condition.IndexOf(":");
            int stringLength = end - start;
            if (stringLength <= 0)
            {
                line = 0;
                return null;
            }
            
            string file = condition.Substring(start, stringLength); ///这里取的行数只适配tolua
            Debug.Log(file);
        
            string result=Regex.Match(condition,"(?<=.:).*?(?=: attempt to)").Value;
            Int32.TryParse(result, out line);
            if (!file.EndsWith(".lua")) {
                file = file+".lua";
            }
            return file;
        }
        else if (condition.Contains("LuaException: event:171: System/coroutine:27:"))
        {
            start = condition.IndexOf("LuaException: event:171: System/coroutine:27:");
            condition = condition.Replace ("LuaException: event:171: System/coroutine:27:","");
            Debug.Log(string.Format("{1}:[{0}]",condition,"condition"));
            
            end = condition.IndexOf(":");
            int stringLength = end - start;
            if (stringLength <= 0)
            {
                line = 0;
                return null;
            }
            
            string file = condition.Substring(start, stringLength); ///这里取的行数只适配tolua
            Debug.Log(file);
        
            string result=Regex.Match(condition,"(?<=.:).*?(?=: attempt to)").Value;
            Int32.TryParse(result, out line);
            if (!file.EndsWith(".lua")) {
                file = file+".lua";
            }
            return file;
        }//
        else if (condition.Contains("LuaException: System/coroutine:27:"))
        {
            start = condition.IndexOf("LuaException: System/coroutine:27:");
            condition = condition.Replace ("LuaException: System/coroutine:27:","");
            Debug.Log(string.Format("{1}:[{0}]",condition,"condition"));
            
            end = condition.IndexOf(":");
            int stringLength = end - start;
            if (stringLength <= 0)
            {
                line = 0;
                return null;
            }
            
            string file = condition.Substring(start, stringLength); ///这里取的行数只适配tolua
            Debug.Log(file);
        
            string result=Regex.Match(condition,"(?<=.:).*?(?=: attempt to)").Value;
            Int32.TryParse(result, out line);
            if (!file.EndsWith(".lua")) {
                file = file+".lua";
            }
            return file;
        }
        else if (condition.Contains("LuaException: event:171:"))
        {
            start = condition.IndexOf("LuaException: event:171:");
            condition = condition.Replace ("LuaException: event:171:","");
            end = condition.IndexOf(":");
            int stringLength = end - start;
            if (stringLength <= 0)
            {
                line = 0;
                return null;
            }
   
            string file = condition.Substring(start, stringLength); ///这里取的行数只适配tolua
            Debug.Log(file);
        
            string result=Regex.Match(condition,"(?<=.:).*?(?=: attempt to)").Value;
            Int32.TryParse(result, out line);
            if (!file.EndsWith(".lua")) {
                file = file+".lua";
            }
            return file;
        }
        else if (condition.Contains("LuaException:"))
        {
            start = condition.IndexOf("LuaException:");
            condition = condition.Replace ("LuaException:","");
            end = condition.IndexOf(":");
            int stringLength = end - start;
            if (stringLength <= 0)
            {
                line = 0;
                return null;
            }
   
            string file = condition.Substring(start, stringLength); ///这里取的行数只适配tolua
            Debug.Log(file);
        
            string result=Regex.Match(condition,"(?<=.:).*?(?=: attempt to)").Value;
            Int32.TryParse(result, out line);
            if (!file.EndsWith(".lua")) {
                file = file+".lua";
            }
            return file;
        }
        else
        {
            int stringLength = end - start;
            if (stringLength <= 0)
            {
                line = 0;
                return null;
            }
   
            string file = condition.Substring(start, stringLength); ///这里取的行数只适配tolua
        
            string result=Regex.Match(condition,"(?<=.lua:).*?(?=]:)").Value;
            Int32.TryParse(result, out line);
            if (!file.EndsWith(".lua")) {
                file = file+".lua";
            }
            return file;
        }
    }
    
    public static bool OnOpenConsoleE(string txt)
    {
        int line = 0;
        string fileName = GetLuaFilePath(txt,out line);

        if (fileName == null)
        {
//            if (OnOpenByDefault(instanceID, line))
//            {
//                return true;
//            }
//            return false;
            return true;
        }
        OnOpenAsset(fileName, line);

        return false;
    }


    private static bool StartWithIgnoreLine(string text, bool isDefalut)
    {
        string[] ignoreLines = isDefalut ? CS_IGNORE_LINE : LUA_IGNORE_LINE;
        for (int i = 0; i < ignoreLines.Length; i++)
        {
            if (text.Trim().StartsWith(ignoreLines[i]))
            {
                return true;
            }
        }
        return false;
    }

    private static string ParseLuaRowCount(string text, out int line)
    {
        int startIndex = text.IndexOf("[");
        int endIndex = text.IndexOf("]:");
        string fileNameStr = text.Substring(startIndex + 9, endIndex - 1 - (startIndex + 9)) + ".lua";
        int lineTxtStartIndex = endIndex;
        int lineTxtEndIndex = text.IndexOf(":", lineTxtStartIndex + 2);
        string _line = text.Substring(lineTxtStartIndex + 2, lineTxtEndIndex - (lineTxtStartIndex + 2)); ///这里取的行数只适配tolua
        Int32.TryParse(_line, out line);
        return fileNameStr;
    }

    private static bool OnOpenByDefault(int instanceID, int line)
    {
        string fileName = GetListViewRowCountByDefault(ref line);
        if (fileName == null)
        {
            return false;
        }

        if (msDefaultOpenInstanceID == instanceID && msDefaultOpenLine == line)
        {
            msDefaultOpenInstanceID = -1;
            msDefaultOpenLine = -1;
            return false;
        }
        msDefaultOpenInstanceID = instanceID;
        msDefaultOpenLine = line;

        OpenFileByDefault(fileName, line);
        return true;
    }

    private static string GetLog()
    {
        int row = (int)logListViewCurrentRow.GetValue(logListView);
        LogEntriesGetEntry.Invoke(null, new object[] { row, logEntry });
        return logEntryCondition.GetValue(logEntry) as string;
    }

    private static string GetListViewRowCountByDefault(ref int line)
    {
        string oriCondition = GetLog();
        int index = oriCondition.IndexOf("UnityEngine.Debug:");
        if (index >= 0)
        {
            string traceback = oriCondition.Substring(index);
            string[] stracebacks = traceback.Split(new char[] { '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < stracebacks.Length; i++)
            {
                if (!StartWithIgnoreLine(stracebacks[i], true))
                {
                    return ParseCSRowCount(stracebacks[i], out line);
                }
            }
        }
        return null;
    }

    private static string ParseCSRowCount(string text, out int line)
    {
        int startIndex = text.LastIndexOf("(at ") + 4;
        int endIndex = text.LastIndexOf(")");
        string fileNameAndLine = text.Substring(startIndex, endIndex - startIndex);
        string[] splitResults = fileNameAndLine.Split(':');
        Int32.TryParse(splitResults[1].Trim(), out line);
        string fileName = splitResults[0];
        return fileName;
    }

    public static void OpenFileByDefault(string filePath, int line)
    {
        UnityEngine.Object obj = AssetDatabase.LoadAssetAtPath(filePath, typeof(MonoScript));
        AssetDatabase.OpenAsset(obj, line);
    }
}

}
#endif
