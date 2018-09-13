﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMeltCondition : MonoBehaviour
{
    
    public UnityEngine.Animator melt_;
    public UnityEngine.Animator fire_;
    bool flag;
    DateTime t_MouseDown;
    public GameObject roll;
    // Use this for initialization
    void Start()
    {
        melt_.SetBool("IsMelt", false);
        fire_.SetBool("isFire", false);
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo animatorInfo;
        animatorInfo = melt_.GetCurrentAnimatorStateInfo(0);  //要在update获取
        if ((animatorInfo.normalizedTime > 1.0f) && (animatorInfo.IsName("icemelt")))//normalizedTime：0-1在播放、0开始、1结束 MyPlay为状态机动画的名字
        {
            Destroy(gameObject);
        }
        if ((animatorInfo.normalizedTime > 1.0f) && (animatorInfo.IsName("onlymelt")))//normalizedTime：0-1在播放、0开始、1结束 MyPlay为状态机动画的名字
        {
            fire_.SetBool("isFire", false);
        }
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
            bool isHitSprite = false;
            bool isHitIceCube = false;
            foreach (RaycastHit hit in hits)
            {
                foreach (Transform child in gameObject.transform)
                {
                    if (hit.collider.gameObject.tag == "ice cube")
                        isHitIceCube = true;
                }
                if (hit.collider.gameObject.tag == "BoySprite")
                    isHitSprite = true;
            }

            if (isHitSprite && isHitIceCube)
            {
                fire_.SetBool("isFire", true);
                if (roll != null)
                {
                    melt_.SetBool("IsMelt", true);
                }
                else {
                    melt_.SetBool("IsOnlyMelt", true);
                }
            }
        }
    }
}
