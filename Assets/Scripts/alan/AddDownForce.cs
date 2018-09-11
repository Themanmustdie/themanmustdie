using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddDownForce : MonoBehaviour {
    public GameObject pre; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    public void AddForce(){
        GameObject clone = Instantiate(pre);
        Rigidbody rb = clone.GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0, -290, 0), ForceMode.Impulse);
        Destroy(clone, 0.2f);
    }
}
