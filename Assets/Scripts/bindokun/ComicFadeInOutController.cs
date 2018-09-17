using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComicFadeInOutController : MonoBehaviour {

    public float fadeInDuration = 1;
    public float fadeOutDuration = 1;
    // Use this for initialization
    void Start () {
        Animation ani = gameObject.AddComponent<Animation>();
        AnimationClip clip = new AnimationClip();
        gameObject.GetComponent<Image>();
        clip.SetCurve("", typeof(Image), "Color.a", AnimationCurve.EaseInOut(0, 0, fadeInDuration, 1));
        //ani.AddClip()
        ani.AddClip(clip, "Start");
       // ani.Play("Start");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
