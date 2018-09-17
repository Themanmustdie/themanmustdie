using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaffleController : MonoBehaviour {

    private SoundManager soundManager;
    private AudioSource hitSound;
	// Use this for initialization
	void Start () {
        soundManager = GameObject.Find("EverySceneNeed").GetComponent<SoundManager>();
        hitSound = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "water level raise left")
        {
            soundManager.PlaySound(hitSound);
        }
    }
}
