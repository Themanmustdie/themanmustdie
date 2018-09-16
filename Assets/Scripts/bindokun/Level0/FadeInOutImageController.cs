using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOutImageController : MonoBehaviour {

    public GameObject nextImg;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnAnimationFinish()
    {
        if(nextImg!=null)
        {
            nextImg.SetActive(true);
        }
        Destroy(gameObject);
    }
}
