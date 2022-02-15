// ================================================
//描 述 :  
//作 者 : 杜鑫 
//创建时间 : 2021-08-12 00-05-17  
//修改作者 : 杜鑫 
//修改时间 : 2021-08-12 00-05-17  
//版 本 : 0.1 
// ===============================================
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Deer.Editor
{
    public class OverrideUIComponent
    {
        [MenuItem("GameObject/UI/Text",false,20)]
        [MenuItem("GameObject/UI/Text - TextMeshPro",false,21)]
        static TextMeshProUGUI CreateText()
        {
            var text = CreateComponent<TextMeshProUGUI>("Text");
            text.raycastTarget = false;
            text.font = AssetDatabase.LoadAssetAtPath<TMP_FontAsset>("Assets/Deer/Asset/Font/wryh SDF.asset"); // 默认字体  
            text.color = Color.black;
            return text;
        }

        [MenuItem("GameObject/UI/Image",false,30 )]
        static Image CreateImage()
        {
            var image = CreateComponent<Image>("Image");
            image.sprite = AssetDatabase.LoadAssetAtPath<Sprite>(DefaultTextureName<Image>());
            image.raycastTarget = false;
            image.maskable = false;
            return image;
        }

        [MenuItem("GameObject/UI/Raw Image",false,31)]
        static RawImage CreateRawImage()
        {
            var image = CreateComponent<RawImage>("Raw Image");
            image.texture = AssetDatabase.LoadAssetAtPath<Texture>(DefaultTextureName<RawImage>());
            image.raycastTarget = false;
            image.maskable = false;
            return image;
        }

        [MenuItem("GameObject/UI/Button",false,60)]
        [MenuItem("GameObject/UI/Button - TextMeshPro",false,61)]
        static UIButtonSuper CreateButton()
        {
            //设置一个文本
            Transform textRrans;
            var image = CreateComponent<Image>("Button");
            image.sprite = AssetDatabase.LoadAssetAtPath<Sprite>(DefaultTextureName<UIButtonSuper>());
            image.raycastTarget = true;
            image.maskable = false;
            image.GetComponent<RectTransform>().sizeDelta = new Vector2(180, 60);
            var text = CreateText();
            text.text = "Button";
            text.horizontalAlignment = HorizontalAlignmentOptions.Center;
            text.verticalAlignment = VerticalAlignmentOptions.Middle;
            (textRrans = text.transform).SetParent(image.transform);
            textRrans.localPosition = Vector3.zero;
            textRrans.localScale = Vector3.one;
            var textRectTrans = text.GetComponent<RectTransform>();
            textRectTrans.anchorMin = new Vector2(0, 0);
            textRectTrans.anchorMax = new Vector2(1, 1);
            textRectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 160);
            textRectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 40);
            var uiButton = image.gameObject.GetOrAddComponent<UIButtonSuper>();
            Selection.activeGameObject = uiButton.gameObject;
            return uiButton;
        }
        [MenuItem("GameObject/UI/U_SpriteAnimation",false,2 )]
        static Image CreateUGUISpriteAnimation()
        {
            var image = CreateComponent<Image>("Image");
            image.sprite = AssetDatabase.LoadAssetAtPath<Sprite>(DefaultTextureName<Image>());
            image.raycastTarget = false;
            image.maskable = false;
            image.gameObject.AddComponent<UGUISpriteAnimation>();
            return image;
        }

        /// <summary>
        /// 创建ui组件
        /// </summary>
        /// <param name="defaultName"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private static T CreateComponent<T>(string defaultName) where T : UIBehaviour
        {
            GameObject canvasObj = SecurityCheck();
            GameObject go = new GameObject(defaultName, typeof(T));
            if (!Selection.activeTransform)
            {
                go.transform.SetParent(canvasObj.transform);
            }
            else
            {
                if (!Selection.activeTransform.GetComponentInParent<Canvas>()) // 没有在UI树下  
                {
                    go.transform.SetParent(canvasObj.transform);
                }
                else
                {
                    go.transform.SetParent(Selection.activeTransform);
                }
            }

            go.transform.localScale = Vector3.one;
            go.transform.localPosition = Vector3.zero;
            Selection.activeGameObject = go;
            return go.GetComponent<T>();
        }

        // 如果第一次创建UI元素 可能没有 Canvas、EventSystem对象！  
        private static GameObject SecurityCheck()
        {
            GameObject canvas;
            var cc = Object.FindObjectOfType<Canvas>();
            if (!cc)
            {
                canvas = new GameObject("Canvas", typeof(Canvas));
            }
            else
            {
                canvas = cc.gameObject;
            }

            if (!Object.FindObjectOfType<EventSystem>())
            {
                GameObject eventSystem = new GameObject("EventSystem", typeof(EventSystem));
            }

            return canvas;
        }

        private static string DefaultTextureName<T>()where T : UIBehaviour
        {
            if (typeof(T) == typeof(Image))
            {
                
            }else if (typeof(T) == typeof(RawImage))
            {
                
            }else if (typeof(T) == typeof(UIButtonSuper))
            {
                
            }
            return string.Empty;
        }

    }
}