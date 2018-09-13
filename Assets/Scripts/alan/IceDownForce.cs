using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceDownForce : MonoBehaviour {
    public GameObject rope;
    private bool isAddForce = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(!isAddForce) {
            if (rope == null){
                Rigidbody rb = GetComponent<Rigidbody>();
                rb.AddForce(new Vector3(0, -3, 0), ForceMode.Impulse);
                isAddForce = true;
            }
        }
	}
}
