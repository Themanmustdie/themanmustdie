using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour {
    public Button level1;
    public Button level2;
    public Button level3;
    public Button level4;

	// Use this for initialization
	void Start () {
        level1.onClick.AddListener(Select1);
        level2.onClick.AddListener(Select2);
        level3.onClick.AddListener(Select3);
        level4.onClick.AddListener(Select4);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Select1()
    {
        NetCtrl.instance.LoadScene(User.ID, 1);
    }

    public void Select2()
    {
        NetCtrl.instance.LoadScene(User.ID, 2);
    }

    public void Select3()
    {
        NetCtrl.instance.LoadScene(User.ID, 3);
    }

    public void Select4()
    {
        NetCtrl.instance.LoadScene(User.ID, 5);
    }

}
