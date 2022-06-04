// ================================================
//描 述:
//作 者:杜鑫
//创建时间:2022-05-11 11-25-42
//修改作者:杜鑫
//修改时间:2022-05-11 11-25-42
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
	public class SubPanelInfo
	{
		[Title("子界面预制体")]
		[HorizontalGroup, HideLabel]
		[OnValueChanged("UpdateGameObject")]
		public GameObject Object;
		[Title("子界面名字")]
		[HorizontalGroup(Width = .2f), HideLabel]
		public string Name;
		[Title("子界面生成节点")]
		[HorizontalGroup, HideLabel, ChildGameObjectsOnly]
		public GameObject SubPanelNode;

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
	public class SubPanelInfo
	{
		public GameObject Object;
		public string Name;
		public GameObject SubPanelNode;
	}
#endif
}