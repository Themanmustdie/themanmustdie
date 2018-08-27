using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGrilController : MonoBehaviour
{
    public float speed = 30f;
    private CharacterController charController;
    private bool isLeftBtnDown = false;
    private bool isRightBtnDown = false;
   
    public void OnLeftBtnDown()
    {
        if (!isRightBtnDown)
            isLeftBtnDown = true;
    }

    public void OnLeftBtnUp()
    {
        isLeftBtnDown = false;
    }

    public void OnRightBtnDown()
    {
        if (!isLeftBtnDown)
            isRightBtnDown = true;

    }

    public void OnRightBtnUp()
    {
        isRightBtnDown = false;
    }

    // Use this for initialization
    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = Vector3.zero;

        if (isLeftBtnDown || isRightBtnDown)
            move.x = isLeftBtnDown ? -1 : 1;
        

        charController.SimpleMove(move * speed * Time.deltaTime);
    }
}
