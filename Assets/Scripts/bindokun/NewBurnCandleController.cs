using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBurnCandleController : MonoBehaviour {

    private bool isClick = false;
    private bool isClickFire = false;
    private bool isClickCandle = false;

    public GameObject wall;
    public GameObject backgroundWall;
    private Animator aniBackgroundWall;

    // Use this for initialization
    void Start () {
        aniBackgroundWall = backgroundWall.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!isClick && Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(ray);
            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.gameObject.tag == "BoySprite")
                {
                   
                    isClickFire = true;
                }

                if (hit.collider.gameObject.name == "NewDetection")
                {
                    isClickCandle = true;
                }

                if (isClickFire & isClickCandle)
                {
                    Destroy(wall);
                    isClick = true;
                    aniBackgroundWall.SetBool("isLighten", true);
                }
            }
            isClickFire = false;
            isClickCandle = false;
        }
    }

}
