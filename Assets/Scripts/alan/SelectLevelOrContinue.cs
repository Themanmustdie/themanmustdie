using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevelOrContinue : MonoBehaviour {
    public GameObject selectlevel;
    public Button contin;
    public Button select;

    // Use this for initialization
    void Start()
    {
        contin.onClick.AddListener(Continue);
        select.onClick.AddListener(Select);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Continue()
    {
        NetCtrl.instance.LoadScene(User.ID, User.Scene);
    }

    public void Select()
    {
        gameObject.SetActive(false);
        selectlevel.SetActive(true);
    }

}
