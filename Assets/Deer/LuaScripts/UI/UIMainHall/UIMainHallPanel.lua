
---================================================
---描 述 : 
---作 者 : Admin 
---创建时间 : 2021-08-01 22-08-54 
---修改作者 : Admin 
---修改时间 : 2021-08-01 22-08-54 
---版 本 : $Version 
---===============================================
UIMainHallPanel = UIMainHallPanel --Assets/Deer/Asset/UI/UIPrefab/UIMainHall/UIMainHallPanel.prefab
---@class UIMainHallPanel:UIBaseClass
--------------AutoGenerated--------------
---@field joystick zFrame.UI.Joystick
---@field rightBtnPart UnityEngine.RectTransform
---@field leftBtnPart UnityEngine.RectTransform
---@field close UIButtonSuper
--------------Do not modify!-------------
local UIMainHallPanel = Class('UIMainHallPanel', UIBaseClass)

function UIMainHallPanel:OnShow()
    self.super.OnShow(self)
    self.m_isMoveing = false
    self:RegisterEvent()
    self.joystick.OnValueChanged:AddListener(function(v)
        if v.magnitude ~= 0 then
            self.m_isMoveing = true
            local messengerInfo = {}
            messengerInfo.param1 = v.x
            messengerInfo.param2 = v.y
            LuaGameEntry.LuaEvent:SendLuaEvent(EventId.EVENT_LUA_GAME_MOVE_DIRECTION,messengerInfo,true)
        else
            if self.m_isMoveing then
                LuaGameEntry.LuaEvent:SendLuaEvent(EventId.EVENT_LUA_GAME_MOVE_END,true)
                self.m_isMoveing = false
            end
        end
    end)
        GObjUtils.GetAllChildren(self.leftBtnPart,typeof(UIButtonSuper),function(nIndex,btnChild)
        UIUtils.RegisterClick(btnChild,function()
            self:OnLeftPartBtn(btnChild,nIndex)
        end)
    end)
    GObjUtils.GetAllChildren(self.rightBtnPart,typeof(UIButtonSuper),function(nIndex,btnChild)
        local text = btnChild.transform:Find("Text"):GetComponent(typeof(TextMeshProUGUI))
        text.text = LuaGameConfig.Language:GetText("Text_Main_Hall_Right_Btn_"..nIndex)
        UIUtils.RegisterClick(btnChild,function()
            self:OnRightPartBtn(btnChild,nIndex)
        end)
    end)
end

function UIMainHallPanel:OnHide()
    self.super.OnHide(self)

    self:UnRegisterEvent()
end

function UIMainHallPanel:RegisterEvent()

end

function UIMainHallPanel:UnRegisterEvent()

end

-----------------------------logic----------------------------------
--{{{logic
--}}}

--{{{属性
--}}}
-----------------------------event----------------------------------
--{{{event
--}}}
-----------------------------button----------------------------------
---@param button UIButtonSuper
function UIMainHallPanel:OnClickCloseBtn(button)
    LuaGameEntry.UI:CloseUI(UINameConfig.UIMainHallPanel)
    LuaGameEntry.Procedure:OnChangeLuaProcedure(ProcedureConfig.ProcedureLogin)
end

---@param button UIButtonSuper
function UIMainHallPanel:OnDoubleClickCloseBtn(button)

end

---@param button UIButtonSuper
function UIMainHallPanel:OnLongPressCloseBtn(button)

end

---@param button UIButtonSuper
function UIMainHallPanel:OnLeftPartBtn(button,nIndex)
    if nIndex then

    end
    --LuaGameEntry.UI:OpenUI(UINameConfig.UIBagPanel)
    Logger.Debug("Index:" .. nIndex)
end

function UIMainHallPanel:OnRightPartBtn(button,nIndex)
    if nIndex then

    end
    --LuaGameEntry.UI:OpenUI(UINameConfig.UIBagPanel)
    Logger.Debug("Index:" .. nIndex)
end

return UIMainHallPanel
