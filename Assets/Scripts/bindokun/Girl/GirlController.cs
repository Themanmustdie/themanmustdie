using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GirlController : PhysicsObject
{

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private bool isLeftBtnDown = false;
    private bool isRightBtnDown = false;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //animator = GetComponent<Animator>();
    }

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


    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        if (isLeftBtnDown || isRightBtnDown)
            move.x = isLeftBtnDown ? -1 : 1;
        
        //if (Input.GetButtonDown("Jump") && grounded)
        //{
        //    velocity.y = jumpTakeOffSpeed;
        //}
        //else if (Input.GetButtonUp("Jump"))
        //{
        //    if (velocity.y > 0)
        //    {
        //        velocity.y = velocity.y * 0.5f;
        //    }
        //}

        if (move.x > 0.01f)
        {
            if (spriteRenderer.flipX == false)
            {
                spriteRenderer.flipX = true;
            }
        }
        else if (move.x < -0.01f)
        {
            if (spriteRenderer.flipX == true)
            {
                spriteRenderer.flipX = false;
            }
        }

        //animator.SetBool("grounded", grounded);
        //animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    }
}