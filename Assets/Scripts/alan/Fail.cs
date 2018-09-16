using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fail : MonoBehaviour {
    public int scene;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "girl" || collider.tag == "balance")
        {
            NetCtrl.instance.LoadScene(User.ID, scene);
        }
    }
}
