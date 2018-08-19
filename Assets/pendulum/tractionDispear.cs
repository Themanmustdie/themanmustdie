using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tractionDispear : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "floor"){
            Destroy(gameObject, 1.0f);
        }
      
    }

    //void exploreAndDispear() {
    //    BoxCollider collider = GetComponent<BoxCollider>();
    //    collider.attachedRigidbody.AddExplosionForce(50f,  Vector3.zero, 0, 0);
    //    Destroy(gameObject, 1.0f);
    //}
}
