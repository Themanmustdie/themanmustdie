using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRise : MonoBehaviour {
    public UnityEngine.Animator waterRise;
    public UnityEngine.Animator melt_;
    public bool isLeft;
    public GameObject rope;
    // Use this for initialization
    void Start () {
        waterRise.SetBool("IsRaise", false);
    }
	
	// Update is called once per frame
	void Update () {
        AnimatorStateInfo animatorInfo;
        if (melt_ != null)
        {
            animatorInfo = melt_.GetCurrentAnimatorStateInfo(0);
            if ((animatorInfo.normalizedTime < 1.0f) && (animatorInfo.normalizedTime > 0.0f) && (animatorInfo.IsName("4-melt")))//normalizedTime：0-1在播放、0开始、1结束 MyPlay为状态机动画的名字
            {
                if (isLeft)
                {
                    if (rope == null)
                    {
                        waterRise.SetBool("IsRaise", true);
                    }

                }else{
                    waterRise.SetBool("IsRaise", true);
                }
            }
        }
    }
}
