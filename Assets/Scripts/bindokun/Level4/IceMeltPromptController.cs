﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMeltPromptController : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDestroy()
    {
        GameObject.Find("UILayer").GetComponentInChildren<BtnPromptController>(true).SwitchPromptFrom(1);
    }
}
