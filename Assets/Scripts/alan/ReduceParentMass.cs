﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReduceParentMass : MonoBehaviour
{
    bool flag;
    DateTime t_MouseDown;
    public Sprite trayWithWater;
    public Sprite trayWithoutWater;
    private bool hasPrompt = false;
    public UnityEngine.Animator steam;
    private UIManager uiManager;
    private float time_;
    // Use this for initialization
    void Start()
    {
        uiManager = GameObject.Find("UILayer").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {

        //AnimatorStateInfo animatorInfo;
        //animatorInfo = fire.GetCurrentAnimatorStateInfo(0);  //要在update获取
        //if ((animatorInfo.normalizedTime > 1.0f) && (animatorInfo.IsName("fire")))//normalizedTime：0-1在播放、0开始、1结束 MyPlay为状态机动画的名字
        //{
        //    Destroy(steam);

        //}

        if (Input.GetMouseButtonUp(0))
        {
            flag = false;
        }
        if (!flag && Input.GetMouseButtonDown(0))
        {
            t_MouseDown = DateTime.Now;
            flag = true;
        }

        if (flag)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(ray);
            bool isHitWater = false;
            foreach (RaycastHit hit in hits)
            {
                //print("hit:" + hit.collider.name);
                if (hit.collider.tag == gameObject.tag)
                {
                    isHitWater = true;
                    GameObject boy = GameObject.Find("BoySprite");
                    time_ = Mathf.Abs(Vector3.Distance(boy.transform.position, hit.transform.position)) / 8;
                    break;
                }

            }

            if (isHitWater && !uiManager.isBtnShowing)
            {
                Invoke("StartFire", time_);
            }
        }
    }

    public void StartFire()
    {
        SpriteRenderer render = GetComponent<SpriteRenderer>();
        Sprite sprite = render.sprite;
        print("sprite.name " + sprite.name);
        if (sprite.name == trayWithWater.name)
        {
            steam.SetBool("IsSteam", true);
            Rigidbody rb = transform.gameObject.GetComponent<Rigidbody>();
            rb.mass = 1;
            GetComponent<SpriteRenderer>().sprite = trayWithoutWater;
            if (!hasPrompt && gameObject.name == "right board")
            {
                GameObject.Find("UILayer").GetComponentInChildren<BtnPromptController>(true).SwitchPromptFrom(2);
                hasPrompt = true;
            }
            else if (!hasPrompt && gameObject.name == "left board")
            {
                GameObject.Find("UILayer").GetComponentInChildren<BtnPromptController>(true).SwitchPromptFrom(3);
                hasPrompt = true;
            }
        }
    }
}
