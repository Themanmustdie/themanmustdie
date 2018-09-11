using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SpriteState
{
    NormalMoveState, DragState, IdleState
}

interface ISpriteState
{
    void Move();
    void Reset();
}


class IdleState : ISpriteState
{
    private SpriteController spirteCtrl;
    private float stayAloneTime;
    private Transform spriteTr;
    private Transform girlTr;
    private float timethreshold;

    public IdleState(Transform spriteTr, Transform girlTr, SpriteController spirteCtrl)
    {
        this.spriteTr = spriteTr;
        this.girlTr = girlTr;
        this.spirteCtrl = spirteCtrl;
        stayAloneTime = 0;

        timethreshold = 1.0f;
        string strVal = ConfigManager.GetInstance.GetPara("commom-SpriteStayAloneDelay");
        Debug.Log("stayAloneTime: " + strVal);
        if (strVal != "")
        {
            timethreshold = float.Parse(strVal);
        }

    }

    public void Move()
    {
        Vector3 moveDir = girlTr.position - spriteTr.position;
        if (moveDir.magnitude > 1.2)
        {
            stayAloneTime += Time.deltaTime;
        }
        else
        {
            stayAloneTime = 0;
        }
        if (timethreshold < stayAloneTime)
        {
            spriteTr.Translate(moveDir.normalized * spirteCtrl.moveSpeed * Time.deltaTime, Space.World);
        }

    }

    public void Reset()
    {
        stayAloneTime = 0;
    }
}

class NormalMoveState : ISpriteState
{
    private SpriteController spirteCtrl;
    private Transform spriteTr;

    public NormalMoveState(SpriteController spirteCtrl, Transform spriteTr)
    {
        this.spirteCtrl = spirteCtrl;
        this.spriteTr = spriteTr;
    }

    public void Move()
    {
        Vector3 originPos = spriteTr.position;
        originPos.z = 0;

        spirteCtrl.targetPos.z = 0;
        Vector3 moveDir = spirteCtrl.targetPos - originPos;
        if (moveDir.magnitude > 0.05)
        {
            spriteTr.Translate(moveDir.normalized * spirteCtrl.moveSpeed * Time.deltaTime, Space.World);
        }
        else
        {
            spirteCtrl.ChangeState(SpriteState.IdleState);
        }
    }

    public void Reset()
    {
        // mouseDownPos = spriteTr.position;
    }
}

class DragState : ISpriteState
{
    private Transform spriteTr;

    public DragState(Transform spriteTr)
    {
        this.spriteTr = spriteTr;
    }

    public void Move()
    {

        Vector3 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos.z = spriteTr.position.z;
        spriteTr.position = targetPos;
    }

    public void Reset()
    {

    }
}

public class SpriteController : MonoBehaviour
{

    private Transform tr;
    public Vector3 targetPos;
    public float moveSpeed = 3.0f;
    public GameObject girl;

    private Dictionary<SpriteState, ISpriteState> stateMap;
    private SpriteState state;

    // Use this for initialization
    void Start()
    {
        tr = GetComponent<Transform>();
        targetPos = tr.position;
        stateMap = new Dictionary<SpriteState, ISpriteState>();
        // State map
        stateMap.Add(SpriteState.IdleState, new IdleState(tr, girl.GetComponent<Transform>(), this));
        stateMap.Add(SpriteState.NormalMoveState, new NormalMoveState(this, tr));
        stateMap.Add(SpriteState.DragState, new DragState(tr));
        state = SpriteState.NormalMoveState;


    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        stateMap[state].Move();
    }

    public void OnMouseDrag()
    {
        state = SpriteState.DragState;
    }
    private void OnMouseUp()
    {
        state = SpriteState.IdleState;
    }

    public void ChangeState(SpriteState state)
    {
        stateMap[state].Reset();
        this.state = state;
    }
}
