using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReduceParentMass : MonoBehaviour {
    bool flag;
    DateTime t_MouseDown;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0))
        {
            flag = false;
        }
        if (!flag && Input.GetMouseButtonDown(0))
        {
            t_MouseDown = DateTime.Now;
            flag = true;
        }

        if (flag && DateTime.Now - t_MouseDown > new TimeSpan(0, 0, 0, 2, 0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(ray);
            bool isHitSprite = false;
            bool isHitWater = false;
            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.tag == "water")
                {
                    isHitWater = true;
                }
                if (hit.collider.tag == "BoySprite"){
                    isHitSprite = true;
                }
                if(isHitSprite && isHitWater)
                {
                    Rigidbody rb = transform.parent.gameObject.GetComponent<Rigidbody>();
                    rb.mass = 1;
                    Destroy(this.gameObject);
                }
            }
        }
	}
}
