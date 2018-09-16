using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkyTouchController : MonoBehaviour
{
    private Vector3 mouseDownPos;
    public SpriteController spriteController;
    public GameObject spriteMotionMaskPanel;
     

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject() || Input.touchCount > 0 && EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
        {
            return;
        }
        
        
        if (Input.GetMouseButtonDown(0))
        {
            mouseDownPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseDownPos.z = 0;
        }

        if (Input.GetMouseButtonUp(0))
        {
           
            Vector3 mouseUpPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseUpPos.z = 0;

            float clickDist = (mouseUpPos - mouseDownPos).magnitude;
            if (clickDist < 0.3)
            {
                spriteController.ChangeState(SpriteState.NormalMoveState, mouseUpPos);
                spriteMotionMaskPanel.SetActive(true);
            }
        }
    }
}
