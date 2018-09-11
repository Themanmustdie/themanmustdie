using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class UserInfos
{
    public List<UserInfo> userInfoList = new List<UserInfo>();
}

[System.Serializable]
public class UserInfo
{
    public string ID;
    public string PassWord;
}

[System.Serializable]
public class DataInfos
{
    public List<DataInfo> dataInfoList = new List<DataInfo>();
}

[System.Serializable]
public class DataInfo
{
    public string ID;
    public int Scene;
    public int loginCount;
}
public class NetCtrl : MonoBehaviour
{
    //单例
    public static NetCtrl instance;
    public UserInfos users;
    public DataInfos datas;

    // Use this for initialization
    void Start()
    {
        instance = this;
        users = new UserInfos();
        datas = new DataInfos();
        //读取数据，并将数据放到userinfo列表中，方便后边的查询，存储
        string json1 = FileCtrl.instance.ReadFileTxt(FileType.USERINFO);
        if (json1.Length > 0)
        {
            users = JsonUtility.FromJson<UserInfos>(json1);//对文本中的json数据进行反序列化
            Debug.Log(json1 + ",userInfoList count=" + users.userInfoList.Count);
        }
        string json2 = FileCtrl.instance.ReadFileTxt(FileType.DataInfo);
        if (json2.Length > 0)
        {
            datas = JsonUtility.FromJson<DataInfos>(json2);//对文本中的json数据进行反序列化
            Debug.Log(json2 + ",dataInfoList count=" + datas.dataInfoList.Count);
        }

    }
    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// 登录事件，查询数据
    /// </summary>
    /// <param name="id"></param>
    /// <param name="passWord"></param>
    /// <returns></returns>
    public bool LoginIn(string id, string passWord)
    {
        for (int i = 0; i < users.userInfoList.Count; i++)
        {
            if (users.userInfoList[i].ID == id && users.userInfoList[i].PassWord == passWord)
            {

                return true;
            }
        }
        return false;

    }
    /// <summary>
    /// 注册事件 0表示成功，-1表示注册过，
    /// </summary>
    public bool Register(string id,string passWord)
    {
        for (int i = 0; i < users.userInfoList.Count; i++)
        {
            if (users.userInfoList[i].ID == id)
            {
                Common.MessageBox.Show("提示", "ID已经注册过了");
                return false;
            }
        }
        //创建对象，并将输入账号和密码，赋值给对象相应的属性
        UserInfo info = new UserInfo();
        info.ID = id;
        info.PassWord = passWord;
        users.userInfoList.Add(info);
        //转换成Json格式,
        string json1 = JsonUtility.ToJson(users);
        ////写进文件中，调用FileCtrl.cs脚本中的方法
        FileCtrl.instance.WriteFileTxt(json1, FileType.USERINFO);
        DataInfo data = new DataInfo();
        data.ID = id;
        data.Scene = 1;
        datas.dataInfoList.Add(data);
        //转换成Json格式,
        string json2 = JsonUtility.ToJson(datas);
        ////写进文件中，调用FileCtrl.cs脚本中的方法
        FileCtrl.instance.WriteFileTxt(json2, FileType.DataInfo);
        return true;
    }

    public void LoadScene(string id, int scene){
        for (int i = 0; i < datas.dataInfoList.Count; i ++)
        {
            if (datas.dataInfoList[i].ID == id)
                datas.dataInfoList.Remove(datas.dataInfoList[i]);
        }
        DataInfo info = new DataInfo();
        info.ID = id;
        info.Scene = scene;
        datas.dataInfoList.Add(info);

        User.ID = id;
        User.Scene = scene;
        //转换成Json格式,
        string json = JsonUtility.ToJson(datas);
        ////写进文件中，调用FileCtrl.cs脚本中的方法
        FileCtrl.instance.WriteFileTxt(json, FileType.DataInfo);
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);

    }

    public int GetUserScene(string id){
        for (int i = 0; i < datas.dataInfoList.Count; i++)
        {
            if (datas.dataInfoList[i].ID == id)
                return datas.dataInfoList[i].Scene;
        }
        return 0;
    }
}