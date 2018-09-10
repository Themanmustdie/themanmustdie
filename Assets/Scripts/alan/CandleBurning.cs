using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CandleBurning : MonoBehaviour {

    public GameObject ulight_1;
    public GameObject ulight_2;
    public GameObject ulight_3;
    public GameObject light_1;
    public GameObject light_2;
    public GameObject light_3;
    public GameObject girl;
    public GameObject fire;
    public GameObject wall;
    private SpriteRenderer gReder;
    private SpriteRenderer fReder;
    bool isClick = false;
	// Use this for initialization
	void Start () {
        gReder = girl.GetComponent<SpriteRenderer>();
        fReder = fire.GetComponent<SpriteRenderer>();
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
                    ulight_1.gameObject.SetActive(true);
                    ulight_2.gameObject.SetActive(true);
                    ulight_3.gameObject.SetActive(true);
                    light_1.gameObject.SetActive(true);
                    light_2.gameObject.SetActive(true);
                    light_3.gameObject.SetActive(true);
                    gReder.color = Color.white;
                    fReder.color = Color.white;
                    Destroy(wall);
                    isClick = true;
                }
            }
        }
	}

}
