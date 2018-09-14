using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroudMoveWithGirl : MonoBehaviour {
    public GameObject girl;
    public float lastX;
	// Use this for initialization
	void Start () {
        lastX = girl.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
        float x = girl.transform.position.x;
        float distance = x - lastX;
        if(Mathf.Abs(distance) > 0.05){
            Vector3 position_ = new Vector3(transform.position.x - distance * 2, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, position_, Mathf.Abs(distance));
        }
        lastX = x;
	}
}
