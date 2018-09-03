using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CandleBurning : MonoBehaviour {

    public GameObject candleLight;
    private Light light_;
    public GameObject girl;
    public GameObject fire;
    public GameObject wall;
    private Image image_;
    private SpriteRenderer gReder;
    private SpriteRenderer fReder;
    bool isClick;
	// Use this for initialization
	void Start () {
        light_ = candleLight.GetComponent<Light>();
        image_ = GetComponent<Image>();
        gReder = girl.GetComponent<SpriteRenderer>();
        fReder = fire.GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ClickCandle() {
        if (!isClick)
        {
            light_.range = 15;
            image_.color = Color.white;
            gReder.color = Color.white;
            fReder.color = Color.white;
            Destroy(wall);
            isClick = true;
        } else
        {
            light_.range = 0;
            image_.color = new Vector4(120, 120, 120, 1);
            gReder.color = new Vector4(120, 120, 120, 1);
            fReder.color = new Vector4(120, 120, 120, 1);
            isClick = false;
        }
    }
}
