// ================================================
//描 述 :  
//作 者 : 杜鑫 
//创建时间 : 2021-08-07 00-47-59  
//修改作者 : 杜鑫 
//修改时间 : 2021-08-07 00-47-59  
//版 本 : 0.1 
// ===============================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Deer
{
    public class AtlasScriptableObject : ScriptableObject
    {
        public Sprite[] m_Sprites;

        private Dictionary<string, int> Index = new Dictionary<string, int>();
        private int indexS = 0;

        public Sprite[] SetSP
        {
            set
            {
                m_Sprites = value;
            }
        }

        public Sprite GetSprite(string spName)
        {
            if (string.IsNullOrEmpty(spName))
            {
                return m_Sprites[indexS];
            }
            if (Index.Count == 0)
            {
                Log.Warning("SpriteName:{0} have count is 0",spName);
                for (int i = 0; i < m_Sprites.Length; i++)
                {
                    Index.Add(m_Sprites[i].name, i);
                }
            }
            if (Index.TryGetValue(spName, out indexS))
            {
                return m_Sprites[indexS];
            }
            return null;
        }

        public int GetSpriteCount()
        {
            return m_Sprites.Length;
        }
        
        public Sprite GetSpriteByIndex(int index)
        {
            return m_Sprites[index];
        }
    }
}