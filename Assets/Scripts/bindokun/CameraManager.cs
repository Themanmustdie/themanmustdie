﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class CameraManager : MonoBehaviour
{

    public float sceneLeftBound;
    public float sceneRightBound;

    public bool isLockTarget = true;

    private GameObject mainCamera;
    private GameObject characterCamera;
    private GameObject lastTarget;

    public void ChangeTarget(GameObject target)
    {
        if (target == null)
        {
            mainCamera.GetComponent<SmoothFollow>().target = null;
            characterCamera.GetComponent<SmoothFollow>().target = null;
        }
        else
        {
            mainCamera.GetComponent<SmoothFollow>().target = target.transform;
            characterCamera.GetComponent<SmoothFollow>().target = target.transform;
            lastTarget = target;
        }

    }

    public void BlurBackground(bool isBlur)
    {
        mainCamera.GetComponent<ImageEffect_GaussianBlur>().enabled = isBlur;
        characterCamera.GetComponent<ImageEffect_GaussianBlur>().enabled = isBlur;
    }

    // Use this for initialization
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        characterCamera = GameObject.Find("CharacterCamera");

        mainCamera.AddComponent<ImageEffect_GaussianBlur>().enabled = false;
        characterCamera.AddComponent<ImageEffect_GaussianBlur>().enabled = false;
        if(isLockTarget)
        {
            lastTarget = GameObject.Find("Girl");
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if(lastTarget == null)
        {
            return;
        }

        float cameraLeftBound = Camera.main.ViewportToWorldPoint(Vector3.zero).x;
        float cameraRightBound = Camera.main.ViewportToWorldPoint(Vector3.one).x;
        float lastTargetPosX = 0;
        lastTargetPosX = Camera.main.WorldToViewportPoint(lastTarget.transform.position).x;

        if (cameraLeftBound < sceneLeftBound)
        {
            ChangeTarget(null);
            if (lastTargetPosX > 0.5)
            {
                ChangeTarget(lastTarget);
            }
        }
        else if (cameraRightBound > sceneRightBound)
        {
            ChangeTarget(null);
            if (lastTargetPosX < 0.5)
            {
                ChangeTarget(lastTarget);
            }
        }
        else
        {
            ChangeTarget(lastTarget);
        }
    }
}
