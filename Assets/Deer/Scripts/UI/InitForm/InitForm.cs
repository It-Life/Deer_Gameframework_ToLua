// ================================================
//描 述 :  
//作 者 : 杜鑫 
//创建时间 : 2021-10-10 16-03-00  
//修改作者 : 杜鑫 
//修改时间 : 2021-10-10 16-03-00  
//版 本 : 0.1 
// ===============================================

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InitForm : MonoBehaviour
{
	public Image progressImg;
	public TextMeshProUGUI progressText;
	public RectTransform uiTipsPanel;
	public UIButtonSuper backTipsBtn;
	public UIButtonSuper closeBtn;
	public UIButtonSuper okBtn;
	public TextMeshProUGUI tipsText;
	
	private void Awake()
	{
		backTipsBtn.onClick.AddListener(BackTipsBtn);
		closeBtn.onClick.AddListener(CloseBtn);
		okBtn.onClick.AddListener(OkBtn);
	}

	void Start()
	{
		GameEntry.Messenger.RegisterEvent(EventName.EVENT_CS_UI_REFRESH_LOADING_UI,RefreshProgress);
		GameEntry.Messenger.RegisterEvent(EventName.EVENT_CS_UI_OPEN_TIPS_UI,OpenUiTipsPanel);
		GameEntry.Messenger.RegisterEvent(EventName.EVENT_CS_UI_OPEN_INITFORM_UI,OpenUiInitFormPanel);
	}

	private void OnDestroy()
	{
		GameEntry.Messenger.UnRegisterEvent(EventName.EVENT_CS_UI_REFRESH_LOADING_UI,RefreshProgress);
		GameEntry.Messenger.UnRegisterEvent(EventName.EVENT_CS_UI_OPEN_TIPS_UI,OpenUiTipsPanel);
		GameEntry.Messenger.UnRegisterEvent(EventName.EVENT_CS_UI_OPEN_INITFORM_UI,OpenUiInitFormPanel);
	}
	
	object OpenUiTipsPanel(object pSender)
	{
		MessengerInfo messengerInfo = (MessengerInfo) pSender;
		bool bIsOpen = bool.Parse(messengerInfo.param1.ToString());
		uiTipsPanel.gameObject.SetActive(bIsOpen);
		if (bIsOpen)
		{
			string strTips = messengerInfo.param2.ToString();
			tipsText.text = strTips;
		}
		return null;
	}
	object RefreshProgress(object pSender)
	{
		float value = 0;
		if (pSender is MessengerInfo messengerInfo)
	    {
		    float.TryParse(messengerInfo.param1.ToString(), out value);
		    progressImg.fillAmount = value;
		    progressText.text = messengerInfo.param2.ToString();
	    }
		return null;
	}

	object OpenUiInitFormPanel(object pSender)
	{
		bool bIsOpen = bool.Parse(pSender.ToString());
		gameObject.SetActive(bIsOpen);
		return null;
	}

	void BackTipsBtn()
	{
		OpenUiTipsPanel(new MessengerInfo(){param1 = false});
	}

	void CloseBtn()
	{
		MessengerInfo messengerInfo = new MessengerInfo();
		messengerInfo.param1 = false;
		GameEntry.Messenger.SendEvent(EventName.EVENT_CS_UI_TIPS_CALLBACK, messengerInfo);
		OpenUiTipsPanel(new MessengerInfo(){param1 = false});
	}

	void OkBtn()
	{
		MessengerInfo messengerInfo = new MessengerInfo();
		messengerInfo.param1 = true;
		GameEntry.Messenger.SendEvent(EventName.EVENT_CS_UI_TIPS_CALLBACK, messengerInfo);
		OpenUiTipsPanel(new MessengerInfo(){param1 = false});
	}
}