using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddDownForce : MonoBehaviour {
    public GameObject pre;
    public GameObject girl;
    public bool IsFallIce = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(girl.transform.position, transform.position);
        print(distance);
	}



    public void AddForce(){
        if (!IsFallIce)
        {
            GameObject clone = Instantiate(pre);
            Rigidbody rb = clone.GetComponent<Rigidbody>();
            rb.AddForce(new Vector3(0, -290, 0), ForceMode.Impulse);
            //Destroy(clone, 0.5f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "ice cube")
        {
            IsFallIce = true;
        }

    }
}
