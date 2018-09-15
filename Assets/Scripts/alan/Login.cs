using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Login : MonoBehaviour
{

    public InputField InputFieldone;//用户账号
    public InputField InputFieldtwo;//用户的密码
    public GameObject register;//注册视图界面对象
    public GameObject select;
    public Button reg_btn;
    public Button log_btn;
    public GameObject loginFailDialog;
    // Use this for initialization
    void Start()
    {
        reg_btn.onClick.AddListener(zhuce);
        log_btn.onClick.AddListener(login);
    }

    // Update is called once per frame
    void Update()
    {



    }


    public void login()
    {
        if (NetCtrl.instance.LoginIn(InputFieldone.text, InputFieldtwo.text))
        {
            User.ID = InputFieldone.text;
            User.Scene = NetCtrl.instance.GetUserScene(User.ID);
            gameObject.SetActive(false);
            select.SetActive(true);
        }else {

            // Common.MessageBox.Show("提示", "登陆失败");
            loginFailDialog.SetActive(true);
        }
    }

    public void zhuce()
    {
        gameObject.SetActive(false);
        register.SetActive(true);
    }
}