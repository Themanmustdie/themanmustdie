﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMelt : MonoBehaviour
{

    public UnityEngine.Animator melt_;
    public UnityEngine.Animator fire_;
    public AudioSource burnSound;
    private SoundManager soundManager;
    bool flag;
    DateTime t_MouseDown;
    private UIManager uiManager;
    private float time_;
    // Use this for initialization
    void Start()
    {
        melt_.SetBool("IsMelt", false);
        fire_.SetBool("isFire", false);
        uiManager = GameObject.Find("UILayer").GetComponent<UIManager>();
        soundManager = GameObject.Find("EverySceneNeed").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo animatorInfo;
        animatorInfo = melt_.GetCurrentAnimatorStateInfo(0);  //要在update获取
        if ((animatorInfo.normalizedTime > 1.0f) && (animatorInfo.IsName("icemelt") || animatorInfo.IsName("icemelt2")))//normalizedTime：0-1在播放、0开始、1结束 MyPlay为状态机动画的名字
        {
            Destroy(gameObject);
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
            bool isHitIceCube = false;
            foreach (RaycastHit hit in hits)
            {
                foreach (Transform child in gameObject.transform)
                {
                    if (hit.collider.gameObject.tag == gameObject.tag)
                    {
                        isHitIceCube = true;
                        GameObject boy = GameObject.Find("BoySprite");
                        time_ = Mathf.Abs(Vector3.Distance(boy.transform.position, hit.transform.position)) / 8;
                        break;
                    }
                }
            }

            if (isHitIceCube && !uiManager.isBtnShowing)
            {
                Invoke("StartFire", time_);
            }
        }
    }

    public void StartFire()
    {
        melt_.SetBool("IsMelt", true);
        fire_.SetBool("isFire", true);
        soundManager.PlaySound(burnSound);
    }
}
