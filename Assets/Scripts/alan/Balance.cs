﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balance : MonoBehaviour {
    public GameObject heavy1;
    public GameObject heavy2;
    public GameObject top1;
    public GameObject middle1;
    public GameObject bottom1;
    public GameObject top2;
    public GameObject middle2;
    public GameObject bottom2;
    public float speed = 0.05f;
    public float angle = 30f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float massLeft = heavy1.GetComponent<Rigidbody>().mass;
        float massRight = heavy2.GetComponent<Rigidbody>().mass;
        if(massLeft > massRight) {
            CounterclockwiseRotation();
        }
        else if(massLeft < massRight) {
            ClockwiseRotation();
        }
        else {
            Balance_();
        }

	}
    public void CounterclockwiseRotation() {
        transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, Quaternion.Euler(0, 0, -angle), Time.time * speed);
        heavy1.transform.position = Vector3.Lerp(heavy1.transform.position, top1.transform.position, Time.time * speed);
        heavy2.transform.position = Vector3.Lerp(heavy2.transform.position, bottom2.transform.position, Time.time * speed);
    }
    public void ClockwiseRotation()
    {
        transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, Quaternion.Euler(0, 0, angle), Time.time * speed);
        heavy1.transform.position = Vector3.Lerp(heavy1.transform.position, bottom1.transform.position, Time.time * speed);
        heavy2.transform.position = Vector3.Lerp(heavy2.transform.position, top2.transform.position, Time.time * speed);
    }
    public void Balance_()
    {
        transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, Quaternion.Euler(0, 0, 0), Time.time * speed);
        heavy1.transform.position = Vector3.Lerp(heavy1.transform.position, middle1.transform.position, Time.time * speed);
        heavy2.transform.position = Vector3.Lerp(heavy2.transform.position, middle2.transform.position, Time.time * speed);
    }
}
