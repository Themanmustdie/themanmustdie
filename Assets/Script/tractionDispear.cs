using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tractionDispear : MonoBehaviour {
    DateTime t_MouseDown;
    bool flag = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!flag && Input.GetMouseButtonDown(0))
        {
            t_MouseDown = DateTime.Now;
            flag = true;
        }

        if (flag && DateTime.Now - t_MouseDown > new TimeSpan(0, 0, 0, 2, 0))
        {
            Destroy(gameObject);
        }
	}


    //void exploreAndDispear() {
    //    BoxCollider collider = GetComponent<BoxCollider>();
    //    collider.attachedRigidbody.AddExplosionForce(50f,  Vector3.zero, 0, 0);
    //    Destroy(gameObject, 1.0f);
    //}
}
