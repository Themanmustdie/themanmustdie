﻿using UnityEngine;
using UnityEditor.SceneManagement;

public class BtnReplayController : MonoBehaviour
{
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
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
