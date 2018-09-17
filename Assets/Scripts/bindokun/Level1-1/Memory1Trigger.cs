using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memory1Trigger : MonoBehaviour
{

    private AudioSource bgmSound;
    public GameObject comicPanel;
    private UIManager uiMgr;
    private GameObject girl;
    private GameObject normalBGM;
    // Use this for initialization
    void Start()
    {
        bgmSound = GameObject.Find("MemoryBGM").GetComponent<AudioSource>();
        uiMgr = GameObject.Find("UILayer").GetComponent<UIManager>();
        girl = GameObject.Find("Girl");
        normalBGM = GameObject.Find("NomalBGM");
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Girl")
        {
            normalBGM.SetActive(false);
            bgmSound.Play();
            comicPanel.SetActive(true);
            uiMgr.HideAllButtons();
            girl.GetComponent<NewGrilController>().DisableMoving();
            Destroy(gameObject);
        }
    }
}
