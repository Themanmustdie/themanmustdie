using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeController : MonoBehaviour {

    private float spriteStayTime;
    private bool hasBurned = false;
    public float timethreshold = 2F;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
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
                Object.Destroy(gameObject);
            }
        }
    }
}
