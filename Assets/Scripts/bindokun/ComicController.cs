using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComicController : MonoBehaviour
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

    public void OnClickComic()
    {
        curIndex++;
        if (curIndex - 1 < comics.Length)
        {
            comics[curIndex - 1].GetComponent<Animator>().SetBool("isFadeOut", true);
        }
        if (curIndex < comics.Length)
        {
            comics[curIndex].SetActive(true);
        }
        if (curIndex - 2 >= 0)
        {
            comics[curIndex - 2].SetActive(false);
        }

        if (curIndex >= comics.Length)
        {
            gameObject.SetActive(false);
            uiManager.ShowCommonButtons();
            GameObject.Find("Girl").GetComponent<NewGrilController>().EnableMoving();
        }

        // comics[comics.Length - 1].SetActive(false);
        //gameObject.SetActive(false);

    }

}
