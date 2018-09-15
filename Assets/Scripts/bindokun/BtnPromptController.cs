using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnPromptController : MonoBehaviour
{

    public GameObject[] promptList;
    private int curPromptIdx = 0;

    public GameObject btnReplay;
    private bool[] hasPromptList;
    private bool hasInit = false;

    
    private void Init()
    {
        hasPromptList = new bool[promptList.Length];
        for (int i = 0; i < hasPromptList.Length; ++i)
        {
            hasPromptList[i] = false;
        }
    }
    

    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void OnClick()
    {
        if (curPromptIdx >= 0 && curPromptIdx < promptList.Length)
        {
            promptList[curPromptIdx].SetActive(true);
            promptList[curPromptIdx].transform.parent.gameObject.SetActive(true);
            btnReplay.SetActive(false);
            gameObject.SetActive(false);
        }

    }

    public void SwitchPrompt()
    {
        curPromptIdx++;
    }
    public void SwitchPromptFrom(int index)
    {
        if(!hasInit)
        {
            hasInit = true;
            Init();
        }
        if (index >= 0 && index < hasPromptList.Length)
        {
            hasPromptList[index] = true;

            curPromptIdx = hasPromptList.Length - 1;
            for (int i = 0; i < hasPromptList.Length; ++i)
            {
                if (!hasPromptList[i])
                {
                    Debug.Log(i);
                    curPromptIdx = i;
                    break;
                }
            }
        }

    }
}
