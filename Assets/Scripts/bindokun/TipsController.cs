﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsController : MonoBehaviour
{


    public GameObject tipMaskPanel;
    public GameObject tip1;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    
    public void OnClickMaskPanel()
    {
        tipMaskPanel.SetActive(false);
    }

  
}