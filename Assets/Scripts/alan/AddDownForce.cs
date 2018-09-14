using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AddDownForce : MonoBehaviour {
    public GameObject pre;
    public bool IsFallIce = false;
    public GameObject Ice;
    public bool IsInstanPre = false;
    DateTime t_MouseDown;
	// Use this for initialization
	void Start () {
        t_MouseDown = DateTime.Now;
	}
	
	// Update is called once per frame
	void Update () {

	}



    public void AddForce(){
        if (!IsFallIce || Ice == null)
        {
            if (DateTime.Now - t_MouseDown > new TimeSpan(0, 0, 0, 3, 0))
            {
                GameObject clone = Instantiate(pre);
                Rigidbody rb = clone.GetComponent<Rigidbody>();
                rb.AddForce(new Vector3(0, -0.2f, 0), ForceMode.Impulse);
                IsInstanPre = true;
                t_MouseDown = DateTime.Now;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "IceRigth")
        {
            IsFallIce = true;
        }

    }
}
