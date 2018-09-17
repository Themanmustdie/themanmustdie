using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComicFinishCallBack : MonoBehaviour {

    private NewComicController comicCtrl;
	// Use this for initialization
	void Start () {
        comicCtrl = GameObject.Find("PromptUILayer").GetComponentInChildren<NewComicController>(true);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnComicFinish()
    {
        comicCtrl.OnComicFinish();
    }
}
