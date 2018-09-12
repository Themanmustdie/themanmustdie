using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DectionLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (collision.collider.tag == "water")
        {
            rb.mass = 3;

        }
        else if(collision.collider.tag == "girl")
        {
            if(rb.mass >= 2){
                return;
            }
            rb.mass = 2;
        }

    }
}
