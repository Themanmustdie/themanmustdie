using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FruitFireController : MonoBehaviour {

    public UnityEngine.Animator fire_;
    bool flag;
    DateTime t_MouseDown;
    private bool hasFinish = false;
    // Use this for initialization
    void Start()
    {
        fire_.SetBool("isFire", false);
        GameObject girl = GameObject.Find("Girl");
        foreach (Transform trChild in transform)
        {
            if (trChild.GetComponent<Collider>() != null)
            {
                foreach (Transform trChild2 in transform)
                {
                    if (trChild2.GetComponent<Collider>() != null)
                    {
                        Physics.IgnoreCollision(trChild.gameObject.GetComponent<Collider>(), trChild2.gameObject.GetComponent<Collider>());
                    }
                }
                Physics.IgnoreCollision(trChild.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(hasFinish)
        {
            return;
        }

        AnimatorStateInfo animatorInfo;
        animatorInfo = fire_.GetCurrentAnimatorStateInfo(0);  //要在update获取
        if ((animatorInfo.normalizedTime > 1.0f) && (animatorInfo.IsName("fire")))//normalizedTime：0-1在播放、0开始、1结束 MyPlay为状态机动画的名字
        {
            foreach(Transform tr in transform)
            {
                if (tr.gameObject.name == "Fire")
                {
                    Destroy(tr.gameObject);
                    DropFruits();
                    hasFinish = true;
                }
            }
           
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
            bool isHitIceRivets = false;
            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.gameObject.tag == gameObject.tag)
                    isHitIceRivets = true;
                if (hit.collider.gameObject.tag == "BoySprite")
                    isHitSprite = true;
            }

            if (isHitSprite && isHitIceRivets)
            {
                fire_.SetBool("isFire", true);
            }
        }
    }

    public void DropFruits()
    {
        foreach (Transform trChild in transform)
        {
            if (trChild.gameObject.name.StartsWith("Fruit"))
            {
                trChild.gameObject.GetComponent<Rigidbody>().useGravity = true;
                break;
            }

        }
    }
}
