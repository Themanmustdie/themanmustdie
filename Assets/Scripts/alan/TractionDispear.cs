using System;
using UnityEngine;

public class TractionDispear : MonoBehaviour
{
    public GameObject cam;
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

        if (flag && DateTime.Now - t_MouseDown > new TimeSpan(0, 0, 0, 2, 0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(ray);
            bool isHitBoySprite = false;
            bool isHitRope = false;

            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.tag == "rope")
                    isHitRope = true;
                else if (hit.collider.tag == "BoySprite")
                    isHitBoySprite = true;
            }
            if(isHitBoySprite && isHitRope)
            {
                var enemies = GameObject.FindGameObjectsWithTag("rope");
                foreach (GameObject enemy in enemies)
                    Destroy(enemy);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            flag = false;
        }
    }

}
