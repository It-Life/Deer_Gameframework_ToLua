// ================================================
//描 述:
//作 者:杜鑫
//创建时间:2022-05-11 15-56-25
//修改作者:杜鑫
//修改时间:2022-05-11 15-56-25
//版 本:0.1 
// ===============================================
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Please modify the description.
/// </summary>
namespace Deer
{
#if UNITY_EDITOR
	[Serializable]
	public class PanelItemInfo
	{
		[Title("界面创建的预制件单位")]
		[HorizontalGroup, HideLabel]
		[OnValueChanged("UpdateGameObject")]
		public GameObject Object;
		[Title("预制件名字")]
		[HorizontalGroup(Width = .2f), HideLabel]
		public string Name;

		void UpdateGameObject()
		{
			SetName();
		}
		void SetName()
		{
			if (Object != null)
			{
				Name = Object.name.Replace("(", "")
					.Replace(")", "")
					.Replace(" ", "");
				Name = StringUtils.ToLowerCase(Name);
			}
		}
	}

#else
	[Serializable]
	public class PanelItemInfo
	{
		public GameObject Object;
		public string Name;
	}
#endif
}