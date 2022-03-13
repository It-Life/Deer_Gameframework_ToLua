// ================================================
//描 述 :  
//作 者 : 杜鑫 
//创建时间 : 2021-08-04 23-29-11  
//修改作者 : 杜鑫 
//修改时间 : 2021-08-04 23-29-11  
//版 本 : 0.1 
// ===============================================
using Deer;
using GameFramework;
using GameFramework.ObjectPool;
using GameFramework.Resource;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

[DisallowMultipleComponent]
[AddComponentMenu("Deer/TPSprite")]
public class TPSpriteComponent : GameFrameworkComponent
{
    private IObjectPool<AssetInstanceObject> m_InstancePool; //资源池   
    private LoadAssetCallbacks m_LoadAssetCallbacks; //加载回调                    
    private Dictionary<Object, AssetInstanceObject> m_Images;
    private Dictionary<Object, string> m_ImageInfoNames;
    protected override void Awake()
    {
        base.Awake();
        m_LoadAssetCallbacks = new LoadAssetCallbacks(LoadTpSuccessCallback, LoadTpFailureCallback, LoadTpUpdateCallback, LoadTpDependencyAssetCallback);
        m_Images = new Dictionary<Object, AssetInstanceObject>();
        m_ImageInfoNames = new Dictionary<Object, string>();
    }
    private void Start()
    {
        m_InstancePool = GameEntry.ObjectPool.CreateMultiSpawnObjectPool<AssetInstanceObject>("UI TPSprite Pool", 10, 64, 5, 0);
    }
    public void SetImage(Image targetImage, string strAssetPath, string strSpriteName, bool setNativeSize = false)
    {
        AssetInstanceObject assetObject = m_InstancePool.Spawn(strAssetPath);
        if (assetObject == null)
        {
            LoadSpriteInfo loadSpriteInfo = LoadSpriteInfo.Create(targetImage, strAssetPath, strSpriteName, setNativeSize);
            //m_TPSpriteBeingLoaded.Add(nLoadSerial, loadSpriteInfo);
            GameEntry.Resource.LoadAsset(strAssetPath, typeof(AtlasScriptableObject), Constant.AssetPriority.TextureAsset, m_LoadAssetCallbacks, loadSpriteInfo);
        }
        else
        {
            InternalSetImage(targetImage, assetObject, strSpriteName, setNativeSize);
        }
    }

    public void SetImage(Image targetImage, string strAssetPath, bool setNativeSize = false)
    {
        AssetInstanceObject assetObject = m_InstancePool.Spawn(strAssetPath);
        if (assetObject == null)
        {
            LoadSpriteInfo loadSpriteInfo = LoadSpriteInfo.Create(targetImage, strAssetPath, "", setNativeSize);
            GameEntry.Resource.LoadAsset(strAssetPath, typeof(Texture2D), Constant.AssetPriority.TextureAsset, m_LoadAssetCallbacks, loadSpriteInfo);
        }
        else
        {
            InternalSetImage(targetImage, assetObject, setNativeSize);
        }
    }

    private void InternalSetImage(Image targetImage, AssetInstanceObject assetObject, string strSpriteName, bool setNativeSize)
    {
        AtlasScriptableObject atlasScriptable = assetObject.Target as AtlasScriptableObject;
        if (atlasScriptable != null)
        {
            Sprite sprite = atlasScriptable.GetSprite(strSpriteName);
            targetImage.sprite = sprite;
            if (setNativeSize)
            {
                targetImage.SetNativeSize();
            }
        }
    }

    private void InternalSetImage(Image targetImage, AssetInstanceObject assetObject, bool setNativeSize)
    {
        if (targetImage==null)
        {
            return;
        }
        Texture2D texture2D = assetObject.Target as Texture2D;
        Sprite sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), Vector2.zero);
        targetImage.sprite = sprite;
        if (setNativeSize)
        {
            targetImage.SetNativeSize();
        }
    }

    private void LoadTpSuccessCallback(string assetName, object asset, float duration, object userData)
    {
        LoadSpriteInfo loadSpriteInfo = (LoadSpriteInfo)userData;
        if (loadSpriteInfo == null)
        {
            throw new GameFrameworkException("Load Sprite info is invalid.");
        }
        AssetInstanceObject assetObject = m_InstancePool.Spawn(assetName);
        if (assetObject?.Target == null)
        {
            if (assetObject!=null)
                m_InstancePool.Unspawn(assetObject);
            assetObject = AssetInstanceObject.Create(assetName, asset);
            m_InstancePool.Register(assetObject, true);
        }
        else
            GameEntry.Resource.UnloadAsset(asset);
        if (loadSpriteInfo.Target == null)
        {
            m_InstancePool.Unspawn(assetObject);
            ReferencePool.Release(loadSpriteInfo);
            GameEntry.Resource.UnloadAsset(asset);
            return;
        }
        if (string.IsNullOrEmpty(loadSpriteInfo.TargetSpriteName))
        {
            InternalSetImage(loadSpriteInfo.Target as Image, assetObject, loadSpriteInfo.SetNativeSize);
        }
        else
        {
            InternalSetImage(loadSpriteInfo.Target as Image, assetObject, loadSpriteInfo.TargetSpriteName, loadSpriteInfo.SetNativeSize);
        }
    }
    private void LoadTpFailureCallback(string assetName, LoadResourceStatus status, string errorMessage, object userData)
    {

    }
    private void LoadTpUpdateCallback(string assetName, float progress, object userData)
    {

    }
    private void LoadTpDependencyAssetCallback(string assetName, string dependencyAssetName, int loadedCount, int totalCount, object userData)
    {

    }
}
