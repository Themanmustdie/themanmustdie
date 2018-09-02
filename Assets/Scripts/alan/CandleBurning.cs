using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleBurning : MonoBehaviour {

    public GameObject candleLight;
    private Light light_;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ClickCandle() {
        print("click");
        light_ = candleLight.GetComponent<Light>();
        light_.intensity = 40;
    }
}
