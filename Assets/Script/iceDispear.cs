using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceDispear : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "floor")
        {
            Destroy(gameObject, 2.0f);
        }

    }
}
