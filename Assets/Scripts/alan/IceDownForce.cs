using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceDownForce : MonoBehaviour
{
    public GameObject rope;
    private bool isAddForce = false;
    private AudioSource hitSound;
    // Use this for initialization
    void Start()
    {
        hitSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAddForce)
        {
            if (rope == null)
            {
                Rigidbody rb = GetComponent<Rigidbody>();
                rb.AddForce(new Vector3(0, -3, 0), ForceMode.Impulse);
                isAddForce = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Trestle")
        {
            hitSound.Play();
        }
        else if (collision.collider.name == "Baffle left")
        {
            hitSound.Play();
        }
        else if (collision.collider.name == "Baffle right")
        {
            hitSound.Play();
        }
    }
}
