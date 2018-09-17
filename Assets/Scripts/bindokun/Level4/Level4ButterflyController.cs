using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4ButterflyController : MonoBehaviour
{

    public float speed = 2.0f;
    //曲线
    public AnimationCurve anim;
    private Transform trButterfly;
    private float startTime;
    private GameObject boySprite;
    private GameObject girl;
    public float targetLocalXpos;
    private bool isToMove = false;
    private ButterflyController originCtrl;
    private bool isEnterRoom = false;
    public GameObject comicPanel;
    // Use this for initialization
    void Start()
    {
        trButterfly = GetComponent<Transform>();
        boySprite = GameObject.Find("BoySprite");
        girl = GameObject.Find("Girl");
        originCtrl = GetComponent<ButterflyController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isToMove)
        {
            if (trButterfly.localPosition.x < targetLocalXpos)
            {
                isToMove = false;
            }
            else
            {
                trButterfly.position = new Vector3(trButterfly.position.x - speed * Time.deltaTime, anim.Evaluate((Time.time - startTime) * speed), 0);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Girl" && originCtrl.isFinish)
        {
            startTime = Time.time;
            isToMove = true;
            GetComponent<SpriteRenderer>().flipX = true;

        }
        if (other.gameObject.name == "Girl" && isEnterRoom)
        {

        }

    }

    public void GetIntoRoom()
    {
        Animation fadeAni = gameObject.AddComponent<Animation>();
        AnimationClip clip = new AnimationClip();
        clip.legacy = true;
        clip.SetCurve("", typeof(Material), "_Color.a", AnimationCurve.EaseInOut(0, 1, 1, 0));
        fadeAni.AddClip(clip, "fadeOut");
        fadeAni.Play("fadeOut");
        isEnterRoom = true;

        Memory1Trigger trigger = gameObject.AddComponent<Memory1Trigger>();
        trigger.comicPanel = comicPanel;
    }
}
