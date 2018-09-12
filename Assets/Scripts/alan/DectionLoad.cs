using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DectionLoad : MonoBehaviour {
    public GameObject girl;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(transform.position, girl.transform.position);
        Rigidbody rb = GetComponent<Rigidbody>();
        if(distance < 2.1f){
            if(rb.mass >= 2){
                return;
            }
            rb.mass = 2;
        } else{
            if (rb.mass == 3)
            {
                return;
            }
            rb.mass = 1;
        }
	}

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Rigidbody rb = GetComponent<Rigidbody>();
    //    if(collision.collider.tag == "girl")
    //    {
    //        float distance = Vector3.Distance(transform.position, collision.transform.position);
    //        print(distance);
    //    }

    //}

    //void OnCollisionExit(Collision other)
    //{
    //    Rigidbody rb = GetComponent<Rigidbody>();
    //    if (other.collider.tag == "girl")
    //    {
    //        if (rb.mass > 2)
    //        {
    //            return;
    //        }
    //        rb.mass = 1;
    //    }
    //}
}
