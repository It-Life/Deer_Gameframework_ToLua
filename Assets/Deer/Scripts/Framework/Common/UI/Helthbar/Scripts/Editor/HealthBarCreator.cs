using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class HealthBarCreator : EditorWindow {
	
	Sprite hBar, hValue, hBackground;
	Color hBarCol = Color.white, hValueCol = Color.white, hBackCol = Color.white, fCol = Color.white;
	Font f;
	FontStyle fStyle;
	private const string kUILayerName = "UI";

	[MenuItem("Window/X-BARS/New Healthbar")]	
	static void Init()
	{
		HealthBarCreator cEditor = (HealthBarCreator)EditorWindow.GetWindowWithRect(typeof(HealthBarCreator), new Rect(0,0, 400, 250), false, "X-BARS");
		cEditor.autoRepaintOnSceneChange = true;
	}
	
	void OnGUI()
	{
		EditorGUILayout.BeginVertical ("Box", GUILayout.Width(395), GUILayout.Height(395));
		GUILayout.Space (10);
		hBar = (Sprite)EditorGUILayout.ObjectField ("Health Bar Main Image", hBar, typeof(Sprite), false);
		if(hBar)
			hBarCol = EditorGUILayout.ColorField("Color", hBarCol);

		hValue = (Sprite)EditorGUILayout.ObjectField ("Health Image", hValue, typeof(Sprite), false);
		if(hValue)
			hValueCol = EditorGUILayout.ColorField("Color", hValueCol);

		hBackground = (Sprite)EditorGUILayout.ObjectField ("Health Background", hBackground, typeof(Sprite), false);
		if(hBackground)
			hBackCol = EditorGUILayout.ColorField("Color", hBackCol);
		GUILayout.Space (10);
		f = (Font)EditorGUILayout.ObjectField ("Health Info Font", f, typeof(Font), false);
		if(f)
		{
			fCol = EditorGUILayout.ColorField("Color", fCol);
			fStyle = (FontStyle)EditorGUILayout.EnumPopup("Font Style", fStyle);
		}

		GUILayout.Space (20);
		if(GUILayout.Button("Create", EditorStyles.toolbarButton))
		{
			CreateHealthBar();
		}
		EditorGUILayout.EndVertical ();
	}

	void CreateHealthBar()
	{
		GameObject healthBarPrefab = new GameObject ("HealthBarPrefab", typeof(Image), typeof(CanvasGroup));
		SetCanvas (healthBarPrefab.transform);
		Image Main = healthBarPrefab.GetComponent<Image> ();
		Main.sprite = hBar;
		Main.color = hBarCol;
		Main.SetNativeSize ();

		GameObject backGround = new GameObject ("Background", typeof(Image));
		backGround.transform.SetParent (healthBarPrefab.transform, false);
		Image bGround = backGround.GetComponent<Image>();
		bGround.sprite = hBackground;
		bGround.color = hBackCol;
		bGround.type = Image.Type.Filled;
		bGround.fillMethod = Image.FillMethod.Horizontal;
		bGround.SetNativeSize ();
		SetAnchors (backGround.GetComponent<RectTransform>(), healthBarPrefab.GetComponent<RectTransform>());

		GameObject healthValue = new GameObject ("Health", typeof(Image));
		healthValue.transform.SetParent (healthBarPrefab.transform, false);
		Image health = healthValue.GetComponent<Image>();
		health.sprite = hValue;
		health.color = hValueCol;
		health.type = Image.Type.Filled;
		health.fillMethod = Image.FillMethod.Horizontal;
		health.SetNativeSize ();
		SetAnchors (healthValue.GetComponent<RectTransform>(), healthBarPrefab.GetComponent<RectTransform>());

		GameObject healthInfo = new GameObject ("HealthInfo", typeof(Text));
		healthInfo.GetComponent<Text>().font = f;
		healthInfo.GetComponent<Text>().color = fCol;
		healthInfo.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
		healthInfo.GetComponent<Text>().fontStyle = fStyle;
		healthInfo.transform.SetParent (healthBarPrefab.transform, false);
		healthInfo.GetComponent<RectTransform>().sizeDelta = healthBarPrefab.GetComponent<RectTransform>().sizeDelta;
	}

	static public GameObject CreateNewUI()
	{
		// Root for the UI
		var root = new GameObject("X-Bars Canvas");
		root.layer = LayerMask.NameToLayer(kUILayerName);
		Canvas canvas = root.AddComponent<Canvas>();
		canvas.renderMode = RenderMode.ScreenSpaceOverlay;
		root.AddComponent<CanvasScaler>();
		root.AddComponent<GraphicRaycaster>();
		Undo.RegisterCreatedObjectUndo(root, "Create " + root.name);
		
		// if there is no event system add one...
		CreateEventSystem(false);
		return root;
	}
	
	public static void CreateEventSystem(MenuCommand menuCommand)
	{
		GameObject parent = menuCommand.context as GameObject;
		CreateEventSystem(true, parent);
	}
	
	private static void CreateEventSystem(bool select)
	{
		CreateEventSystem(select, null);
	}
	
	private static void CreateEventSystem(bool select, GameObject parent)
	{
		var esys = Object.FindObjectOfType<EventSystem>();
		if (esys == null)
		{
			var eventSystem = new GameObject("EventSystem");
			GameObjectUtility.SetParentAndAlign(eventSystem, parent);
			esys = eventSystem.AddComponent<EventSystem>();
			eventSystem.AddComponent<StandaloneInputModule>();
			eventSystem.AddComponent<TouchInputModule>();
			
			Undo.RegisterCreatedObjectUndo(eventSystem, "Create " + eventSystem.name);
		}
		
		if (select && esys != null)
		{
			Selection.activeGameObject = esys.gameObject;
		}
	}
	
	public static void SetCanvas(Transform thisTransform)
	{
		Canvas[] canvases = (Canvas[])GameObject.FindObjectsOfType(typeof(Canvas));
		
		if(canvases.Length > 0)
		{
			for (int i = 0; i < canvases.Length; i++)
			{
				if(canvases[i].enabled && canvases[i].renderMode == RenderMode.ScreenSpaceOverlay)
					thisTransform.SetParent (canvases[i].transform, false);
				else
				{
					GameObject canvas = CreateNewUI();
					thisTransform.SetParent(canvas.transform, false);
				}
			}
		}
		else
		{
			GameObject canvas = CreateNewUI();
			thisTransform.SetParent(canvas.transform, false);
		}
	}

	void SetAnchors(RectTransform thisRectTransform, RectTransform parentRectTransform)
	{
		if(thisRectTransform == null || parentRectTransform == null) return;

		Vector2 newAnchorsMin = new Vector2(thisRectTransform.anchorMin.x + thisRectTransform.offsetMin.x / parentRectTransform.rect.width,
		                                    thisRectTransform.anchorMin.y + thisRectTransform.offsetMin.y / parentRectTransform.rect.height);
		Vector2 newAnchorsMax = new Vector2(thisRectTransform.anchorMax.x + thisRectTransform.offsetMax.x / parentRectTransform.rect.width,
		                                    thisRectTransform.anchorMax.y + thisRectTransform.offsetMax.y / parentRectTransform.rect.height);
		thisRectTransform.anchorMin = newAnchorsMin;
		thisRectTransform.anchorMax = newAnchorsMax;
		thisRectTransform.offsetMin = thisRectTransform.offsetMax = new Vector2(0, 0);
	}















}
