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
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "rope")
                {
                    var enemies = GameObject.FindGameObjectsWithTag("rope");
                    foreach (GameObject enemy in enemies)
                        Destroy(enemy);
                }
            }

        }
        if (Input.GetMouseButtonUp(0))
        {
            flag = false;
        }
    }

}
