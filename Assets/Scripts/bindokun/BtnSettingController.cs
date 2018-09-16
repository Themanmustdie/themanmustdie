using UnityEngine;

public class BtnSettingController : MonoBehaviour
{

    public GameObject btnPrompt;
    public GameObject btnReplay;
    public GameObject btnGoBack;
    private CameraManager cameraMgr;
    private bool isShowBtn;
    public GameObject maskPanel;
    // Use this for initialization
    void Start()
    {
        cameraMgr = GameObject.Find("EverySceneNeed").GetComponent<CameraManager>();
        isShowBtn = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        isShowBtn = !isShowBtn;
        cameraMgr.BlurBackground(isShowBtn);
        btnPrompt.SetActive(isShowBtn);
        btnReplay.SetActive(isShowBtn);
        maskPanel.SetActive(isShowBtn);
        btnGoBack.SetActive(isShowBtn);

    }
}
