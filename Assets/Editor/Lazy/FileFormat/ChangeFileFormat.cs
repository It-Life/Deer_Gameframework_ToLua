// ================================================
//描 述 :  
//作 者 : 杜鑫 
//创建时间 : 2021-10-31 10-01-11  
//修改作者 : 杜鑫 
//修改时间 : 2021-10-31 10-01-11  
//版 本 : 0.1 
// ===============================================
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;
public class ChangeFileFormat
{
	[MenuItem("MyTools/File/ChangeLuaScriptToUtf8NoBom")]
	public static void ChangeLuaScriptToUtf8NoBom()
	{
		List<string> files = FileUtils.FindFiles(LuaConst.luaDir);
		foreach (string filePath in files)
		{
			StreamReader streamReader = new StreamReader(filePath);
			string text = streamReader.ReadToEnd();
			streamReader.Close();
			bool encoderShouldEmitUTF8Identifier = false;
			bool throwOnInvalidBytes = false;
			UTF8Encoding encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier, throwOnInvalidBytes);
			bool append = false;
			StreamWriter streamWriter = new StreamWriter(filePath, append, encoding);
			streamWriter.Write(text);
			streamWriter.Close();
			AssetDatabase.ImportAsset(filePath);
			AssetDatabase.Refresh();
			AssetDatabase.SaveAssets();
		}
	}
}