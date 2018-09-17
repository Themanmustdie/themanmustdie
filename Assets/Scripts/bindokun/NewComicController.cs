using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewComicController : MonoBehaviour
{

    public GameObject[] comics = new GameObject[7];
    private int curIndex = 0;
    private UIManager uiManager;
    // Use this for initialization
    void Start()
    {
        uiManager = GameObject.Find("UILayer").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnComicFinish()
    {
        curIndex++;
        if (curIndex - 1 < comics.Length && curIndex - 1 >= 0)
        {
            Destroy(comics[curIndex - 1]);
        }
        if (curIndex < comics.Length)
        {
            comics[curIndex].SetActive(true);
        }   
        if (curIndex >= comics.Length)
        {
            Destroy(gameObject);
          //  gameObject.SetActive(false);
            uiManager.ShowCommonButtons();
            GameObject.Find("Girl").GetComponent<NewGrilController>().EnableMoving();
        }
    }
}
