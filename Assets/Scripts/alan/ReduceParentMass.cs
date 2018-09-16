using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReduceParentMass : MonoBehaviour {
    bool flag;
    DateTime t_MouseDown;
    public Sprite trayWithWater;
    public Sprite trayWithoutWater;
    private bool hasPrompt = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0))
        {
            flag = false;
        }
        if (!flag && Input.GetMouseButtonDown(0))
        {
            t_MouseDown = DateTime.Now;
            flag = true;
        }

        if (flag)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(ray);
            bool isHitSprite = false;
            bool isHitWater = false;
            foreach (RaycastHit hit in hits)
            {
                //print("hit:" + hit.collider.name);
                if (hit.collider.tag == gameObject.tag)
                {
                    isHitWater = true;
                }
                if (hit.collider.tag == "BoySprite"){
                    isHitSprite = true;
                }
                if(isHitSprite && isHitWater)
                {
                    SpriteRenderer render = GetComponent<SpriteRenderer>();
                    Sprite sprite = render.sprite;
                    print("sprite.name " + sprite.name);
                    if (sprite.name == trayWithWater.name)
                    {
                        Rigidbody rb = transform.gameObject.GetComponent<Rigidbody>();
                        rb.mass = 1;
                        GetComponent<SpriteRenderer>().sprite = trayWithoutWater;
                        if(!hasPrompt && gameObject.name == "right board")
                        {
                            GameObject.Find("UILayer").GetComponentInChildren<BtnPromptController>(true).SwitchPromptFrom(2);
                            hasPrompt = true;
                        }
                        else if (!hasPrompt && gameObject.name == "left board")
                        {
                            GameObject.Find("UILayer").GetComponentInChildren<BtnPromptController>(true).SwitchPromptFrom(3);
                            hasPrompt = true;
                        }
                    }
                }
            }
        }
	}
}
