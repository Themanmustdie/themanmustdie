using UnityEngine;
using UnityEngine.UI;

public class Register : MonoBehaviour
{

    // Use this for initialization
    public InputField InputFieldone;//用户账号
    public InputField InputFieldtwo;//用户的密码
    public InputField InputFieldthree;//确认密码
    public GameObject login;//登录视图界面对象
    public Button register;
    public Button cancle;

    void Start()
    {
        register.onClick.AddListener(Registers);
        cancle.onClick.AddListener(Cancle);
    }

    // Update is called once per frame
    void Update()
    {

    }   
    /// <summary>
    /// 判断注册信息是否完善
    /// </summary>
    public void Interpretation()
    {

        //判断是否输入为空
        if (InputFieldone.text.Equals(string.Empty) || InputFieldtwo.text.Equals(string.Empty) || InputFieldthree.text.Equals(string.Empty))
        {
            Common.MessageBox.Show("提示", "账户或密码为空！！！！！！！！！");
            return;
        }
        //判断两次输入的密码是否一致
        if (!InputFieldthree.text.Equals(InputFieldtwo.text))
        {
            Common.MessageBox.Show("提示", "两次输入的密码不一致，请检查并重新输入");
            return;
        }
        print(InputFieldone.text+InputFieldtwo.text);
        //如果上边的判断都没问题，就要执行存储序列化了,需要调用NetCtrl.cs中的方法
        if (NetCtrl.instance.Register(InputFieldone.text, InputFieldtwo.text))
        {
            Common.MessageBox.Show("提示", "注册成功");
        }


    }

    /// <summary>
    /// 单击注册按钮
    /// </summary>
    public void Registers()
    {
        Interpretation();
    }
    /// <summary>
    /// 单击取消按钮
    /// </summary>
    public void Cancle()
    {
        InputFieldone.text = "";
        InputFieldtwo.text = "";
        InputFieldthree.text = "";
        //关闭注册界面
        gameObject.SetActive(false);
        //现实登录界面
        login.SetActive(true);
    }


}