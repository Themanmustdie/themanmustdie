using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOrgan : MonoBehaviour {
    public GameObject end;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    private void OnTriggerEnter(Collider other)
    {
        print("1111");
        if (other.tag == "girl")
        {
            end.SetActive(true);
        }
    }
}
