using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{

    private Vector3 targetPos;
    private bool hasTrigger = false;
    public float moveSpeed = 5f;
    private Vector3 velocity = Vector3.zero;
    private Vector3 moveDir;

    // Use this for initialization
    void Start()
    {
        //Physics.IgnoreCollision(GetComponent<BoxCollider>(), GameObject.Find("BaffleForBigBall").GetComponent<MeshCollider>());
        //gameObject.transform.position = new Vector3(2.549f, 3.59f, 25.68f);
        Physics.IgnoreCollision(GetComponent<BoxCollider>(), GameObject.Find("Barrier1").GetComponent<BoxCollider>());
        //Physics.IgnoreCollision(GetComponent<BoxCollider>(), GameObject.Find("River").GetComponent<BoxCollider>());
        //Physics.IgnoreCollision(GetComponent<BoxCollider>(), GameObject.Find("Girl").GetComponent<CapsuleCollider>());
        
        moveDir = new Vector3(8.02f, -5.71f, 0.04f) - gameObject.transform.position;
    }

    public void MoveWhenBranchIsBurned()
    {
        //targetPos = new Vector3(7.29f, -2.96f, 0);
        //hasTrigger = true;
        GetComponent<Rigidbody>().AddForce(moveDir.normalized * moveSpeed, ForceMode.VelocityChange);
    }

    public void StoneIsInRiver()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hasTrigger)
        {
            //gameObject.transform.position = Vector3.SmoothDamp(gameObject.transform.position, targetPos, ref velocity, 3F);
            // GetComponent<Rigidbody>().AddForce(moveDir.normalized, ForceMode.VelocityChange);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Stone")
        {
            GetComponent<Rigidbody>().isKinematic = true;

            Physics.IgnoreCollision(GetComponent<BoxCollider>(), collision.gameObject.GetComponent<SphereCollider>());
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().AddForce(moveDir.normalized * moveSpeed, ForceMode.VelocityChange);
            GetComponent<Rigidbody>().drag = 3;
        }
        //else if (collision.gameObject.name == "Girl")
        //{
        //    GetComponent<Rigidbody>().isKinematic = true;
        //    GetComponent<Rigidbody>().isKinematic = false;
        //    GetComponent<Rigidbody>().AddForce(moveDir.normalized * moveSpeed, ForceMode.VelocityChange);
        //}
    }

    //private void OnCollisionStay(Collision collision)
    //{
    //    if (collision.gameObject.name == "Girl")
    //    {
    //        GetComponent<Rigidbody>().isKinematic = true;
    //        GetComponent<Rigidbody>().isKinematic = false;
    //        GetComponent<Rigidbody>().AddForce(moveDir.normalized * moveSpeed, ForceMode.VelocityChange);
    //    }
    //}
}
