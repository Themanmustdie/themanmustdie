using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoorController : MonoBehaviour {

    public GameObject imgBackground;
    public GameObject imgBackgroundOpenDoor;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "girl")
        {
            Destroy(imgBackground);
            imgBackgroundOpenDoor.SetActive(true);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
