using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public bool isPrompting =false;
    private BtnPromptController btnPromptCtrl;
    private BtnSettingController btnSettingCtrl;
    private CameraManager cameraMgr;

    // Use this for initialization
    void Start () {
        btnPromptCtrl = GetComponentInChildren<BtnPromptController>(true);
        cameraMgr = GameObject.Find("EverySceneNeed").GetComponent<CameraManager>();
        btnSettingCtrl = GetComponentInChildren<BtnSettingController>(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowCommonButtons()
    {
        foreach(Transform tr in GetComponentInChildren<Transform>(true))
        {
            if(tr.gameObject.name == "btnLeft" || tr.gameObject.name == "btnRight" || tr.gameObject.name == "btnSetting")
            {
                tr.gameObject.SetActive(true);
            }
        }
    }

    public void HideAllButtonsButMaskPanel()
    {
        foreach (Transform tr in GetComponentInChildren<Transform>(true))
        {
           
            if(tr.gameObject.name == "UILayerMaskPanel")
            {
                tr.gameObject.SetActive(true);
            }
            else
            {
                tr.gameObject.SetActive(false);
            }
        }
    }

    public void HideAllButtons()
    {
        foreach (Transform tr in GetComponentInChildren<Transform>())
        {
            tr.gameObject.SetActive(false);
        }
    }

    public void OnClickMaskPanel()
    {
        if(isPrompting)
        {
            ShowCommonButtons();
            btnSettingCtrl.OnClick();
            isPrompting = false;
            btnPromptCtrl.HidePrompt();
        }
    }
}
