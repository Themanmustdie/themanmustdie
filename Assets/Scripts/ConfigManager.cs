using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class JsonStruct
{
    public KeyVal[] keyValList;
}

[System.Serializable]
public class KeyVal
{
    public string key;
    public string value;
}

public class ConfigManager
{

    private static ConfigManager instance;
    private Dictionary<string, string> configParaMap;

    public static ConfigManager GetInstance
    {
        get
        {
            if (instance == null)
            {
                instance = System.Activator.CreateInstance<ConfigManager>();
                instance.Init();
            }
            return instance;
        }
    }

    private void Init()
    {
        configParaMap = new Dictionary<string, string>();
        string configDirPath = configDirPath = Application.persistentDataPath + "/Config";
        if (!Directory.Exists(configDirPath))
        {
            Directory.CreateDirectory(configDirPath);
        }

        DirectoryInfo configDir = new DirectoryInfo(configDirPath);
        foreach (FileInfo configFile in configDir.GetFiles())
        {
            if (configFile.Name.EndsWith(".json"))
            {
                string dataAsJson = File.ReadAllText(configFile.FullName);
                if (!dataAsJson.Equals(""))
                {
                    JsonStruct jsonStruct = JsonUtility.FromJson<JsonStruct>(dataAsJson);
                    foreach (KeyVal keyVal in jsonStruct.keyValList)
                    {
                        configParaMap.Add(configFile.Name.Replace(".json", "-") + keyVal.key, keyVal.value);
                    }
                }
            }

        }
    }

    public string GetPara(string key)
    {
        if (configParaMap.ContainsKey(key))
        {
            return configParaMap[key];
        }
        return "";
    }

}
