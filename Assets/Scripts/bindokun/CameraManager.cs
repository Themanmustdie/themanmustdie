using System.Collections;
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

    private float velocity = 0;

    public void ChangeTarget(GameObject target)
    {
        if (target != null)
        {
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
        if (isLockTarget)
        {
            lastTarget = GameObject.Find("Girl");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (lastTarget == null)
        {
            return;
        }

        UpdateLocation();


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


    private void UpdateLocation()
    {
        float cameraTargetX = Mathf.SmoothDamp(mainCamera.transform.position.x, lastTarget.transform.position.x, ref velocity, 0.3f);
        float cameraTargetY = mainCamera.transform.position.y;
        float cameraTargetZ = mainCamera.transform.position.z;
        mainCamera.transform.position = new Vector3(cameraTargetX, cameraTargetY, cameraTargetZ);
        characterCamera.transform.position = new Vector3(cameraTargetX, cameraTargetY, cameraTargetZ);
    }
}
