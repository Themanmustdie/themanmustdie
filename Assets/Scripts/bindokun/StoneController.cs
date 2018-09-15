using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneController : MonoBehaviour {

    private AudioSource dropWaterSound;
    private AudioSource appleHitSound;

	// Use this for initialization
	void Start () {
        dropWaterSound = GetComponents<AudioSource>()[0];
        appleHitSound = GetComponents<AudioSource>()[1];
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "River")
        {
            dropWaterSound.Play();
        }else if(collision.collider.name.StartsWith("Fruit"))
        {
            appleHitSound.Play();
        }
    }
}
