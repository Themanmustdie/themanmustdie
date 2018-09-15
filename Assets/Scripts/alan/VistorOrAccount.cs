using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistorOrAccount : MonoBehaviour {

    public Button account_btn;
    public Button vistor_btn;
    public GameObject login;
    public GameObject selectLevel;
    // Use this for initialization
    void Start()
    {
        account_btn.onClick.AddListener(Account);
        vistor_btn.onClick.AddListener(Vistor);
    }

    // Update is called once per frame
    void Update()
    {



    }


    public void Vistor()
    {
        gameObject.SetActive(false);
        selectLevel.SetActive(true);
    }

    public void Account()
    {
        gameObject.SetActive(false);
        login.SetActive(true);
    }
}
