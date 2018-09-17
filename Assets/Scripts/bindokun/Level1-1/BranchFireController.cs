using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BranchFireController : MonoBehaviour
{

    private bool hasBurned = false;
    private GameObject barrier;

    public UnityEngine.Animator fire_;
    bool flag;
    DateTime t_MouseDown;
    private bool hasFinish = false;

    private float time_;
    private UIManager uiManager;
    private SoundManager soundManager;
    // Use this for initialization
    void Start()
    {
        fire_.SetBool("isFire", false);
        barrier = GameObject.Find("Barrier2");
        uiManager = GameObject.Find("UILayer").GetComponent<UIManager>();
        soundManager = GameObject.Find("EverySceneNeed").GetComponent<SoundManager>(); 
    }

    // Update is called once per frame
    void Update()
    {

        AnimatorStateInfo animatorInfo;
        animatorInfo = fire_.GetCurrentAnimatorStateInfo(0);  //要在update获取
        if ((animatorInfo.normalizedTime > 1.0f) && (animatorInfo.IsName("fire")))//normalizedTime：0-1在播放、0开始、1结束 MyPlay为状态机动画的名字
        {
            ReleaseIce();
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
            bool isHitIceRivets = false;
            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.gameObject.tag == gameObject.tag)
                {
                    isHitIceRivets = true;
                    GameObject boy = GameObject.Find("BoySprite");
                    time_ = Mathf.Abs(Vector3.Distance(boy.transform.position, hit.transform.position)) / 8;
                    break;
                }
            }
            if (isHitIceRivets && !uiManager.isBtnShowing)
            {
                Invoke("StartFire", time_);
            }
        }
    }

    public void StartFire()
    {
        fire_.SetBool("isFire", true);
        soundManager.PlaySound(GetComponent<AudioSource>());
        GameObject.Find("UILayer").GetComponentInChildren<BtnPromptController>(true).SwitchPromptFrom(1);
    }


    public void ReleaseIce()
    {
        barrier.GetComponent<BoatController>().MoveWhenBranchIsBurned();
    }
}
