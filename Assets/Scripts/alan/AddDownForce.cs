﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddDownForce : MonoBehaviour {
    public GameObject pre;
    public bool IsFallIce = false;
    public GameObject Ice;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}



    public void AddForce(){
        if (!IsFallIce || Ice == null)
        {
            GameObject clone = Instantiate(pre);
            Rigidbody rb = clone.GetComponent<Rigidbody>();
            rb.AddForce(new Vector3(0, -290, 0), ForceMode.Impulse);
            //Destroy(clone, 0.5f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "ice cube")
        {
            IsFallIce = true;
        }

    }
}
