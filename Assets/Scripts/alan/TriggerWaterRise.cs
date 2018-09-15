using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWaterRise : MonoBehaviour {
    public UnityEngine.Animator waterRise;
    //public UnityEngine.Animator waterRise2;
    public UnityEngine.Animator waterdrop;
    public GameObject raiseWater;
    public GameObject baffle;
    public GameObject roll;
	// Use this for initialization
	void Start () {
        waterRise.SetBool("IsRaise", false);
        waterdrop.SetBool("IsDrop", false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "board")
        {
            waterRise.SetBool("IsRaise", true);
            waterdrop.SetBool("IsDrop", true);
            if (raiseWater != null)
            {
                Destroy(raiseWater);
            }
        }

    }
}
