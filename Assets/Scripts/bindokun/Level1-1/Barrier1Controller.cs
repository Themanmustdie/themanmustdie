﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier1Controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Stone")
        {
            collision.gameObject.GetComponent<ConstantForce>().enabled = true;
        }
    }
}