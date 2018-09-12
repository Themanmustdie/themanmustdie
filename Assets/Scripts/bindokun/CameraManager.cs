using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class CameraManager : MonoBehaviour {

    private GameObject mainCamera;
    private GameObject characterCamera;

    public void ChangeTarget(GameObject target)
    {
        mainCamera.GetComponent<SmoothFollow>().target = target.transform;
        characterCamera.GetComponent<SmoothFollow>().target = target.transform;
    }

    public void BlurBackground(bool isBlur)
    {
        mainCamera.GetComponent<BlurBackground>().enabled = isBlur;
        characterCamera.GetComponent<BlurBackground>().enabled = isBlur;
    }

    // Use this for initialization
    void Start () {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        characterCamera = GameObject.Find("CharacterCamera");

        mainCamera.AddComponent<BlurBackground>().enabled = false;
        characterCamera.AddComponent<BlurBackground>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
