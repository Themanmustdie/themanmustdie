using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBurnCandleController : MonoBehaviour {

    private static bool isLightened  = false;

    private bool isClick = false;
    private bool isClickFire = false;
    private bool isClickCandle = false;

    public GameObject mask;

    private float time_;

    public GameObject wall;
    public GameObject backgroundWall;
    private Animator aniBackgroundWall;
    private UIManager uiManager;

    // Use this for initialization
    void Start () {
        aniBackgroundWall = backgroundWall.GetComponent<Animator>();
        isLightened = false;
        uiManager = GameObject.Find("UILayer").GetComponent<UIManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!NewBurnCandleController.isLightened && Input.GetMouseButtonDown(0) && !uiManager.isBtnShowing)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(ray);
            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.gameObject.name.StartsWith("NewDetection"))
                {
                    mask.SetActive(true);
                    isClickCandle = true;
                    GameObject boy = GameObject.Find("BoySprite");
                    time_ = Mathf.Abs(Vector3.Distance(boy.transform.position, hit.transform.position)) / 8;
                    break;
                }

            }
            if (isClickCandle)
            {
                Invoke("StartFire", time_);
            }
            isClickCandle = false;
          
        }
    }


    public void StartFire()
    {
        Destroy(wall);
        NewBurnCandleController.isLightened = true;
        aniBackgroundWall.SetBool("isLighten", true);
        mask.SetActive(false);
    }

}
