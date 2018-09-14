using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour {
    private float spriteStayTime;
    private bool hasBurned = false;
    public float timethreshold = 2F;
    // Use this for initialization
    void Start()
    {
       
        foreach (Transform tr in transform.parent.gameObject.transform)
        {
            Physics.IgnoreCollision(tr.gameObject.GetComponent<SphereCollider>(), GetComponent<SphereCollider>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasBurned)
        {
            bool isHitBranch = false;
            bool isHitSprite = false;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(ray);
            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.gameObject.name == gameObject.name)
                {
                    isHitBranch = true;
                }
                else if (hit.collider.gameObject.name == "BoySprite")
                {
                    isHitSprite = true;
                }
            }
            if (isHitBranch && isHitSprite)
            {
                spriteStayTime += Time.deltaTime;
            }
            else
            {
                spriteStayTime = 0;
            }
            if (spriteStayTime > timethreshold)
            {
                hasBurned = true;
                GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }
}
