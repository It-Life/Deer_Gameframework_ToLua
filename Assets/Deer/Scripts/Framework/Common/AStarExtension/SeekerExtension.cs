// ================================================
//描 述:
//作 者:XinDu
//创建时间:2022-05-03 18-35-09
//修改作者:XinDu
//修改时间:2022-05-03 18-35-09
//版 本:0.1 
// ===============================================
using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Seeker 扩展
/// </summary>
public static class SeekerExtension 
{
    public static Path StartPath(this Seeker seeker,float startx,float starty,float startz,float endx,float endy,float endz, OnPathDelegate callback)
    {
        return seeker.StartPath(new Vector3(startx,starty,startz),new Vector3(endx,endy,endz), callback);
    }
}