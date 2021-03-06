﻿using System.Collections;
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
    private UIManager uiManager;
    public bool isFinish = false;
    private float startY = 0;

    // Use this for initialization

    void Start()
    {
        trButterfly = GetComponent<Transform>();
        startTime = Time.time;
        uiManager = GameObject.Find("UILayer").GetComponent<UIManager>();
        startY = trButterfly.position.y;

    }
    // Update is called once per frame
    void Update()
    {
        if(isFinish)
        {
            return;
        }

        if (trButterfly.localPosition.x > targetLocalXpos)
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                GameObject.Find("EverySceneNeed").GetComponent<CameraManager>().ChangeTarget(girl);
                gameObject.SetActive(false);
            }
            girl.GetComponent<NewGrilController>().EnableMoving();
            boySprite.GetComponent<SpriteController>().EnableMoving();
            // 显示按钮
            GameObject.Find("UILayer").GetComponent<UIManager>().ShowCommonButtons();
            isFinish = true;
        }
        else
        {
            trButterfly.position = new Vector3(trButterfly.position.x + speed * Time.deltaTime, startY + anim.Evaluate((Time.time - startTime) * speed), 0);
        }
    }
}
