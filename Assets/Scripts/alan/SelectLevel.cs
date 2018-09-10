using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour {
    public Button contin_btn;
    public Button restart_btn;
	// Use this for initialization
	void Start () {
        contin_btn.onClick.AddListener(contin);
        restart_btn.onClick.AddListener(restart);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void contin()
    {
        print(User.Scene);
        NetCtrl.instance.LoadScene(User.ID, User.Scene);
    }

    public void restart()
    {
        NetCtrl.instance.LoadScene(User.ID, 0);
    }
}
