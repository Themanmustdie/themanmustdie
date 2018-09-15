using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceDownForce : MonoBehaviour
{
    public GameObject rope;
    private bool isAddForce = false;
    private AudioSource hitSound;
    private SoundManager soundManager;
    // Use this for initialization
    void Start()
    {
        hitSound = GetComponent<AudioSource>();
        soundManager = new SoundManager();
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
            soundManager.PlaySound(hitSound);
        }
        else if (collision.collider.name == "Baffle left")
        {
            soundManager.PlaySound(hitSound);
        }
        else if (collision.collider.name == "Baffle right")
        {
            soundManager.PlaySound(hitSound);
        }
    }
}
