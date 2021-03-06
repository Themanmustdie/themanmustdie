﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMeltAndCreateWater : MonoBehaviour
{

    public UnityEngine.Animator melt_;
    public UnityEngine.Animator fire_;
    public GameObject heavy;
    bool flag;
    DateTime t_MouseDown;
    private bool isInstan = false;
    public string AniName;
    public string Condition;
    private AudioSource dropWaterSound;
    public Sprite trayWithoutWater;
    public Sprite trayWithWater;

    private float time_;

    private SoundManager soundManager;
    private UIManager uiManager;
    // Use this for initialization
    void Start()
    {
        melt_.SetBool(Condition, false);
        fire_.SetBool("isFire", false);
        dropWaterSound = GetComponent<AudioSource>();
        soundManager = GameObject.Find("EverySceneNeed").GetComponent<SoundManager>();
        uiManager = GameObject.Find("UILayer").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo animatorInfo;
        animatorInfo = melt_.GetCurrentAnimatorStateInfo(0);  //要在update获取
        if ((animatorInfo.normalizedTime > 1.0f) && (animatorInfo.IsName(AniName)))//normalizedTime：0-1在播放、0开始、1结束 MyPlay为状态机动画的名字
        {
            Destroy(melt_);
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
                // print(hit.collider.name);
                if (hit.collider.gameObject.tag == gameObject.tag)
                {
                    isHitIceCube = true;
                    GameObject boy = GameObject.Find("BoySprite");
                    time_ = Mathf.Abs(Vector3.Distance(boy.transform.position, hit.transform.position)) / 8;
                    break;
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
        melt_.SetBool(Condition, true);
        fire_.SetBool("isFire", true);
        soundManager.PlaySound(dropWaterSound);
        if (!isInstan)
        {
            //GameObject water = (GameObject)Resources.Load(pre);
            //water = Instantiate(water, heavy.transform.position + new Vector3(0, 0.5f, 0), heavy.transform.rotation) as GameObject;
            //water.transform.parent = heavy.transform;
            SpriteRenderer reader = heavy.GetComponent<SpriteRenderer>();
            reader.sprite = trayWithWater;
            Rigidbody rb = heavy.GetComponent<Rigidbody>();
            rb.mass = 3;
            isInstan = true;
        }
    }
}
