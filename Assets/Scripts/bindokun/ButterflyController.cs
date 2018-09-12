using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

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
    // Use this for initialization

    void Start()
    {
        trButterfly = GetComponent<Transform>();
        startTime = Time.time;
    }



    // Update is called once per frame

    void Update()
    {
        if(trButterfly.localPosition.x > targetLocalXpos)
        {
            gameObject.SetActive(false);
            GameObject.Find("EverySceneNeed").GetComponent<CameraManager>().ChangeTarget(girl);

            girl.GetComponent<NewGrilController>().EnableMoving();
            boySprite.GetComponent<SpriteController>().EnableMoving();
            // 显示按钮
            GameObject.Find("UILayer").GetComponent<UIManager>().ShowCommonButtons();
        }
        else
        {
            trButterfly.position = new Vector3(trButterfly.position.x + speed * Time.deltaTime, anim.Evaluate((Time.time - startTime) * speed), 0);
        }
    }
}
