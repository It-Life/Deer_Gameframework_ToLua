﻿# **框架说明**


````
框架使用开源的GameFramework
集成toLua原生
UI框架使用的是UGUI
图集使用TexturePacker打图集
````

````
一、命名规范
    1、类命名：帕斯卡命名法：单词首字母大写，如：GetInstance
    2、函数命名：同类名
    3、基础变量名：沿用C#习惯，驼峰命名法，单词首字母小写，后面单词首字母大写，都要加前缀，
       以表示这个变量是什么类型比如，intCount, listMember
    4、私有变量命名：基础变量名,单词最前面加上m_ 如：self.m_intCount, self.m_listCount;
    5、公有变量命名：基础变量名,单词最前面加上g_ 如：self.g_listAction
    6、局部变量命名：基础变量名,单词最前面加上_ 如：local _listAction
    7、参数名命名：基础变量名
    8、任何情况下不应该由外部访问的成员，使用双下划线打头，如：析构函数__init，内部成员self.__callback
    9、所有UI脚本以UI打头，即UIxxxx
    10、系统功能扩展函数：全部使用小写，不用下划线，如对table的扩展：table.walksort
    11、所有协程函数体以"Co"打头，如：CoAsyncLoad，表示该函数必须运行在协程中，并且可以使用任意协程相关函数
    12、所有Unity Object均使用全局函数GObjUtils.IsNull判空===>***很重要
    13、由于脚本语言没有跳转功能，最好在UI组件实例的名字前标识组件类型，提高可读性：
        unity类型
        a）gameObject：gobjXXX
        b）component：compXXX
        c）transform：transXXX
        UI 组件类型
        a）根节点（UIRoot）：XXXRoot
        b）摄像机（UICamera）：XXXCamera
        c）文本（UIText）：XXXText
        d）列表（UILabel）：XXXLab
        e）锚点（UIAnchor）：XXXAnchor
        f）图集（UIAtlas）：XXXAtlas
        g）字体（UIFont）：XXXFont
        h）精灵图片（UISprite）：XXXSpr
        i）网格（UIGrid）：XXXGrid
        j）表格（UITable）：XXXTab
        k）输入（UIInput）：XXXInput
        l）滑动框（ScrollView）：XXXScrollV
        m）按钮（Button）：XXXBtn
        n）位移（TweenPosition）：XXXTweenP
        数据类型
        a）int： nXXX
        b）float： flXXX
        c）double： dlXXX
        d）string： strXXX
        e）bool：bXXX
        f）table：tbXXX
        g）list：listXXX        
        h）int64： n64XXX
        i）long： lXXX
        j）unsign long： ulXXX
        k）unsign int： uXXX
        l）unsign int64： u64XXX
    14、场景规范（含UI）：
    	(1)Drawcall：均值<200,峰值<300 (2)SetPasscall：均值<120,峰值<150
		(3)Overdraw：均值<3x,峰值<4X
		(4)面数：
			①总面数：高端<35W,中端<25W,低端<15W
			②场景：高端<20W,中端<10W,低端<8W
			③角色：高端<8k,中端<5k,低端<3k
（以上指标仅供参考，实际上根据游戏类型的不同,模型侧重点也不同，应该权衡各个模型面数，可根据①总面数指标和场景同屏需求设定侧重点。）
		(5)内存:
			①总内存：小型游戏<500MB 大型游戏<800MB
			①Mono堆：小型游戏<50MB 大型游戏<150MB
			②纹理：小型游戏<150MB 大型游戏<400MB
			③网格：<50MB
			④动画：<30M
			⑤音频：<20MB
````

````
二、代码规范
1.使用引用池:避免频繁new object，尽可能缓存起来或者使用ReferencePool.Acquire<>(),减少垃圾回收频率。C#中所有的类都直接或间接继承自System.Object类，内存分配于托管堆中，由GC负责垃圾回收，GC是一种高耗性能的操作，同一帧中大量GC可能导致游戏卡顿，框架中已实现了引用池，所有继承IReference接口的类，可通过引用池重复利用，注意每次使用完后需手动回收引用对象。同时需要在Debugger的ReferencePool查看是否已经成功回收，避免使用不当引内存泄漏。
2.简短函数方法：使用函数方法尽量简单。长篇大段的函数实现会使我们的视觉疲劳，撰写过长的代码使代码分析难度加大，修复bug和代码的维护成本也增大，撰写短小代码可让JIT编译器能够更好地平摊编译的代价，也更适合内联。
3.Mono空函数删除：空Update()、Start()等生命周期函数需要删除，即使是空的也存在不必要的性能消耗。Unity在编译时候会根据Mono中相关函数名，将相关的函数指针添加到生命周期委托当中，从而导致该函数在生命周期当中被不必要的调用。
4.减少字符串拼接：减少字符串拼接，大量拼接字符串使用StringBuilder。
5.避免强转：使用is进行判断或者as对类型进行安全转换。
6.抽象类和接口规范：接口是一种契约式的设计方式，接口中仅包含方法不包含数据。抽象基类则为一组相关的类型提供了一个共同的基本实现抽象。也就是说抽象基类描述了对象是什么，而接口描述了对象将如何表现其行为。
7.委托实现回调:当类之间有通信的需要，并且我们期望一种比接口所提供的更为松散的耦合机制时，委托便是最佳的选择。
````

```
三：框架使用规范

```

```
四：优化指南：
1.拆分prefab：避免生成过于复杂的prefab，如果prefab中元素过多尝试切分prefab。Unity中prefab过于复杂在加载过程中容易阻塞主线程，导致短时间假死现象。应该尽量减小prefab的复杂度，个别能够复用的元素尽量复用。可尝拆分prefab分帧或切换状态后异步加载子类prefab。
2.使用对象池：避免频繁Instantiate和Destroy对象，对于频繁实例化和销毁的对象应该使用ObjectPool将对象复用起来。当前场景状态切换时再回收全部对象，然后调用ReleaseAllUnused()方法释放全部对象。
3.UI动静分离：动态UI会造成网格重构，网格重构也是一种高耗性能的操作，建议将UI以Canvas划分拆分为动态UI和静态UI，甚至复杂的UI可拆分为好几个Canvas。注意增加Canvas会导致Drawcall增加，虽然现在手机性能的提升几个Drawcall对于手机影响变小，但是尽量还是控制好Canvas不要超过10个。
4.UI切分：如果图集中存在较长UI元素，例如：161200的图片，添加到图集将会使用图集扩充到10242048，可将图片切割分为2张16*600图等，尽可能充分利用图集的剩余空间。
5.图集整合：除去UI打包图集外，例如花草、岩石、墙壁等存在多套纹理，且不需要太高分辨率的纹理可尝试合并到图集，从而尽可能降低dc。
6.UI整合大图：UI展示大图元素比较多无法打到一张1024*1024图集中，考虑将元素合并到一张背景大图中。例如：活动、充值界面，存在许多大图展示，可考虑让美术将大图元素整合到一张背景大图中。
7.OverDraw：半透明物体会导致过度重绘，当打开多级界面，若界面被完全覆盖,可将被覆盖界面隐藏，防止OverDraw性能损耗，同时若仅仅存在UI界面无需渲染场景的状况，可关闭场景相机，减少性能损耗。
8.填充率(fill rate) ：是指显卡每帧或者说每秒能够渲染的像素数。不同的GPU对于处理像素数的速度是不同的，对于一些低端机型可适当考虑减少分辨率，减少像素数处理的量，同时因为半透明物体会导致重复绘制，参考7.Overdraw。
9.UI网格重构：//动态UI会导致UI的网格重构
10.Animator设计：Animator应当简单明了，避免复杂的网状结构，尽量设计成可通过程序状态机能够快速切换的形式。
11.常用颜色应该规范建立色值表，常用文字或公共UI图等应当通过色值表匹配当前适用的颜色。
12.原则上UI图片资源应该关闭Mipmap、Read\Write Enable等选项，减少内存消耗。
13.减少透明贴图:减少透明贴图得使用，部分图集使用RBG格式，某些不需要A通道的图片可合并到一个仅有RBG的公共图集中。
14.减少阴影消耗：大量对象实时阴影消耗很大，单角色少量角色或小范围场景能可使用RenderTexture模拟阴影，静态物体考虑烘焙阴影方式，动态考虑面片做假阴影，适当时候真假混合。
15.缓存哈希值：部分运行时生成的哈希值，需要频繁获取时候可预先缓存结果，示例：
private readonly static int m_PropertyToIDColor = Shader.PropertyToID("_Color");//获取shader属性id
public static readonly int EventId = typeof(TestDataEventArgs).GetHashCode();//运行时生成GF事件id
16.动态合批：Unity提供了动态合批方案，动态合批的条件比较苛刻一般适用于UI当中，条件如下：
	1.不能超过900个顶点属性
	2.不超过300个顶点
	3.如果使用Vertex Position、Normal、UV0、UV1 and Tangent上限为180顶点
	4.不能使用镜像Scale，例如(1,-1,1)，即不能出现负值
	5.不能使用多个Pass
	6.相同材质
17.静态合批：在游对象中对于静态的对象勾选Static。注意使用静态合批会使SharedMesh，各自在内存中存在一份拷贝，所以花草树木等不建议使用静态合批,会造成内存中驻留大量副本。
18.动态图集：这是一个不常用的方案，用不好就得不偿失。为了节省DC以及驻留内存的消耗，利用动态图集算法将当前所需的贴图渲染到一张RenderTexture中，图集算法可参考Github开源项目RectanglePacking。
19.减少材质实例：如果直接给Matrial赋值会在内存中新生成一份材质实例，可使用MaterialPropertyBlock对材质做操作，那么内存中材质实例仅存在一份。
20.Gpu Instancing:对于大量同材质对象可在Shader中开始Gpu Instancing，例如：血条、浮字伤害因为频繁动态会导致网格重构可考虑，自己写材质配合Gpu Instancing实现，以及SLG中大量小兵、花草树木等。
21.ECS:ECS和Gpu Instancing是一对好基友，DOTS给我们提供了安全的多线程编程，可用于各种寻路、物理等密集型计算，同时配合Gpu Instancing、Graphics.DrawMeshInstanced，即可实现No GameObject大量物体的渲染，SLG中大规模的战争就是以此基础，配合烘焙模型动画到纹理中的方式实现的。

UI控件复用：UI虽然有缓存策略以及生命周期策略，不过实例化加载、销毁依旧存在一定损耗，可考虑对控件做对象池，界面控件并非直接销毁，而是Release释放回收到对象池中，当有新界面打开时候，通过数据表数据对UI界面进行自动化布局。
23.生命周期管理：使用MonoBehaviour的生命周期函数存在时序控制比较困难问题，建议使用管理类保留主入口，其他生命周期函数自己编写接口，通过委托注册方法添加到生命周期当中。
24.弱引用：平常使用的引用一般都为强引用，若使用A->B->C->A这种形式对对象引用会导致引用闭环，所有引用对象将无法GC，应该WeakReference断开环链，这样将不会增加引用计数器计数，使对象能够有效被GC。
25.虚拟文件系统（Virtual File System）:使用虚拟文件系统将碎片文件整合统一集中管理，优化资源加载时内存分配，对局部资源片段加载友好。
26.虚拟配置表（Virtual Table）：一次性将表中数据加载到内存中将会造成不必要的内存浪费，使用虚拟配置表在内存中仅以哈希表形式维护引用对象的索引值，在真正需要使用时候,通过索引值获取相关对象数据。
27.虚拟贴图(Virtual Texture):和虚拟配置表原理相似，由于物理内存的瓶颈无法容纳大量的纹理或者是一次加载一张巨大的纹理。例如：一张大世界地形纹理，我们可使用虚拟贴图技术，将纹理分成n*n小块，内存中仅储存纹理索引，真正使用时候获取当前区域范围内的纹理索引，动态加载所需的纹理到内存中。
28.图片压缩:IOS图片选择PVRTC,安卓使用ASTC。
29.降低帧率：长时间静置时候，可选自自动降低帧率来节约性能开销达到省电目的，一旦有点击事件后再恢复。
30.模型合并：一些模型可食用组合的形式合并在一起，使用MeshBaker可达到网格材质合并目的。
31.LOD:可使用AutoLOD对游戏内模型层次细节划分。
```

