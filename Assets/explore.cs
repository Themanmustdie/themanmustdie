using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explore : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        Transform[] items = GetComponentsInChildren<Transform>();
        foreach (Transform child in items)
        {
            BoxCollider collider = child.GetComponent<BoxCollider>();
            collider.attachedRigidbody.AddExplosionForce(300f, -transform.position, 100, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}