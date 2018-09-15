using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;
using UnityEngine.SceneManagement;

public class ButterflyController : MonoBehaviour
{


    public float speed = 2.0f;
    //曲线
    public AnimationCurve anim;
    private Transform trButterfly;
    private float startTime;
    public float targetLocalXpos;
    public GameObject girl;
    public GameObject boySprite;
    public GameObject comicPanel;
    private UIManager uiManager;

    // Use this for initialization

    void Start()
    {
        trButterfly = GetComponent<Transform>();
        startTime = Time.time;
        uiManager = GameObject.Find("UILayer").GetComponent<UIManager>();

    }



    // Update is called once per frame

    void Update()
    {

        if (trButterfly.localPosition.x > targetLocalXpos)
        {


            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                GameObject.Find("EverySceneNeed").GetComponent<CameraManager>().ChangeTarget(girl);
                gameObject.SetActive(false);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                gameObject.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
            }

            girl.GetComponent<NewGrilController>().EnableMoving();
            boySprite.GetComponent<SpriteController>().EnableMoving();
            // 显示按钮
            GameObject.Find("UILayer").GetComponent<UIManager>().ShowCommonButtons();
        }
        else
        {
            trButterfly.position = new Vector3(trButterfly.position.x + speed * Time.deltaTime, anim.Evaluate((Time.time - startTime) * speed), 0);
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Girl")
        {
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                PlayMemoryOne();
                uiManager.HideAllButtons();
                girl.GetComponent<NewGrilController>().DisableMoving();
                Destroy(gameObject);
            }
        }

    }


    private void PlayMemoryOne()
    {
        comicPanel.SetActive(true);
    }
}
