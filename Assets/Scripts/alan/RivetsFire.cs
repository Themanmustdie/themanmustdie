using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RivetsFire : MonoBehaviour
{

    public UnityEngine.Animator fire_;
    bool flag;
    DateTime t_MouseDown;
    private bool hasFinish = false;
    private float time_;
    // Use this for initialization
    void Start()
    {
        fire_.SetBool("isFire", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (hasFinish)
        {
            return;
        }
        
        AnimatorStateInfo animatorInfo;
        animatorInfo = fire_.GetCurrentAnimatorStateInfo(0);  //要在update获取
        if ((animatorInfo.normalizedTime > 1.0f) && (animatorInfo.IsName("fire")))//normalizedTime：0-1在播放、0开始、1结束 MyPlay为状态机动画的名字
        {;
            Destroy(gameObject);
            Destroy(fire_.gameObject);
            hasFinish = true;
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
                //print(hit.collider.name);
                if (hit.collider.gameObject.tag == gameObject.tag)
                {
                    isHitIceRivets = true;
                    GameObject boy = GameObject.Find("BoySprite");
                    time_ = Mathf.Abs(Vector3.Distance(boy.transform.position, hit.transform.position)) / 8;
                    break;
                }
               
            }

            if (isHitIceRivets)
            {
                Invoke("StartFire", time_);
            }
            isHitIceRivets = false;
        }
    }

    public void StartFire()
    {
        fire_.SetBool("isFire", true);
    }
}
