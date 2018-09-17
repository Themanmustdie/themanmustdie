using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public bool isPrompting = false;
    public bool isBtnShowing = false;
    private BtnPromptController btnPromptCtrl;
    
    public GameObject maskPanel;
    private UIManager uiManager;

    // private BtnSettingController btnSettingCtrl;
    private CameraManager cameraMgr;

    // Use this for initialization
    void Start()
    {
        btnPromptCtrl = GetComponentInChildren<BtnPromptController>(true);
        cameraMgr = GameObject.Find("EverySceneNeed").GetComponent<CameraManager>();
        // btnSettingCtrl = GetComponentInChildren<BtnSettingController>(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowCommonButtons()
    {
        cameraMgr.BlurBackground(false);
        foreach (Transform tr in GetComponentInChildren<Transform>(true))
        {
            if (tr.gameObject.name == "btnLeft" || tr.gameObject.name == "btnRight" || tr.gameObject.name == "btnSetting")
            {
                tr.gameObject.SetActive(true);
            }
            else
            {
                tr.gameObject.SetActive(false);
            }
        }
    }
    public void ShowControlButtons()
    {
        cameraMgr.BlurBackground(true);
        foreach (Transform tr in GetComponentInChildren<Transform>(true))
        {
            if (tr.gameObject.name == "BtnPrompt" || tr.gameObject.name == "BtnReplay" || tr.gameObject.name == "BtnGoBack" || tr.gameObject.name == "UILayerMaskPanel")
            {
                tr.gameObject.SetActive(true);
            }
            else
            {
                tr.gameObject.SetActive(true);
            }
        }
    }

    public void HideAllButtonsButMaskPanel()
    {
        foreach (Transform tr in GetComponentInChildren<Transform>(true))
        {

            if (tr.gameObject.name == "UILayerMaskPanel")
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
        isPrompting = false;
        btnPromptCtrl.HidePrompt();
        ShowCommonButtons();
        isBtnShowing = false;
    }

    public void OnClickBtnSetting()
    {
        isBtnShowing = !isBtnShowing;
        if (isBtnShowing)
        {
            ShowControlButtons();
        }
        else
        {
            ShowCommonButtons();
        }
    }
}
