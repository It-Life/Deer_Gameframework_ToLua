// ================================================
//描 述 :  
//作 者 : 杜鑫 
//创建时间 : 2021-10-06 23-48-15  
//修改作者 : 杜鑫 
//修改时间 : 2021-10-06 23-48-15  
//版 本 : 0.1 
// ===============================================

using GameFramework;
using LuaInterface;
using UnityEngine;
/// <summary>
/// 自定义 Lua 资源加载器。
/// </summary>
public class CustomLuaFileLoader : LuaFileUtils
{
	public delegate bool GetLuaScriptContentDelegate(string fileName, out byte[] buffer);

	private GetLuaScriptContentDelegate m_GetScript;

	public GetLuaScriptContentDelegate GetLuaScriptContent 
	{
		get
		{
			return m_GetScript;
		}
		set
		{
			m_GetScript = value;
		}
	}


	public new static CustomLuaFileLoader Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new CustomLuaFileLoader();
			}

			return instance as CustomLuaFileLoader;
		}

		protected set
		{
			instance = value;
		}
	}
	
	public CustomLuaFileLoader()
	{
	}
	public CustomLuaFileLoader(GetLuaScriptContentDelegate getScript) : base()
	{
		GetLuaScriptContent = getScript;
	}
	public override byte[] ReadFile(string fileName)
	{
		if (Application.isEditor && GameEntry.Base.EditorResourceMode)
		{
			return base.ReadFile(fileName);
		}

		if (!fileName.EndsWith(".lua"))
		{
			fileName += ".lua";
		}

		byte[] buffer;
		if (!GetLuaScriptContent(fileName, out buffer))
		{
			throw new GameFramework.GameFrameworkException($"File '{fileName}' not loaded.");
		}

		return buffer;
	}
	
}
