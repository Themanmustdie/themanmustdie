﻿using UnityEngine;
using UnityEditor.SceneManagement;

public class BtnReplayController : MonoBehaviour
{
    public int level;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        NetCtrl.instance.LoadScene(User.ID, level);
    }
}
