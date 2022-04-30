
---================================================
---描 述 :  GameObjectUtils
---作 者 : 杜鑫 
---创建时间 : 2021-07-20 07-57-26  
---修改作者 : 杜鑫 
---修改时间 : 2021-07-20 07-57-26  
---版 本 : 0.1 
---===============================================
---@class UIUtils
UIUtils = {}
UIUtils.tbScrollViewList = {}

---初始化 List 列表
---@param vListScrollView SuperScrollView.LoopListView2
function UIUtils.InitListView(vListScrollView,tbList,parentClass,callBack)
    if not vListScrollView then
        Logger.Error("ListScrollView is nil")
        return
    end
    if not tbList then
        Logger.Error("tbList is nil")
        return
    end
    local count = 0
    count = #tbList
    if (count < 0 or count > #tbList) then
        return
    end
    local key = parentClass.name .. "_" .. vListScrollView.name
    UIUtils.tbScrollViewList[key] = UIUtils.tbScrollViewList[key] or {}
    vListScrollView:InitListView(count,function(listView,index)
        local item = listView:NewListViewItem("ScrollVItemPrefab");
        local itemScript = UIUtils.tbScrollViewList[key][index]
        if itemScript then
            itemScript = LuaGameEntry.UI:BindUIUnit(item.gameObject,itemScript);
        else
            itemScript = LuaGameEntry.UI:BindUIUnit(item.gameObject);
        end
        if (item.IsInitHandlerCalled == false) then
            item.IsInitHandlerCalled = true
            itemScript:Init();
        end
        itemScript:SetItemData(tbList[index+1], index);
        if callBack then
            callBack(itemScript,tbList[index+1], index)
        end
        return item
    end)
end
---初始化 Grid 列表
function UIUtils.InitGridView(vGridScrollView,tbList,parentClass,callBack)
    if not vGridScrollView then
        Logger.Error("vGridScrollView is nil")
        return
    end
    if not tbList then
        Logger.Error("tbList is nil")
        return
    end
    local count = 0
    count = #tbList
    if (count < 0 or count > #tbList) then
        return
    end
    local key = parentClass.name .. "_" .. vGridScrollView.name
    UIUtils.tbScrollViewList[key] = UIUtils.tbScrollViewList[key] or {}
    vGridScrollView:InitGridView(count,function(gridView,index,row,column)
        local item = gridView:NewListViewItem("ScrollVItemPrefab");
        local itemScript = UIUtils.tbScrollViewList[key][index]
        if itemScript then
            itemScript = LuaGameEntry.UI:BindUIUnit(item.gameObject,itemScript);
        else
            itemScript = LuaGameEntry.UI:BindUIUnit(item.gameObject);
        end
        if (item.IsInitHandlerCalled == false) then
            item.IsInitHandlerCalled = true;
            itemScript:Init();
        end
        itemScript:SetItemData(tbList[index+1], index, row, column);
        if callBack then
            callBack(itemScript,tbList[index+1], index, row, column)
        end
        return item;
    end)
end

---初始化 List or Grid 列表
function UIUtils.SetListItemCount(vListScrollView,tbList,resetPos)
    if (vListScrollView.ItemTotalCount < 0) then
        return
    end
    if resetPos ~= false then
        resetPos = true
    end
    local count = 0
    count = #tbList
    if (count < 0 or count > #tbList) then
        return
    end
    vListScrollView:SetListItemCount(count, resetPos);
end

function UIUtils.RegisterClick(btn,callBack)
    if not btn then
        Logger.Error("btn is nil")
        return
    end
    btn.onClick:AddListener(function()
        if callBack then
            callBack()
        end
    end)
end

return UIUtils