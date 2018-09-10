using UnityEngine;
using System.Collections;
using System.IO;
/// <summary>
/// 存入文件的类型
/// </summary>
public enum FileType
{
    USERINFO,
    EQUIP,
    DataInfo,
}
public class FileCtrl : MonoBehaviour
{
    public static FileCtrl instance;
    string UserFile = "UserInfo.txt";
    string EquipFile = "Equip.txt";
    string UserInfoFile = "Info.txt";
    // Use this for initialization
    void Awake()
    {
        instance = this;
    }
    void Start()
    {

    }
    /// <summary>
    /// 写入文件
    /// </summary>
    /// <param name="content"></param>
    /// <param name="type"></param>
    public void WriteFileTxt(string content, FileType type)
    {
        string path = Application.persistentDataPath + "/";
        print("path:" + path);
        //path的路径C:\Users\Administrator\AppData\LocalLow\DefaultCompany\login

        switch (type)
        {
            case FileType.USERINFO:
                path += UserFile;
                break;
            case FileType.EQUIP:
                path += EquipFile;
                break;
            case FileType.DataInfo:
                path += UserInfoFile;
                break;
        }
        File.WriteAllText(path, content);
    }
    /// <summary>
    /// 读取文件类型
    /// </summary>
    /// <param name="type"></param>
    public string ReadFileTxt(FileType type)
    {
        string path = Application.persistentDataPath + "/";
        switch (type)
        {
            case FileType.USERINFO:
                path += UserFile;
                break;
            case FileType.EQUIP:
                path += EquipFile;
                break;
            case FileType.DataInfo:
                path += UserInfoFile;
                break;
        }
        if (!File.Exists(path))
        {
            Debug.Log("路径文件为空");
            return "";
        }
        return File.ReadAllText(path);
    }
}