# **框架说明**


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
````

````
二、类定义和使用规范
    1、


