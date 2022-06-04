
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
UIUtils.tbScrollDataList = {}
UIUtils.tbScrollInit = {}
---初始化 List 列表
---@param vListScrollView SuperScrollView.LoopListView2
function UIUtils.InitListView(vListScrollView,tbList,parentClass,callBack)
    if not vListScrollView then
        Logger.Error("ListScrollView is nil")
        return
    end
    vListScrollView:RefreshAllShownItemWithFirstIndex(0)
    if not tbList then
        Logger.Error("tbList is nil")
        return
    end
    local count = 0
    count = #tbList
    if (count < 0 or count > #tbList) then
        return
    end
    local instanceID = vListScrollView:GetInstanceID()
    if UIUtils.tbScrollInit[instanceID] then
        UIUtils.SetListItemCount(vListScrollView,tbList,true)
        return
    end
    UIUtils.tbScrollInit[instanceID] = true
    UIUtils.tbScrollDataList[instanceID] = tbList
    UIUtils.tbScrollViewList[instanceID] = UIUtils.tbScrollViewList[instanceID] or {}
    vListScrollView:InitListView(count,function(listView,index)
        local item = listView:NewListViewItem("ScrollVItemPrefab");
        local itemScript = UIUtils.tbScrollViewList[instanceID][index]
        if itemScript then
            itemScript = LuaGameEntry.UI:BindUIUnit(item.gameObject,itemScript);
        else
            itemScript = LuaGameEntry.UI:BindUIUnit(item.gameObject);
        end
        if (item.IsInitHandlerCalled == false) then
            item.IsInitHandlerCalled = true
            itemScript:Init();
        end
        itemScript:SetItemData(UIUtils.tbScrollDataList[hashCode][index+1], index);
        if callBack then
            callBack(itemScript,UIUtils.tbScrollDataList[instanceID][index+1], index)
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

    local instanceID = vGridScrollView:GetInstanceID()
    if UIUtils.tbScrollInit[instanceID] then
        UIUtils.SetListItemCount(vGridScrollView,tbList,true)
        return
    end
    UIUtils.tbScrollInit[instanceID] = true
    UIUtils.tbScrollDataList[instanceID] = tbList
    UIUtils.tbScrollViewList[instanceID] = UIUtils.tbScrollViewList[instanceID] or {}
    vGridScrollView:InitGridView(count,function(gridView,index,row,column)
        local item = gridView:NewListViewItem("ScrollVItemPrefab");
        local itemScript = UIUtils.tbScrollViewList[instanceID][index]
        if itemScript then
            itemScript = LuaGameEntry.UI:BindUIUnit(item.gameObject,itemScript);
        else
            itemScript = LuaGameEntry.UI:BindUIUnit(item.gameObject);
        end
        if (item.IsInitHandlerCalled == false) then
            item.IsInitHandlerCalled = true;
            itemScript:Init();
        end
        itemScript:SetItemData(UIUtils.tbScrollDataList[instanceID][index+1], index, row, column);
        if callBack then
            callBack(itemScript,UIUtils.tbScrollDataList[instanceID][index+1], index, row, column)
        end
        return item;
    end)
end

---初始化 List or Grid 列表
function UIUtils.SetListItemCount(vScrollView,tbList,resetPos)
    if (vScrollView.ItemTotalCount < 0) then
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
    local instanceID = vScrollView:GetInstanceID()
    UIUtils.tbScrollDataList[instanceID] = tbList
    vScrollView:SetListItemCount(count, resetPos);
    vScrollView:RefreshAllShownItem()
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