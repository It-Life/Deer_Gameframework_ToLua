// ================================================
//描 述 :  
//作 者 : 杜鑫 
//创建时间 : 2021-12-13 23-39-11  
//修改作者 : 杜鑫 
//修改时间 : 2021-12-13 23-39-11  
//版 本 : 0.1 
// ===============================================
using System.Collections;
using System.Collections.Generic;
using ConfigData;
using Deer;
using LuaInterface;
using UnityEngine;
public class SoundsConfigDataInfo : ConfigBase<SoundsConfigDataInfo>
{
	public Sounds_Config_Data data;
	public override string Name => "Sounds_Config";
	private Dictionary<uint, Sounds_Config> m_Infos = new Dictionary<uint, Sounds_Config>();

	public override IEnumerator LoadConfig(string path)
	{
		data = AnalyseConfig<Sounds_Config_Data>(Name,path);
		if (data != null)
		{
			foreach (var t in data.Items)
			{
				m_Infos.Add(t.Id, t);
			}
		}
		yield return null;
	}

	public Sounds_Config GetConfigById(uint soundId)
	{
		Sounds_Config config;
		if (m_Infos.TryGetValue(soundId, out config))
		{
			return config;
		}

		return null;
	}

	public override void Clear()
	{
		data = null;
	}
}