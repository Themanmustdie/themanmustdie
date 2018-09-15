using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    
    private Dictionary<AudioSource, float> soundTimeMap = new Dictionary<AudioSource, float>();
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    public void PlaySound(AudioSource sound)
    {
        Debug.Log(Time.time);
        if (soundTimeMap.ContainsKey(sound))
        {
            float hasPlayTime = Time.time - soundTimeMap[sound];
            if(hasPlayTime > 2)
            {
                sound.Play();
            }
            soundTimeMap[sound] = Time.time;
        }
        else
        {
            sound.Play();
            soundTimeMap.Add(sound, Time.time);
        }
    }
}
