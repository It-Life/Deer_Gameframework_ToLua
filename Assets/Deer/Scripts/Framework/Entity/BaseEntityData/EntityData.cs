﻿// ================================================
//描 述 :  
//作 者 : 杜鑫 
//创建时间 : 2021-08-17 23-53-22  
//修改作者 : 杜鑫 
//修改时间 : 2021-08-17 23-53-22  
//版 本 : 0.1 
// ===============================================
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EntityData
{
    private int m_Id = 0;
    /// <summary>
    /// 实体编号。
    /// </summary>
    public int Id => m_Id;

    private int m_TypeId = 0;
    /// <summary>
    /// 实体类型编号。
    /// </summary>
    public int TypeId => m_TypeId;

    private string m_AssetName;
    /// <summary>
    /// 实体资源路径。
    /// </summary>
    public string AssetName
    {
        get => m_AssetName;
        set => m_AssetName = value;
    }

    private Vector3 m_Position;

    public Vector3 Position
    {
        get => m_Position;
        set => m_Position = value;
    }

    public bool IsOwner = false;
    
    public EntityData(int entityId, int typeId, string assetName)
    {
        m_Id = entityId;
        m_TypeId = typeId;
        m_AssetName = assetName;
    }
}
