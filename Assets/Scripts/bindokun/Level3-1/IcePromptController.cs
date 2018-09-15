using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePromptController : MonoBehaviour
{

    private static int iceNum = 0;

   
    // Use this for initialization
    void Start()
    {
        IcePromptController.iceNum = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnDestroy()
    {
        IcePromptController.iceNum++;
        if (IcePromptController.iceNum >= 2)
        {
            GameObject.Find("UILayer").GetComponentInChildren<BtnPromptController>(true).SwitchPromptFrom(1);
        }
    }
}
