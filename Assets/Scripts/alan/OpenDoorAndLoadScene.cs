﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorAndLoadScene : MonoBehaviour {
    public int level;
    public GameObject door;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "girl")
        {
            Debug.Log("OnTriggerEnterOnTriggerEnterOnTriggerEnterOnTriggerEnter");
            door.SetActive(true);
            GameObject.Find("Butterfly").GetComponent<Level4ButterflyController>().GetIntoRoom();
            //Invoke("LoadScene", 2f);
        }
    }

    public void LoadScene(){
        NetCtrl.instance.LoadScene(User.ID, level);
    }
}
