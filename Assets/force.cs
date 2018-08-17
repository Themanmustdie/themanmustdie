using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class force : MonoBehaviour {

    bool flag = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!flag)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(500.0f, -100.0f, 0f);
            flag = true;
        }
    }

}
