using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGrilController : MonoBehaviour
{
    public float speed = 30f;
    private CharacterController charController;
    private bool isLeftBtnDown = false;
    private bool isRightBtnDown = false;
    private SpriteRenderer spriteRender;

    public GameObject tipMaskPanel;
    public GameObject bookMaskPanel;

    private Animator actionController;
    public bool isWalk;
    

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
        actionController = GetComponent<Animator>();
        isWalk = false;
        spriteRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = Vector3.zero;

        if (isLeftBtnDown || isRightBtnDown)
        {
            move.x = isLeftBtnDown ? -1 : 1;
            isWalk = true;

            if(isLeftBtnDown)
            {
                spriteRender.flipX = true;
            }
            else
            {
                spriteRender.flipX = false;
            }
        }
        else
        {
            isWalk = false;
        }
           
        charController.SimpleMove(move * speed * Time.deltaTime);
        actionController.SetBool("isWalk", isWalk);
    }

    private void StopMoving()
    {
        isLeftBtnDown = false;
        isRightBtnDown = false;
    }


    public void OnControllerColliderHit(ControllerColliderHit hit)
    {

        if (hit.gameObject.name == "wall")
        {
            ShowTips("Tip1");
            StopMoving();
        }
        else if (hit.gameObject.name == "Book")
        {
            ShowBook();
            StopMoving();
        }
       
    }

    private void ShowTips(string tipName)
    {
        foreach (Transform child in tipMaskPanel.transform)
        {
            if (child.gameObject.name == tipName)
            {
                child.gameObject.SetActive(true);
            }
            else
            {
                child.gameObject.SetActive(false);
            }
        }
        tipMaskPanel.SetActive(true);
    }

    private void ShowBook()
    {
        foreach (Transform transform in bookMaskPanel.GetComponentInChildren<Transform>())
        {
            if (transform.gameObject.name == "BookCover")
            {
                transform.gameObject.SetActive(true);
            }
            else
            {
                transform.gameObject.SetActive(false);
            }
        }
        bookMaskPanel.SetActive(true);
    }
}
