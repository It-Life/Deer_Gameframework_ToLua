// ================================================
//描 述 :  
//作 者 : 杜鑫 
//创建时间 : 2021-07-10 12-12-48  
//修改作者 : 杜鑫 
//修改时间 : 2021-07-10 12-12-48  
//版 本 : 0.1 
// ===============================================
using System.Collections;
using LuaInterface;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.UI;
[NoToLua]
[CustomEditor(typeof(UIButtonSuper),true)]
[CanEditMultipleObjects]
public class UIButtonSuperEditor : ButtonEditor
{
    private SerializedProperty m_CanClick;
    private SerializedProperty m_CanDoubleClick;
    private SerializedProperty m_DoubleClickIntervalTime;
    private SerializedProperty onDoubleClick;
    
    private SerializedProperty m_CanLongPress;
    private SerializedProperty m_ResponseOnceByPress;
    private SerializedProperty m_LongPressDurationTime;
    private SerializedProperty onPress;
    protected override void OnEnable()
    {
        base.OnEnable();
        
        m_CanClick = serializedObject.FindProperty("m_CanClick");
        m_CanDoubleClick = serializedObject.FindProperty("m_CanDoubleClick");
        m_DoubleClickIntervalTime = serializedObject.FindProperty("m_DoubleClickIntervalTime");
        onDoubleClick = serializedObject.FindProperty("onDoubleClick");
        
        m_CanLongPress = serializedObject.FindProperty("m_CanLongPress");
        m_ResponseOnceByPress = serializedObject.FindProperty("m_ResponseOnceByPress");
        m_LongPressDurationTime = serializedObject.FindProperty("m_LongPressDurationTime");
        onPress = serializedObject.FindProperty("onPress");
    }
    [NoToLua]
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        serializedObject.Update();
        EditorGUILayout.PropertyField(m_CanClick);//显示我们创建的属性
        EditorGUILayout.Space();//空行
        EditorGUILayout.PropertyField(m_CanDoubleClick);//显示我们创建的属性
        EditorGUILayout.PropertyField(m_DoubleClickIntervalTime);//显示我们创建的属性
        EditorGUILayout.PropertyField(onDoubleClick);//显示我们创建的属性
        EditorGUILayout.Space();//空行
        EditorGUILayout.PropertyField(m_CanLongPress);//显示我们创建的属性
        EditorGUILayout.PropertyField(m_ResponseOnceByPress);//显示我们创建的属性
        EditorGUILayout.PropertyField(m_LongPressDurationTime);//显示我们创建的属性
        EditorGUILayout.PropertyField(onPress);//显示我们创建的属性
        serializedObject.ApplyModifiedProperties();
    }
}

#endif

public class UIButtonSuper : Button
{
    [Tooltip("是否可以点击")]
    public bool m_CanClick = true;
    [Tooltip("是否可以双击")]
    public bool m_CanDoubleClick = false;
    [Tooltip("双击间隔时长")]
    public float m_DoubleClickIntervalTime = 0.5f;
    [Tooltip("双击事件")]
    public ButtonClickedEvent onDoubleClick;
    [Tooltip("是否可以长按")]
    public bool m_CanLongPress = false;
    [Tooltip("长按是否只响应一次")]
    public bool m_ResponseOnceByPress = false;
    [Tooltip("长按满足间隔")]
    public float m_LongPressDurationTime = 1;
    [Tooltip("长按事件")]
    public ButtonClickedEvent onPress;
    //public ButtonClickedEvent onClick;
 
    private bool isDown = false;
    private bool isPress = false;
    private float downTime = 0;
 
    private float clickIntervalTime = 0;
    private int clickTimes = 0;
    void Update() {
        if (isDown) {
            if (!m_CanLongPress)
            {
                return;
            }
            if (m_ResponseOnceByPress && isPress) {
                return;
            }
            downTime += Time.deltaTime;
            if (downTime > m_LongPressDurationTime) {
                isPress = true;
                onPress.Invoke();
            }
        }
        if (clickTimes >= 1) {
            clickIntervalTime += Time.deltaTime;
            if (clickIntervalTime >= m_DoubleClickIntervalTime) {
                if (clickTimes >= 2) {
                    if (m_CanDoubleClick)
                    {
                        onDoubleClick.Invoke();
                    }
                }
                else {
                    if (m_CanClick)
                    {
                        onClick.Invoke();
                    }
                }
                clickTimes = 0;
                clickIntervalTime = 0;
            }
        }
    }
 
    public override void OnPointerDown(PointerEventData eventData) {
        base.OnPointerDown(eventData);
        isDown = true;
        downTime = 0;
    }
 
    public override void OnPointerUp(PointerEventData eventData) {
        base.OnPointerUp(eventData);
        isDown = false;
    }
 
    public override void OnPointerExit(PointerEventData eventData) {
        base.OnPointerExit(eventData);
        isDown = false;
        isPress = false;
    }
 
    public override void OnPointerClick(PointerEventData eventData) {
        if (!isPress ) {
            clickTimes += 1;
        }
        else
            isPress = false;
    }
}