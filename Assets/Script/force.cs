using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class force : MonoBehaviour {
    public GameObject rope;
    bool flag = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(rope == null){
            gameObject.AddComponent<Rigidbody>();
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "floor"){
            this.GetComponent<Rigidbody>().AddForce(Vector3.right * 100);
        }
    }

}
