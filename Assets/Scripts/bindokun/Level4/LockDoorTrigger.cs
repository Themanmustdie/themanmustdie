using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockDoorTrigger : MonoBehaviour {

    public GameObject LockDoorPrompt;
    private bool hasTrigger = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Girl" && !hasTrigger)
        {
            hasTrigger = true;
            LockDoorPrompt.transform.parent.gameObject.SetActive(true);
            GameObject.Find("Girl").GetComponent<NewGrilController>().DisableMoving();
        }
    }

    public void OnClickPrompt()
    {
        Destroy(LockDoorPrompt.transform.parent.gameObject);
        GameObject.Find("Girl").GetComponent<NewGrilController>().EnableMoving();

    }

}
