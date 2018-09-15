using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneController : MonoBehaviour
{

    private AudioSource dropWaterSound;
    private AudioSource appleHitSound;
    private SoundManager soundManager;
    // Use this for initialization
    void Start()
    {
        dropWaterSound = GetComponents<AudioSource>()[0];
        appleHitSound = GetComponents<AudioSource>()[1];
        soundManager = GameObject.Find("EverySceneNeed").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "River")
        {
            soundManager.PlaySound(dropWaterSound);
            GameObject.Find("Barrier2").GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
        else if (collision.collider.name.StartsWith("Fruit"))
        {
            soundManager.PlaySound(appleHitSound);
        }
    }
}
