﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWaterRise : MonoBehaviour {
    public UnityEngine.Animator waterRise;
    //public UnityEngine.Animator waterRise2;
    public GameObject water;
    public GameObject raiseWater;
    public GameObject baffle;
    public GameObject roll;
	// Use this for initialization
	void Start () {
        waterRise.SetBool("IsRise", false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "board")
        {
            waterRise.gameObject.SetActive(true);
            waterRise.SetBool("IsRise", true);
            if (water != null)
            {
                Destroy(water);
            }
            if (raiseWater != null)
            {
                Destroy(raiseWater);
            }
        }

    }
}