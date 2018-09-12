using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMeltAndCreateWater : MonoBehaviour {

    public UnityEngine.Animator melt_;
    public UnityEngine.Animator fire_;
    public GameObject heavy;
    bool flag;
    DateTime t_MouseDown;
    private bool isInstan = false;
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

        if (flag && DateTime.Now - t_MouseDown > new TimeSpan(0, 0, 0, 2, 0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(ray);
            bool isHitSprite = false;
            bool isHitIceCube = false;
            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.gameObject.tag == "ice cube")
                    isHitIceCube = true;
                if (hit.collider.gameObject.tag == "BoySprite")
                    isHitSprite = true;
            }

            if (isHitSprite && isHitIceCube)
            {
                melt_.SetBool("IsMelt", true);
                fire_.SetBool("isFire", true);
                if (flag && DateTime.Now - t_MouseDown > new TimeSpan(0, 0, 0, 1, 0))
                {
                    if (!isInstan)
                    {
                        GameObject water = (GameObject)Resources.Load("water");
                        water = Instantiate(water, heavy.transform.position + new Vector3(0, 0.49f, 0), heavy.transform.rotation) as GameObject;
                        water.transform.parent = heavy.transform;
                        isInstan = true;
                    }
                }
            }
        }
    }
}
