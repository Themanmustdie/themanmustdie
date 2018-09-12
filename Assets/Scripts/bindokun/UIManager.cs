using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowCommonButtons()
    {
        foreach(Transform tr in GetComponentInChildren<Transform>(true))
        {
            if(tr.gameObject.name == "btnLeft" || tr.gameObject.name == "btnRight" || tr.gameObject.name == "btnSetting")
            {
                tr.gameObject.SetActive(true);
            }
        }
    }

    public void HideAllButtons()
    {
        foreach (Transform tr in GetComponentInChildren<Transform>())
        {
            tr.gameObject.SetActive(false);
        }
    }
}
