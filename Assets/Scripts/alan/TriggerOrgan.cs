using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOrgan : MonoBehaviour {
    public GameObject end;
    public GameObject background;
    public Sprite bg;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "girl")
        {
            end.SetActive(true);
            background.GetComponent<SpriteRenderer>().sprite = bg;
            GameObject.Find("UILayer").GetComponentInChildren<BtnPromptController>(true).SwitchPromptFrom(2);
            Destroy(gameObject);
        }
    }
}
