﻿#define USING_DOTWEENING

using UnityEngine;
using System;
using System.Collections.Generic;
using LuaInterface;
using UnityEditor;

using BindType = ToLuaMenu.BindType;
using System.Reflection;
using Cinemachine;
using Deer;
using UnityGameFramework.Runtime;
using GameFramework.Resource;
using UnityEngine.UI;
using Deer.Enum;
using SuperScrollView;
using TMPro;
using UnityEngine.Events;
using zFrame.UI;
using static zFrame.UI.Joystick;

public static class CustomSettings
{
    public static string saveDir = Application.dataPath + "/ToLua/Source/Generate/";    
    public static string toluaBaseType = Application.dataPath + "/ToLua/BaseType/";
    public static string baseLuaDir = Application.dataPath + "/ToLua/Lua/";
    public static string injectionFilesPath = Application.dataPath + "/ToLua/Injection/";

    //lua print或者error重定向
    public const int PRINTLOGLINE = 208;                //ToLua.Print函数中Debugger.Log位置
    public const int PCALLERRORLINE = 810;              //LuaState.Pcall函数中throw位置
    public const int LUADLLERRORLINE = 803;             //LuaDLL.luaL_argerror函数中throw位置

    public const string LUAJIT_CMD_OPTION = "-b -g";    //luajit.exe 编译命令行参数
    //导出时强制做为静态类的类型(注意customTypeList 还要添加这个类型才能导出)
    //unity 有些类作为sealed class, 其实完全等价于静态类
    public static List<Type> staticClassTypes = new List<Type>
    {        
        typeof(UnityEngine.Application),
        typeof(UnityEngine.Time),
        typeof(UnityEngine.Screen),
        typeof(UnityEngine.SleepTimeout),
        typeof(UnityEngine.Input),
        typeof(UnityEngine.Resources),
        typeof(UnityEngine.Physics),
        typeof(UnityEngine.RenderSettings),
        typeof(UnityEngine.QualitySettings),
        typeof(UnityEngine.GL),
        typeof(UnityEngine.Graphics),
    };

    //附加导出委托类型(在导出委托时, customTypeList 中牵扯的委托类型都会导出， 无需写在这里)
    public static DelegateType[] customDelegateList = 
    {        
        _DT(typeof(Action)),                
        _DT(typeof(UnityEngine.Events.UnityAction)),
        _DT(typeof(System.Predicate<int>)),
        _DT(typeof(System.Action<int>)),
        _DT(typeof(System.Comparison<int>)),
        _DT(typeof(System.Func<int, int>)),

        //GameFramewoek
        _DT(typeof(LoadAssetSuccessCallback)),
        _DT(typeof(LoadAssetFailureCallback)),
        _DT(typeof(LoadAssetUpdateCallback)),
        _DT(typeof(LoadAssetDependencyAssetCallback)),

    };

    //在这里添加你要导出注册到lua的类型列表
    public static BindType[] customTypeList =
    {                
        _GT(typeof(LuaInjectionStation)),
        _GT(typeof(InjectType)),
        _GT(typeof(Debugger)).SetNameSpace(null),          

#if USING_DOTWEENING
        _GT(typeof(DG.Tweening.DOTween)),
        _GT(typeof(DG.Tweening.Tween)).SetBaseType(typeof(System.Object)).AddExtendType(typeof(DG.Tweening.TweenExtensions)),
        _GT(typeof(DG.Tweening.Sequence)).AddExtendType(typeof(DG.Tweening.TweenSettingsExtensions)),
        _GT(typeof(DG.Tweening.Tweener)).AddExtendType(typeof(DG.Tweening.TweenSettingsExtensions)),
        _GT(typeof(DG.Tweening.LoopType)),
        _GT(typeof(DG.Tweening.PathMode)),
        _GT(typeof(DG.Tweening.PathType)),
        _GT(typeof(DG.Tweening.RotateMode)),
        _GT(typeof(Component)).AddExtendType(typeof(DG.Tweening.ShortcutExtensions)),
        _GT(typeof(Transform)).AddExtendType(typeof(DG.Tweening.ShortcutExtensions)),
        _GT(typeof(Light)).AddExtendType(typeof(DG.Tweening.ShortcutExtensions)),
        _GT(typeof(Material)).AddExtendType(typeof(DG.Tweening.ShortcutExtensions)),
        _GT(typeof(Rigidbody)).AddExtendType(typeof(DG.Tweening.ShortcutExtensions)),
        _GT(typeof(Camera)).AddExtendType(typeof(DG.Tweening.ShortcutExtensions)),
        _GT(typeof(AudioSource)).AddExtendType(typeof(DG.Tweening.ShortcutExtensions)),
        //_GT(typeof(LineRenderer)).AddExtendType(typeof(DG.Tweening.ShortcutExtensions)),
        //_GT(typeof(TrailRenderer)).AddExtendType(typeof(DG.Tweening.ShortcutExtensions)),    
#else

        _GT(typeof(Component)),
        _GT(typeof(Transform)),
        _GT(typeof(Material)),
        _GT(typeof(Light)),
        _GT(typeof(Rigidbody)),
        _GT(typeof(Camera)),
        _GT(typeof(AudioSource)),
        //_GT(typeof(LineRenderer))
        //_GT(typeof(TrailRenderer))
#endif
        _GT(typeof(Canvas)).SetNameSpace(null),
        _GT(typeof(CanvasGroup)).SetNameSpace(null),
        _GT(typeof(CanvasRenderer)).SetNameSpace(null),
        _GT(typeof(CanvasScaler)).SetNameSpace(null),
        _GT(typeof(GraphicRaycaster)).SetNameSpace(null),
        _GT(typeof(RectTransform)).SetNameSpace(null),
        //UnityEngine.UI
        _GT(typeof(Image)).AddExtendType(typeof(SetSpriteExtensions)).SetNameSpace(null),
        _GT(typeof(RawImage)).SetNameSpace(null),
        _GT(typeof(TextMeshProUGUI)).SetNameSpace(null),
        _GT(typeof(Text)).SetNameSpace(null),
        _GT(typeof(Slider)).SetNameSpace(null),
        _GT(typeof(Toggle)).SetNameSpace(null),
        _GT(typeof(InputField)).SetNameSpace(null),
        _GT(typeof(Dropdown)).SetNameSpace(null),
        _GT(typeof(Scrollbar)).SetNameSpace(null),
        _GT(typeof(ScrollRect)).SetNameSpace(null),
        _GT(typeof(UGUISpriteAnimation)).SetNameSpace(null),
        _GT(typeof(UIButtonSuper)).SetNameSpace(null),

        _GT(typeof(UnityEvent)),
        _GT(typeof(Behaviour)),
        _GT(typeof(MonoBehaviour)),  
        _GT(typeof(GameObject)),
        _GT(typeof(TrackedReference)),
        _GT(typeof(Application)),
        _GT(typeof(Physics)),
        _GT(typeof(Collider)),
        _GT(typeof(Time)),        
        _GT(typeof(Texture)).AddExtendType(typeof(SetTextureExtensions)).SetNameSpace(null),
        _GT(typeof(Texture2D)),
        _GT(typeof(Shader)),        
        _GT(typeof(Renderer)),
        //_GT(typeof(WWW)),
        _GT(typeof(Screen)),        
        _GT(typeof(CameraClearFlags)),
        _GT(typeof(AudioClip)),        
        _GT(typeof(AssetBundle)),
        //_GT(typeof(ParticleSystem)),
        _GT(typeof(AsyncOperation)).SetBaseType(typeof(System.Object)),        
        _GT(typeof(LightType)),
        _GT(typeof(SleepTimeout)),
#if UNITY_5_3_OR_NEWER && !UNITY_5_6_OR_NEWER
        _GT(typeof(UnityEngine.Experimental.Director.DirectorPlayer)),
#endif
        _GT(typeof(Animator)),
        _GT(typeof(AnimatorStateInfo)),
        _GT(typeof(Input)).SetNameSpace(null),
        _GT(typeof(KeyCode)).SetNameSpace(null),
        _GT(typeof(SkinnedMeshRenderer)).SetNameSpace(null),
        _GT(typeof(Space)).SetNameSpace(null),      
       

        //_GT(typeof(MeshRenderer)),
#if !UNITY_5_4_OR_NEWER
        _GT(typeof(ParticleEmitter)),
        _GT(typeof(ParticleRenderer)),
        _GT(typeof(ParticleAnimator)), 
#endif

        _GT(typeof(BoxCollider)),
        _GT(typeof(MeshCollider)),
        _GT(typeof(SphereCollider)),        
        _GT(typeof(CharacterController)),
        _GT(typeof(CapsuleCollider)),
        
        _GT(typeof(Animation)),        
        _GT(typeof(AnimationClip)).SetBaseType(typeof(UnityEngine.Object)),        
        _GT(typeof(AnimationState)),
        _GT(typeof(AnimationBlendMode)),
        _GT(typeof(QueueMode)),  
        _GT(typeof(PlayMode)),
        _GT(typeof(WrapMode)),

        _GT(typeof(QualitySettings)),
        _GT(typeof(RenderSettings)),                                                   
        _GT(typeof(SkinWeights)),           
        _GT(typeof(RenderTexture)),
        _GT(typeof(Resources)),
        _GT(typeof(Color)),
        _GT(typeof(Color32)),

        _GT(typeof(LuaProfiler)),

        _GT(typeof(PlayerPrefs)).SetWrapName(null),
        //GameFramework
        _GT(typeof(GameEntry)).SetNameSpace(null),
        _GT(typeof(Constant.AssetPriority)).SetNameSpace(null),

        _GT(typeof(ProcedureComponent)).SetNameSpace(null),
        _GT(typeof(ResourceComponent)).SetNameSpace(null),
        _GT(typeof(LoadAssetCallbacks)).SetNameSpace(null),
        
        _GT(typeof(EventComponent)).SetNameSpace(null),
        _GT(typeof(SceneComponent)).AddExtendType(typeof(SceneComponentExtension)).SetNameSpace(null),
        _GT(typeof(LoadSceneSuccessEventArgs)).SetNameSpace(null),
        _GT(typeof(LoadSceneFailureEventArgs)).SetNameSpace(null),
        _GT(typeof(LoadSceneUpdateEventArgs)).SetNameSpace(null),
        _GT(typeof(LoadSceneDependencyAssetEventArgs)).SetNameSpace(null),
        _GT(typeof(UnloadSceneSuccessEventArgs)).SetNameSpace(null),
        _GT(typeof(UnloadSceneFailureEventArgs)).SetNameSpace(null),

        _GT(typeof(WebRequestComponent)).SetNameSpace(null),
        _GT(typeof(WebRequestSuccessEventArgs)).SetNameSpace(null),
        _GT(typeof(WebRequestFailureEventArgs)).SetNameSpace(null),
        _GT(typeof(WebRequestStartEventArgs)).SetNameSpace(null),

        _GT(typeof(SoundComponent)).AddExtendType(typeof(SoundComponentExtension)).SetNameSpace(null),
        
        _GT(typeof(ObjectPoolComponent)).SetNameSpace(null),
        
        _GT(typeof(EntityComponent)).AddExtendType(typeof(EntityComponentExtension)).SetNameSpace(null),
        _GT(typeof(EntityLogicBase)).SetNameSpace(null),

        _GT(typeof(LuaComponent)).SetNameSpace(null),
        _GT(typeof(DeerUIComponent)).SetNameSpace(null),
        _GT(typeof(MessengerComponent)).SetNameSpace(null),
        _GT(typeof(MessengerInfo)).SetNameSpace(null),
        _GT(typeof(EventName)).SetNameSpace(null),

        _GT(typeof(NetConnectorComponent)).SetNameSpace(null),
        
        _GT(typeof(CameraComponent)).SetNameSpace(null),
        _GT(typeof(CinemachineVirtualCamera)).SetNameSpace(null),
        
        _GT(typeof(GameSettingsComponent)).SetNameSpace(null),
        _GT(typeof(LogEnum)).SetNameSpace(null),
        _GT(typeof(Character)).SetNameSpace(null),
        
        //Deer
        _GT(typeof(ProcedureChangeLua)).SetNameSpace(null),
        _GT(typeof(Log)),
        _GT(typeof(ColorType)),
        _GT(typeof(ComponentBinder)).SetNameSpace(null),
        _GT(typeof(FileUtils)).SetNameSpace(null),
        
        //SuperView
        _GT(typeof(LoopListView2)).SetNameSpace(null),
        _GT(typeof(LoopListViewItem2)).SetNameSpace(null),
        _GT(typeof(LoopListViewInitParam)).SetNameSpace(null),
        _GT(typeof(LoopGridView)).SetNameSpace(null),
        _GT(typeof(LoopGridViewItem)).SetNameSpace(null),
        _GT(typeof(LoopGridViewSettingParam)).SetNameSpace(null),
        
        
#region Joystick
        _GT(typeof(Joystick)).SetNameSpace(null),
        _GT(typeof(JoystickEvent)).SetNameSpace(null),
#endregion
    };

    public static List<Type> dynamicList = new List<Type>()
    {
        typeof(MeshRenderer),
#if !UNITY_5_4_OR_NEWER
        typeof(ParticleEmitter),
        typeof(ParticleRenderer),
        typeof(ParticleAnimator),
#endif

        typeof(BoxCollider),
        typeof(MeshCollider),
        typeof(SphereCollider),
        typeof(CharacterController),
        typeof(CapsuleCollider),

        typeof(Animation),
        typeof(AnimationClip),
        typeof(AnimationState),

        typeof(SkinWeights),
        typeof(RenderTexture),
        typeof(Rigidbody),
    };

    //重载函数，相同参数个数，相同位置out参数匹配出问题时, 需要强制匹配解决
    //使用方法参见例子14
    public static List<Type> outList = new List<Type>()
    {
        
    };
        
    //ngui优化，下面的类没有派生类，可以作为sealed class
    public static List<Type> sealedList = new List<Type>()
    {
        /*typeof(Transform),
        typeof(UIRoot),
        typeof(UICamera),
        typeof(UIViewport),
        typeof(UIPanel),
        typeof(UILabel),
        typeof(UIAnchor),
        typeof(UIAtlas),
        typeof(UIFont),
        typeof(UITexture),
        typeof(UISprite),
        typeof(UIGrid),
        typeof(UITable),
        typeof(UIWrapGrid),
        typeof(UIInput),
        typeof(UIScrollView),
        typeof(UIEventListener),
        typeof(UIScrollBar),
        typeof(UICenterOnChild),
        typeof(UIScrollView),        
        typeof(UIButton),
        typeof(UITextList),
        typeof(UIPlayTween),
        typeof(UIDragScrollView),
        typeof(UISpriteAnimation),
        typeof(UIWrapContent),
        typeof(TweenWidth),
        typeof(TweenAlpha),
        typeof(TweenColor),
        typeof(TweenRotation),
        typeof(TweenPosition),
        typeof(TweenScale),
        typeof(TweenHeight),
        typeof(TypewriterEffect),
        typeof(UIToggle),
        typeof(Localization),*/
    };

    public static BindType _GT(Type t)
    {
        return new BindType(t);
    }

    public static DelegateType _DT(Type t)
    {
        return new DelegateType(t);
    }    


    [MenuItem("Lua/Attach Profiler", false, 151)]
    static void AttachProfiler()
    {
        if (!Application.isPlaying)
        {
            EditorUtility.DisplayDialog("警告", "请在运行时执行此功能", "确定");
            return;
        }

        LuaClient.Instance.AttachProfiler();
    }

    [MenuItem("Lua/Detach Profiler", false, 152)]
    static void DetachProfiler()
    {
        if (!Application.isPlaying)
        {            
            return;
        }

        LuaClient.Instance.DetachProfiler();
    }
}
