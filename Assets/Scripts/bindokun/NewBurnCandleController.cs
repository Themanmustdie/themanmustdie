using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBurnCandleController : MonoBehaviour {

    private static bool isLightened  = false;

    private bool isClick = false;
    private bool isClickFire = false;
    private bool isClickCandle = false;

    public GameObject wall;
    public GameObject backgroundWall;
    private Animator aniBackgroundWall;

    // Use this for initialization
    void Start () {
        aniBackgroundWall = backgroundWall.GetComponent<Animator>();
        isLightened = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (!NewBurnCandleController.isLightened && Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(ray);
            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.gameObject.tag == "BoySprite")
                {
                    isClickFire = true;
                 //   Debug.Log("BoySprite");
                }

                if (hit.collider.gameObject.name.StartsWith("NewDetection"))
                {
                    isClickCandle = true;
                   // Debug.Log("NewDetection");
                }

                if (isClickFire & isClickCandle)
                {
                  //  Debug.Log("desdroy wall");
                    Destroy(wall);
                    NewBurnCandleController.isLightened = true;
                    aniBackgroundWall.SetBool("isLighten", true);
                }
            }
            isClickFire = false;
            isClickCandle = false;
        }
    }

}
