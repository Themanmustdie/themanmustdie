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
    private bool enableMoving = true;
    private CameraManager cameraMgr;
    private Transform trGirl;

    public void EnableMoving()
    {
        enableMoving = true;
    }
    public void DisableMoving()
    {
        enableMoving = false;
    }


    private bool isAddForce = false;


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
        cameraMgr = GameObject.Find("EverySceneNeed").GetComponent<CameraManager>();
        trGirl = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!enableMoving)
        {
            return;
        }

        Vector2 move = Vector3.zero;

        if (isLeftBtnDown || isRightBtnDown)
        {
            move.x = isLeftBtnDown ? -1 : 1;
            isWalk = true;

            if (isLeftBtnDown)
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

        //charController.SimpleMove(move * speed * Time.deltaTime);
        //charController.Move(new Vector3(move.x * speed * Time.deltaTime, -1f, 0));
        actionController.SetBool("isWalk", isWalk);
        // 判断女孩在摄像机的位置
        float girlPosX = Camera.main.WorldToViewportPoint(trGirl.position).x;
        if ((girlPosX >= 0.01 || move.x > 0) && (girlPosX <= 0.99 || move.x < 0))
        {
            charController.SimpleMove(move * speed * Time.deltaTime);
            //charController.Move(new Vector3(move.x * speed * Time.deltaTime, -1f, 0));
        }
    }

    private void StopMoving()
    {
        Vector2 move = Vector2.left;
        charController.SimpleMove(move * Time.deltaTime);
        isLeftBtnDown = false;
        isRightBtnDown = false;
    }


    public void OnControllerColliderHit(ControllerColliderHit hit)
    {

        if (hit.gameObject.name == "wall")
        {
            Debug.Log(hit.gameObject.name);
            ShowTips("Tip1");
            StopMoving();
        }
        else if (hit.gameObject.name == "Book")
        {
            ShowBook();
            StopMoving();
        }
        else if (hit.gameObject.name == "Trestle")
        {
            if (!isAddForce)
            {
                float distance = Vector3.Distance(hit.transform.position, transform.position);
                if (distance < 7.3f)
                {
                    AddDownForce force_ = hit.gameObject.GetComponent<AddDownForce>();
                    force_.AddForce();
                    isAddForce = true;
                }
            }
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
        // 隐藏按钮
        GameObject.Find("UILayer").GetComponent<UIManager>().HideAllButtons();
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
        cameraMgr.BlurBackground(true);
        bookMaskPanel.SetActive(true);
        // 隐藏按钮
        GameObject.Find("UILayer").GetComponent<UIManager>().HideAllButtons();
    }
}
