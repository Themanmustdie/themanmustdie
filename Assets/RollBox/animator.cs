using System;
using UnityEngine;

public class Animator : MonoBehaviour
{
    public UnityEngine.Animator animator_;
    bool flag;
    DateTime t_MouseDown;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!flag && Input.GetMouseButtonDown(0))
        {
            t_MouseDown = DateTime.Now;
            flag = true;
        }

        if (flag && DateTime.Now - t_MouseDown > new TimeSpan(0, 0, 0, 1, 0))
        {
            animator_.SetBool("isFire", true);
        }

        if (Input.GetMouseButtonUp(0))
        {
            flag = false;
            animator_.SetBool("isFire", false);
        }
    }

}
