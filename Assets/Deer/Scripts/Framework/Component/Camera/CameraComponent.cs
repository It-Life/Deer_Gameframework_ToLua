// ================================================
//描 述 :  
//作 者 : 杜鑫 
//创建时间 : 2021-08-28 13-57-10  
//修改作者 : 杜鑫 
//修改时间 : 2021-08-28 13-57-10  
//版 本 : 0.1 
// ===============================================
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityGameFramework.Runtime;

public enum CameraType 
{
    FollowCamera = 0,
    RotateCamera = 1,
}

public class CameraModel 
{
    public CinemachineVirtualCamera CinemachineVirtual;
    public CameraType CameraType = CameraType.FollowCamera;
}
[DisallowMultipleComponent]
[AddComponentMenu("Deer/Camera")]
public class CameraComponent : GameFrameworkComponent
{
    /// <summary>
    /// 主相机
    /// </summary>
    public Camera m_MainCamera;
    [SerializeField]
    private CinemachineVirtualCamera m_FollowCamera;
    [SerializeField]
    private CinemachineStateDrivenCamera m_FollowStateDrivenCamera;

    protected override void Awake()
    {
        base.Awake();
        m_MainCamera = transform.Find("MainCamera").GetComponent<Camera>();
        m_FollowCamera = transform.Find("FollowVirtual").GetComponent<CinemachineVirtualCamera>();
        m_FollowStateDrivenCamera = transform.Find("CMStateDrivenCamera").GetComponent<CinemachineStateDrivenCamera>();
    }

    public void OpenCameraType()
    { 
    
    }
    public void LookAtTarget(Transform transform) 
    {
        m_FollowStateDrivenCamera.LookAt = transform;  
    }

    public void FollowTarget(Transform transform)
    {
        m_FollowStateDrivenCamera.Follow = transform;
    }

    public void FollowTarget(Transform transform, Vector3 position)
    {
        m_FollowStateDrivenCamera.Follow = transform;
        m_FollowCamera.transform.localPosition = position;
    }

    public void FollowTarget(Transform transform,Vector3 position, Quaternion quaternion)
    {
        m_FollowCamera.Follow = transform;
        m_FollowCamera.transform.localPosition = position;
        m_FollowCamera.transform.localRotation = quaternion;
    }
    
    public void FollowAndLookAtTarget(Transform followTrans,Transform lookAtTrans)
    {
        m_FollowStateDrivenCamera.Follow = followTrans;
        m_FollowStateDrivenCamera.LookAt = lookAtTrans;
    }
    
    public void CameraActive(bool isActive)
    {
        m_MainCamera.gameObject.SetActive(isActive);   
    }
}