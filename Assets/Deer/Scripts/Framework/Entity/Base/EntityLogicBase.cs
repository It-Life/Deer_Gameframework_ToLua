﻿// ================================================
//描 述 :  
//作 者 : 杜鑫 
//创建时间 : 2021-08-17 23-50-04  
//修改作者 : 杜鑫 
//修改时间 : 2021-08-17 23-50-04  
//版 本 : 0.1 
// ===============================================
using GameFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;


public class EntityLogicBase : EntityLogic
{
    public int Id
    {
        get
        {
            return Entity.Id;
        }
    }

#if UNITY_2017_3_OR_NEWER
    protected override void OnInit(object userData)
#else
        protected internal override void OnInit(object userData)
#endif
    {
        base.OnInit(userData);
    }

#if UNITY_2017_3_OR_NEWER
    protected override void OnRecycle()
#else
        protected internal override void OnRecycle()
#endif
    {
        base.OnRecycle();
    }

#if UNITY_2017_3_OR_NEWER
    protected override void OnShow(object userData)
#else
        protected internal override void OnShow(object userData)
#endif
    {
        base.OnShow(userData);
        MessengerInfo messengerInfo = ReferencePool.Acquire<MessengerInfo>();
        messengerInfo.param1 = Id;
        messengerInfo.param2 = userData;
        GameEntry.Messenger.SendEvent(EventName.EVENT_CS_GAME_ENTITY_SHOW, messengerInfo);
        ReferencePool.Release(messengerInfo);
    }

#if UNITY_2017_3_OR_NEWER
    protected override void OnHide(bool isShutdown, object userData)
#else
        protected internal override void OnHide(bool isShutdown, object userData)
#endif
    {
        base.OnHide(isShutdown, userData);
        MessengerInfo messengerInfo = ReferencePool.Acquire<MessengerInfo>();
        messengerInfo.param1 = Id;
        messengerInfo.param2 = userData;
        GameEntry.Messenger.SendEvent(EventName.EVENT_CS_GAME_ENTITY_HIDE, messengerInfo);
        ReferencePool.Release(messengerInfo);
    }

#if UNITY_2017_3_OR_NEWER
    protected override void OnAttached(EntityLogic childEntity, Transform parentTransform, object userData)
#else
        protected internal override void OnAttached(EntityLogic childEntity, Transform parentTransform, object userData)
#endif
    {
        base.OnAttached(childEntity, parentTransform, userData);
    }

#if UNITY_2017_3_OR_NEWER
    protected override void OnDetached(EntityLogic childEntity, object userData)
#else
        protected internal override void OnDetached(EntityLogic childEntity, object userData)
#endif
    {
        base.OnDetached(childEntity, userData);
    }

#if UNITY_2017_3_OR_NEWER
    protected override void OnAttachTo(EntityLogic parentEntity, Transform parentTransform, object userData)
#else
        protected internal override void OnAttachTo(EntityLogic parentEntity, Transform parentTransform, object userData)
#endif
    {
        base.OnAttachTo(parentEntity, parentTransform, userData);
    }

#if UNITY_2017_3_OR_NEWER
    protected override void OnDetachFrom(EntityLogic parentEntity, object userData)
#else
        protected internal override void OnDetachFrom(EntityLogic parentEntity, object userData)
#endif
    {
        base.OnDetachFrom(parentEntity, userData);
    }

#if UNITY_2017_3_OR_NEWER
    protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
#else
        protected internal override void OnUpdate(float elapseSeconds, float realElapseSeconds)
#endif
    {
        base.OnUpdate(elapseSeconds, realElapseSeconds);
    }
}
