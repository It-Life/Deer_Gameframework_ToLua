using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using LuaInterface;


//NOTE! You should hava a Camera with "MainCamera" tag and a canvas with a Screen Space - Overlay mode to script works properly;

public class HealthBar : MonoBehaviour {

	[ShowInInspector,ReadOnly]
	public float curHealth;
	[ReadOnly]	
	public RectTransform HealthbarPrefab;			//Our health bar prefab;
	public float yOffset;							//Horizontal position offset;
	public bool keepSize = true;	                //keep distance independed size;
	public float scale = 1;							//Scale of the healthbar;
	public Vector2 sizeOffsets;						//Use this to overwright healthbar width and height values;
	public bool DrawOFFDistance;					//Disable health bar if it out of drawDistance;
	public float drawDistance = 10;
	public bool showHealthInfo;						//Show the health info on top of the health bar or not;
	public enum HealthInfoAlignment {top, center, bottom};
	public HealthInfoAlignment healthInfoAlignment = HealthInfoAlignment.center;
	public float healthInfoSize = 10;
    public AlphaSettings alphaSettings;
	private Image healthVolume, backGround;			//Health bar images, should be named as "Health" and "Background";
	private Text healthInfo;						//Health info, a healthbar's child Text object(should be named as HealthInfo);
	private CanvasGroup canvasGroup;
	private Vector2 healthbarPosition, healthbarSize, healthInfoPosition;
	private Transform thisT;
	private float defaultHealth, lastHealth, camDistance, dist, pos, rate;
	private Camera cam;
	private Camera uiCam;
	private GameObject healthbarRoot;
	[HideInInspector]public Canvas canvas;
	private int m_SerialId = 0;
	void Awake()
	{
		Canvas[] canvases = (Canvas[])FindObjectsOfType(typeof(Canvas));
		if (canvases.Length == 0)
			Debug.LogError("There is no Canvas in the scene or Canvas GameObject isn't active, please create one - GameObject->UI->Canvas or activate existing");
		
		for (int i = 0; i < canvases.Length; i++)
		{
			if (canvases[i].enabled && canvases[i].gameObject.activeSelf
				//&& canvases[i].renderMode == RenderMode.ScreenSpaceOverlay
				&& canvases[i].gameObject.name == "HealthbarRoot")
			{
				canvas = canvases[i];
			}
		}
        if (!canvas)
        {
			Debug.LogError("There is no Canvas with RenderMode: ScreenSpace - Overlay in the scene or it's disabled, please create one - GameObject->UI->Canvas or enable existing");
			return;
        }
		healthbarRoot = canvas.gameObject;
		thisT = this.transform;
	}
    public void OnInitialized(string strHealthPrefabPath,int defaultHealth,float sizeDeltaX = 476f,float sizeDeltaY = 54f)
    {
		if (!canvas)
		{
			return;
		}
		yOffset = 2.55f;
		scale = 3;
		sizeOffsets = new Vector2(0,-100);
		showHealthInfo = true;
		InitAlphaSettingsInfo();
		m_SerialId = GameEntry.AssetObject.GenSerialId();
		this.defaultHealth = defaultHealth;
		curHealth = defaultHealth;
		lastHealth = defaultHealth;
		healthbarSize = new Vector2(sizeDeltaX, sizeDeltaY);
		GameEntry.AssetObject.LoadAssetAsync(m_SerialId, strHealthPrefabPath, "HealthBar",delegate(bool result, object gameObject,int serialId) {
			if (result)
			{
				HealthbarPrefab = ((GameObject)gameObject).transform.GetComponent<RectTransform>();
				HealthbarPrefab.gameObject.SetActive(true);
				GameEntry.UI.HealthbarRoot.AddHealthBar(healthbarRoot);
				HealthbarPrefab.position = new Vector2(-1000,-1000);
				HealthbarPrefab.rotation = Quaternion.identity;
				HealthbarPrefab.name = "HealthBar";
				HealthbarPrefab.SetParent(healthbarRoot.transform, false);
				canvasGroup = HealthbarPrefab.GetComponent<CanvasGroup>();

				healthVolume = HealthbarPrefab.transform.Find("Health").GetComponent<Image>();
				backGround = HealthbarPrefab.transform.Find("Background").GetComponent<Image>();
				healthInfo = HealthbarPrefab.transform.Find("HealthInfo").GetComponent<Text>();
				healthInfo.resizeTextForBestFit = true;
				healthInfo.rectTransform.anchoredPosition = Vector2.zero;
				healthInfoPosition = healthInfo.rectTransform.anchoredPosition;
				healthInfo.resizeTextMinSize = 1;
				healthInfo.resizeTextMaxSize = 500;

				canvasGroup.alpha = alphaSettings.fullAplpha;
				canvasGroup.interactable = false;
				canvasGroup.blocksRaycasts = false;
				cam = GameEntry.Camera.MainCamera;
				uiCam = GameEntry.UI.UICamera;
			}
			else 
			{
				Log.Error("加载血条预制体失败");	
			}
		});
	}

	private void InitAlphaSettingsInfo() 
	{
		if (alphaSettings == null)
		{
			alphaSettings = new AlphaSettings();
		}
		alphaSettings.defaultAlpha = 0f;
		alphaSettings.defaultFadeSpeed = 0.1f;
		alphaSettings.fullAplpha = 0f;
		alphaSettings.fullFadeSpeed = 0.1f;
		alphaSettings.nullAlpha = 0f;
		alphaSettings.nullFadeSpeed = 0.1f;
        if (alphaSettings.onHit==null)
        {
			alphaSettings.onHit = new OnHit();
		}
		alphaSettings.onHit.fadeSpeed = 0.1F;
		alphaSettings.onHit.onHitAlpha = 1.0F;
		alphaSettings.onHit.duration = 1.0F;
	}

	public void SetDefaultAlpha(float defaultAlpha, float defaultFadeSpeed)
	{
        if (alphaSettings == null)
        {
			return;
        }
		alphaSettings.defaultAlpha = defaultAlpha;
		alphaSettings.defaultFadeSpeed = defaultFadeSpeed;
	}
	public void SetFullAplpha(float fullAplpha,float fullFadeSpeed)
	{
		if (alphaSettings == null)
		{
			return;
		}
		alphaSettings.fullAplpha = fullAplpha;
		alphaSettings.fullFadeSpeed = fullFadeSpeed;
	}
	public void SetNullAlpha(float nullAlpha, float nullFadeSpeed)
	{
		if (alphaSettings == null)
		{
			return;
		}
		alphaSettings.nullAlpha = nullAlpha;
		alphaSettings.nullFadeSpeed = nullFadeSpeed;
	}
	public void SetAlphaHit(float fadeSpeed, float onHitAlpha,float duration)
	{
		if (alphaSettings == null)
		{
			return;
		}
		if (alphaSettings.onHit == null)
		{
			return;
		}
		alphaSettings.onHit.fadeSpeed = fadeSpeed;
		alphaSettings.onHit.onHitAlpha = onHitAlpha;
		alphaSettings.onHit.duration = duration;
	}
	public void HideHealthbar() 
	{
        if (HealthbarPrefab!=null)
        {
			HealthbarPrefab.gameObject.SetActive(false);
			GameEntry.UI.HealthbarRoot.RemoveHealthBar(HealthbarPrefab.gameObject);
			GameEntry.AssetObject.Unspawn(HealthbarPrefab.gameObject);
		}
	}

    // Update is called once per frame
    void FixedUpdate () {
		if(!HealthbarPrefab)
			return;

		HealthbarPrefab.transform.position = cam.WorldToScreenPoint(new Vector3(thisT.position.x, thisT.position.y + yOffset, thisT.position.z));
/*		Vector3 pos = cam.WorldToViewportPoint(new Vector3(thisT.position.x, thisT.position.y + yOffset, thisT.position.z));
		Vector3 uipos = uiCam.ViewportToWorldPoint(pos);*/
		//HealthbarPrefab.transform.position = uipos;
		healthVolume.fillAmount = curHealth / defaultHealth;

		float maxDifference = 0.1F;

		if(backGround.fillAmount > healthVolume.fillAmount + maxDifference)
			backGround.fillAmount = healthVolume.fillAmount + maxDifference;
        if (backGround.fillAmount > healthVolume.fillAmount)
            backGround.fillAmount -= (1 / (defaultHealth / 100)) * Time.deltaTime;
        else
            backGround.fillAmount = healthVolume.fillAmount;
	}
	
	
	void Update()
	{
		if(!HealthbarPrefab)
			return;
		
		camDistance = Vector3.Dot(thisT.position - cam.transform.position, cam.transform.forward);
		
		if(showHealthInfo)
			healthInfo.text = curHealth + " / "+defaultHealth;
		else
			healthInfo.text = "";

        if(lastHealth != curHealth)
        {
            rate = Time.time + alphaSettings.onHit.duration;
            lastHealth = curHealth;
        }

        if (!OutDistance() && IsVisible())
        {
            if (curHealth <= 0)
            {
                if (alphaSettings.nullFadeSpeed > 0)
                {
                    if (backGround.fillAmount <= 0)
                        canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha, alphaSettings.nullAlpha, alphaSettings.nullFadeSpeed);
                }
                else
                    canvasGroup.alpha = alphaSettings.nullAlpha;
            }
            else if (curHealth == defaultHealth)
                canvasGroup.alpha = alphaSettings.fullFadeSpeed > 0 ? Mathf.MoveTowards(canvasGroup.alpha, alphaSettings.fullAplpha, alphaSettings.fullFadeSpeed) : alphaSettings.fullAplpha;
            else
            {
                if (rate > Time.time)
                    canvasGroup.alpha = alphaSettings.onHit.onHitAlpha;
                else
                    canvasGroup.alpha = alphaSettings.onHit.fadeSpeed > 0 ? Mathf.MoveTowards(canvasGroup.alpha, alphaSettings.defaultAlpha, alphaSettings.onHit.fadeSpeed) : alphaSettings.defaultAlpha;
            }
        }
        else
            canvasGroup.alpha = alphaSettings.defaultFadeSpeed > 0 ? Mathf.MoveTowards(canvasGroup.alpha, 0, alphaSettings.defaultFadeSpeed) : 0;

		
		if(curHealth <= 0)
			curHealth = 0;

		dist = keepSize ? camDistance / scale :  scale;

		HealthbarPrefab.sizeDelta = new Vector2 (healthbarSize.x/(dist-sizeOffsets.x/100), healthbarSize.y/(dist-sizeOffsets.y/100));
		
		healthInfo.rectTransform.sizeDelta = new Vector2 (HealthbarPrefab.sizeDelta.x * healthInfoSize/10, 
		                                                  HealthbarPrefab.sizeDelta.y * healthInfoSize/10);
		
		healthInfoPosition.y = HealthbarPrefab.sizeDelta.y + (healthInfo.rectTransform.sizeDelta.y - HealthbarPrefab.sizeDelta.y) / 2;
		
		if(healthInfoAlignment == HealthInfoAlignment.top)
			healthInfo.rectTransform.anchoredPosition = healthInfoPosition;
		else if (healthInfoAlignment == HealthInfoAlignment.center)
			healthInfo.rectTransform.anchoredPosition = Vector2.zero;
		else
			healthInfo.rectTransform.anchoredPosition = -healthInfoPosition;

        if(curHealth > defaultHealth)
            defaultHealth = curHealth;
	}

	bool IsVisible()
	{
		return canvas.pixelRect.Contains (HealthbarPrefab.position);
	}

    bool OutDistance()
    {
        return DrawOFFDistance == true && camDistance > drawDistance;
    }

    public float GetDefaultHealth()
    {
        return defaultHealth;
    }

    public float GetCurrentHealth()
    {
        return curHealth;
    }
	public void SetCurrentHealth(float curHealth)
	{
		this.curHealth = curHealth;
	}
}

[System.Serializable]
[NoToLua]
public class AlphaSettings
{
    
    public float defaultAlpha = 0.7F;           //Default healthbar alpha (health is bigger then zero and not full);
    public float defaultFadeSpeed = 0.1F;
    public float fullAplpha = 1.0F;             //Healthbar alpha when health is full;
    public float fullFadeSpeed = 0.1F;
    public float nullAlpha = 0.0F;              //Healthbar alpha when health is zero or less;
    public float nullFadeSpeed = 0.1F;
    public OnHit onHit;                         //On hit settings
}

[System.Serializable]
public class OnHit
{
    public float fadeSpeed = 0.1F;              //Alpha state fade speed;
    public float onHitAlpha = 1.0F;             //On hit alpha;
    public float duration = 1.0F;               //Duration of alpha state;
}
