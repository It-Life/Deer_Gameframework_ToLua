// ================================================
//描 述:
//作 者:XinDu
//创建时间:2022-06-01 11-59-18
//修改作者:XinDu
//修改时间:2022-06-01 11-59-18
//版 本:0.1 
// ===============================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 脚本挂载新建相机上 —— 新相机Clear Flags清除标记设置为：Solid Color，不然会显示天空盒
/// </summary>
public class SmoothUI3DCamera : MonoBehaviour
{
    public Camera modelCamera;
    public Transform pivot;
    public Vector3 pivotOffset = Vector3.zero;
    public Transform target;
    public float distance = 10.0f;
    public float minDistance = 2f;
    public float maxDistance = 15f;
    public float zoomSpeed = 1f;
    public float xSpeed = 250.0f;
    public float ySpeed = 250.0f;
    public bool allowYTilt = true;
    public float yMinLimit = -90f;
    public float yMaxLimit = 90f;
    private float x = 0.0f;
    private float y = 0.0f;
    private float targetX = 0f;
    private float targetY = 0f;
    private float targetDistance = 0f;
    private float xVelocity = 1f;
    private float yVelocity = 1f;
    private float zoomVelocity = 1f;
    private bool isInitialize;

    public bool IsInitialize { get { return isInitialize; } }

    private void Start()
    {
        ResetData();
    }

    public void Initialize(Transform target) 
    {
        if (isInitialize) return;
        this.target = target;
        ResetData();
        isInitialize = true;
    }

    private void ResetData()
    {
        var angles = modelCamera.transform.eulerAngles;
        targetX = x = angles.x;
        targetY = y = ClampAngle(angles.y, yMinLimit, yMaxLimit);
        targetDistance = distance;
    }

    private void LateUpdate()
    {
        if (!target) return;
        if (!pivot) return;
        var scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0.0f) targetDistance -= zoomSpeed;
        else if (scroll < 0.0f)
            targetDistance += zoomSpeed;
        targetDistance = Mathf.Clamp(targetDistance, minDistance, maxDistance);
        if (Input.GetMouseButton(1) || (Input.GetMouseButton(0) && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))))
        {
            targetX += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            if (allowYTilt)
            {
                targetY -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
                targetY = ClampAngle(targetY, yMinLimit, yMaxLimit);
            }
        }

        x = Mathf.SmoothDampAngle(x, targetX, ref xVelocity, 0.3f);
        y = allowYTilt ? Mathf.SmoothDampAngle(y, targetY, ref yVelocity, 0.3f) : targetY;
        Quaternion rotation = Quaternion.Euler(y, x, 0);
        distance = Mathf.SmoothDamp(distance, targetDistance, ref zoomVelocity, 0.5f);
        Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distance) + pivot.position + pivotOffset;
        modelCamera.transform.rotation = rotation;
        modelCamera.transform.position = position;
    }


    private static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}