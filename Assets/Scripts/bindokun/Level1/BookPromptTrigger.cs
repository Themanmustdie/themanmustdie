using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookPromptTrigger : MonoBehaviour {

    private BtnPromptController promptController; 
	// Use this for initialization
	void Start () {
        promptController = GameObject.Find("UILayer").GetComponentInChildren<BtnPromptController>(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.name == "Book")
        {
            promptController.SwitchPrompt();
        }
    }

}
