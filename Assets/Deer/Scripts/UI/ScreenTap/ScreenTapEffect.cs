// ================================================
//描 述 :  
//作 者 : 杜鑫 
//创建时间 : 2021-12-18 22-10-48  
//修改作者 : 杜鑫 
//修改时间 : 2021-12-18 22-10-48  
//版 本 : 0.1 
// ===============================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ScreenTapEffect : MonoBehaviour
{
/// <summary>
    /// 屏幕特效原始资源
    /// </summary>
    public GameObject effectSample;

    /// <summary>
    /// 屏幕特效的生命时长，超过后会进行缓存
    /// </summary>
    public float lifeTime = 1.0f;

    /// <summary>
    /// 屏幕特效的容器（父对象）
    /// </summary>
    public RectTransform steContainer;

    /// <summary>
    /// 屏幕特效渲染使用的相机
    /// </summary>
    public Camera steUIRenderCamera;

    private Queue<GameObject> pool = new Queue<GameObject>(20);
    private List<GameObject> activatedSTEList = new List<GameObject>();

    private void Awake()
    {
        if(effectSample == null)
        {
            Debug.LogErrorFormat("没有找到屏幕特效");
            this.enabled = false;
        }
        else
        {
            effectSample.SetActive(false);
        }

        if (steContainer==null)
        {
            steContainer = transform.GetComponent<RectTransform>();
        }

        if (steUIRenderCamera==null)
        {
            GameObject cameraObj = GameObject.Find("UICamera");
            if (cameraObj!=null)
            {
                steUIRenderCamera = cameraObj.GetComponent<Camera>();
            }
        }
    }

    private void Update()
    {
        for (int i = activatedSTEList.Count - 1; i >= 0; --i)
        {
            GameObject ste = activatedSTEList[i];
            float steTime = float.Parse(ste.name);
            if(Time.time - steTime > lifeTime)
            {
                RecycleSTE(ste);
                activatedSTEList.RemoveAt(i);
            }
        }

        if (Application.isMobilePlatform)
        {
            for(int i = 0; i < Input.touchCount; ++i)
            {
                Touch touch = Input.GetTouch(i);
                if(touch.phase == TouchPhase.Began)
                {
                    PlaySTE(touch.position);
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                PlaySTE(Input.mousePosition);
            }
        }
    }


    private void PlaySTE(Vector2 tapPos)
    {
        GameObject ste = CreateFX();
        ste.name = Time.time.ToString();
        activatedSTEList.Add(ste);

        RectTransform steRectTrans = ste.GetComponent<RectTransform>();
        Vector2 steLocalPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(steContainer, tapPos, steUIRenderCamera, out steLocalPos);
        steRectTrans.SetParent(steContainer);
        steRectTrans.anchoredPosition3D = steLocalPos;
        ste.SetActive(true);
    }


    private GameObject CreateFX()
    {
        GameObject newSte = null;
        if(pool.Count > 0)
        {
            newSte = pool.Dequeue();
        }
        else
        {
            newSte = Instantiate(effectSample);
        }
        return newSte;
    }

    private void RecycleSTE(GameObject ste)
    {
        ste.SetActive(false);
        pool.Enqueue(ste);
    }
}