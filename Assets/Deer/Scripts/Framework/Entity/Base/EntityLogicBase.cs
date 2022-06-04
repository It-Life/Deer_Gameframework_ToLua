// ================================================
//描 述 :  
//作 者 : 杜鑫 
//创建时间 : 2021-08-17 23-50-04  
//修改作者 : 杜鑫 
//修改时间 : 2021-08-17 23-50-04  
//版 本 : 0.1 
// ===============================================
using GameFramework;
using UnityEngine;
using UnityGameFramework.Runtime;
using LuaInterface;


public class EntityLogicBase : EntityLogic
{
    public int Id
    {
        get
        {
            return Entity.Id;
        }
    }

    public LuaTable m_LuaData;

    public LuaTable m_LuaOwner;

    public LuaFunction m_OnCollision;
    public LuaFunction m_OnTrigger;

    public void InitLuaTable(LuaTable luaTable) 
    {
        m_LuaOwner = luaTable;
        m_OnCollision = luaTable.GetLuaFunction("OnCollision");
        m_OnTrigger = luaTable.GetLuaFunction("OnTrigger");
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
        m_OnCollision  =null;
        m_OnTrigger = null;
        m_LuaOwner = null;
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

    private void OnCollisionEnter(Collision collision)
    {
        //Log.Error("OnCollisionEnter");
        if (m_LuaData == null)
        {
            return;
        }
        var m_canCollisionEnter = m_LuaData["m_canCollisionEnter"];
        if (m_canCollisionEnter == null) 
        {
            return ;
        }
        bool isCanCollision = m_canCollisionEnter.ToString().Equals("True");
        if (!isCanCollision)
        {
            return;
        }
        if (m_OnCollision != null)
        {
            Log.Info("OnCollisionEnter gameobject name is " + collision.gameObject.name);
            m_OnCollision.Call(m_LuaOwner, 1, collision.gameObject);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (m_LuaData == null)
        {
            return;
        }
        var m_canCollisionExit = m_LuaData["m_canCollisionExit"];
        if (m_canCollisionExit == null)
        {
            return;
        }
        bool isCanCollision = m_canCollisionExit.ToString().Equals("True");
        if (!isCanCollision)
        {
            return;
        }
        if (m_OnCollision != null)
        {
            Log.Info("OnCollisionExit gameobject name is " + collision.gameObject.name);
            m_OnCollision.Call(m_LuaOwner, 3, collision.gameObject);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (m_LuaData == null)
        {
            return;
        }
        var m_canCollisionStay = m_LuaData["m_canCollisionStay"];
        if (m_canCollisionStay == null)
        {
            return;
        }
        bool isCanCollision = m_canCollisionStay.ToString().Equals("True");
        if (!isCanCollision)
        {
            return;
        }
        if (m_OnCollision != null)
        {
            Log.Info("OnCollisionStay gameobject name is " + collision.gameObject.name);
            m_OnCollision.Call(m_LuaOwner, 2, collision.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (m_LuaData == null)
        {
            return;
        }
        var m_canTriggerEnter = m_LuaData["m_canTriggerEnter"];
        if (m_canTriggerEnter == null)
        {
            return;
        }
        bool isCanCollision = m_canTriggerEnter.ToString().Equals("True");
        if (!isCanCollision)
        {
            return;
        }
        if (m_OnTrigger != null)
        {
            Log.Info("OnTriggerEnter gameobject name is " + other.gameObject.name);
            m_OnTrigger.Call(m_LuaOwner, 1, other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (m_LuaData == null)
        {
            return;
        }
        var m_canTriggerExit = m_LuaData["m_canTriggerExit"];
        if (m_canTriggerExit == null)
        {
            return;
        }
        bool isCanCollision = m_canTriggerExit.ToString().Equals("True");
        if (!isCanCollision)
        {
            return;
        }
        if (m_OnTrigger != null)
        {
            Log.Info("OnTriggerExit gameobject name is " + other.gameObject.name);
            m_OnTrigger.Call(m_LuaOwner, 3, other.gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (m_LuaData == null)
        {
            return;
        }
        var m_canTriggerStay = m_LuaData["m_canTriggerStay"];
        if (m_canTriggerStay == null)
        {
            return;
        }
        bool isCanCollision = m_canTriggerStay.ToString().Equals("True");
        if (!isCanCollision)
        {
            return;
        }
        if (m_OnTrigger != null)
        {
            Log.Info("OnTriggerStay gameobject name is " + other.gameObject.name);
            m_OnTrigger.Call(m_LuaOwner, 2, other.gameObject);
        }
    }
}
