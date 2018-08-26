using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsBegin : MonoBehaviour {
    public bool begin;
    MeshMelt meshMelt;
	// Use this for initialization
	void Start () {
        meshMelt = GetComponent<MeshMelt>();
	}
	
	// Update is called once per frame
	void Update () {
        if (begin)
        {
            meshMelt.BeginMelt();
            begin = false;
        }
	}
}
