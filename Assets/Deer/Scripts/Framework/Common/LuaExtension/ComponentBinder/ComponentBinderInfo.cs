// ================================================
//描 述 :  
//作 者 : 杜鑫 
//创建时间 : 2021-07-10 12-29-51  
//修改作者 : 杜鑫 
//修改时间 : 2021-07-10 12-29-51  
//版 本 : 0.1 
// ===============================================
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Deer
{
#if UNITY_EDITOR
    [Serializable]
    public class ComponentBinderInfo
    {
        [HorizontalGroup, HideLabel, ChildGameObjectsOnly]
        [OnValueChanged("UpdateGameObject")]
        public GameObject Object;

        [HorizontalGroup(Width = .2f), HideLabel]
        public string Name;

#pragma warning disable CS0649
        [HorizontalGroup, HideLabel]
        [ValueDropdown("GetFilteredTypeList")]
        [OnValueChanged("UpdateComponent")]
        public string ComponentType;
#pragma warning restore CS0649

        [HideInInspector]
        public Component componet;

        [HorizontalGroup(Width = 30), HideLabel, PreviewField(25, ObjectFieldAlignment.Left), ReadOnly]
        public Component componetPreview;

        [HorizontalGroup("gr", Width = 30), ShowIf("@this.ComponentType == \"UIButtonSuper\""), LabelWidth(70)]
        public bool canClick => ComponentType == "UIButtonSuper";

        [HorizontalGroup("gr", Width = 30), ShowIf("@this.ComponentType == \"UIButtonSuper\""), LabelWidth(70)]
        public bool canDoubleClick = false;
        
        [HorizontalGroup("gr", Width = 30), ShowIf("@this.ComponentType == \"UIButtonSuper\""), LabelWidth(70)]
        public bool canPress = false;

        [HorizontalGroup("gr"), ShowIf("@this.ComponentType == \"UIButtonSuper\""), LabelWidth(60)]
        [OnValueChanged("UpdateSoundId")]
        public SoundTypeEnum soundId = SoundTypeEnum.BtnDefaultClick;
        [HideInInspector]
        public string m_soundId = SoundTypeEnum.BtnDefaultClick.ToString();

        /// <summary>
        /// typeName获取类型
        /// </summary>
        /// <returns></returns>
        private IEnumerable<string> GetFilteredTypeList()
        {
            var gameObj = Object;
            if (gameObj != null)
            {
                var components = gameObj.GetComponents<Component>();
                var typeNames = components.Select(t =>
                {
                    if (t != null)
                    {
                        return t.GetType().Name;
                    }

                    return null;
                });
                return typeNames;
            }

            return null;
        }
        private void UpdateComponent()
        {
            componet = Object.GetComponent(ComponentType);
            componetPreview = componet;
        }
        private void UpdateComponentPreview()
        {
            var scrollRect = Object.GetComponent<ScrollRect>();
            if (scrollRect)
            {
                componetPreview = scrollRect;
            }
            else
            {
                Image image = Object.GetComponent<Image>();
                if (image)
                {
                    componetPreview = image;
                }
                else
                {
                    componetPreview = componet;
                }
            }
        }
        private void InitComponent()
        {
            if (Object)
            {
                var components = Object.GetComponents<Component>();
                componet = components[components.Length - 1];
                UpdateComponentPreview();
                ComponentType = componet.GetType().Name;
            }
        }
        void UpdateSoundId()
        {
            m_soundId = soundId.ToString();
        }
        void UpdateGameObject()
        {
            InitComponent();
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
    public class ComponentBinderInfo 
    {
        public GameObject Object;
        public string Name;
        public string ComponentType;
        public Component componet;
        public Component componetPreview;
        public bool canClick => ComponentType == "UIButtonSuper";
        public bool canDoubleClick = false;
        public bool canPress = false;
        public SoundTypeEnum soundId = SoundTypeEnum.None;
        public string m_soundId = SoundTypeEnum.None.ToString();
    }
#endif
}