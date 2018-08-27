using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkyTouchController : MonoBehaviour
{
    private Vector3 mouseDownPos;
    public SpriteController spriteController;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown()
    {
        mouseDownPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseDownPos.z = 0;
    }

    public void OnMouseUp()
    {

        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        Vector3 mouseUpPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseUpPos.z = 0;
        
        float clickDist = (mouseUpPos - mouseDownPos).magnitude;
        if (clickDist < 0.3)
        {
            spriteController.targetPos = mouseUpPos;
            spriteController.ChangeState(SpriteState.NormalMoveState);
        }
        
    }
}
