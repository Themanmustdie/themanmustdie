using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrestlePromptController : MonoBehaviour {

    private bool hasPrompt = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "midground" && !hasPrompt)
        {
            hasPrompt = true;
            GameObject.Find("UILayer").GetComponentInChildren<BtnPromptController>(true).SwitchPromptFrom(0);
        }
      
    }
}
