using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondLampPromptController : MonoBehaviour {

    private bool hasPrompt = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasPrompt)
        {
            hasPrompt = true;
            GameObject.Find("UILayer").GetComponentInChildren<BtnPromptController>(true).SwitchPromptFrom(3);
        }
    }
}
