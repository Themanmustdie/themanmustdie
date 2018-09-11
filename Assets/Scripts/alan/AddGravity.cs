using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGravity : MonoBehaviour {
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider collider)
    {
        //进入触发器执行的代码
        if(collider.tag == "ice cube"){
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            rb.mass = 10f;
        }
    }

}
