﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMeltPrompt : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDestroy()
    {
        BtnPromptController controller = GameObject.Find("UILayer").GetComponentInChildren<BtnPromptController>(true);
        if(controller)
        {
            GameObject.Find("UILayer").GetComponentInChildren<BtnPromptController>(true).SwitchPromptFrom(0);   
        }
        
    }
}
