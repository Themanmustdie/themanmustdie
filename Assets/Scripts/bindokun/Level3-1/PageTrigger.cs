using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageTrigger : MonoBehaviour
{

    private bool hasTrigger = false;
    private int promptCnt = 0;
    public GameObject prompt1;
    public GameObject prompt2;
    public GameObject promptMaskPanel;


    public NewGrilController girCtrl;
    public SpriteController spriteCtrl;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Girl" && !hasTrigger)
        {
            hasTrigger = true;
            promptMaskPanel.SetActive(true);

            girCtrl.DisableMoving();
            // spriteCtrl.DisableMoving();
        }
    }


    public void OnClick()
    {
        Debug.Log("aaaaaaaaaaa");
        if (promptCnt == 0)
        {
            Destroy(prompt1);
            prompt2.SetActive(true);
        }
        else if (promptCnt == 1)
        {
            //gameObject.SetActive(false);
            Destroy(promptMaskPanel);
            Destroy(gameObject);
            girCtrl.EnableMoving();
            //   spriteCtrl.EnableMoving();
        }
        promptCnt++;
    }
}
