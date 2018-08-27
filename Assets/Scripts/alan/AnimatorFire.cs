using System;
using UnityEngine;

public class AnimatorFire : MonoBehaviour
{
    public UnityEngine.Animator animator_;
    bool flag;
    DateTime t_MouseDown;
    public GameObject rope;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) || rope == null)
        {
            flag = false;
            animator_.SetBool("isFire", false);
        }
        if (!flag && Input.GetMouseButtonDown(0))
        {
            t_MouseDown = DateTime.Now;
            flag = true;
        }

        if (flag && DateTime.Now - t_MouseDown > new TimeSpan(0, 0, 0, 1, 0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "rope")
                {
                    animator_.SetBool("isFire", true);
                }
            }
        }
    }

}
