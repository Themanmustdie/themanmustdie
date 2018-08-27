using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{


    public GameObject girlObj;
    public float cameraMoveSpeed = 10;
    private Transform grilTransform;
    private Transform cameraTransform;
    // Use this for initialization
    void Start()
    {

        grilTransform = girlObj.GetComponent<Transform>();
        cameraTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        Vector3 girlViewPortPos = Camera.main.WorldToViewportPoint(grilTransform.position);

        Vector3 moveDir = Vector3.zero;

        if (girlViewPortPos.x < 0.33 && cameraTransform.position.x > 0)
        {
            moveDir.x = -1;
        }
        else if (girlViewPortPos.x > 0.66)
        {
            moveDir.x = 1;
        }
        if (girlViewPortPos.y > 0.5)
        {
            moveDir.y = 1;
        }
        else if (girlViewPortPos.y < 0.3)
        {
            moveDir.y = -1;
        }
        cameraTransform.Translate(moveDir.normalized * cameraMoveSpeed * Time.deltaTime);
    }
}
