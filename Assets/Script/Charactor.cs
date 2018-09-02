using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactor : MonoBehaviour {

    private CharacterController cc;
    public float speed = 0.1f;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }


    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        Vector3 targetDir = new Vector3(h, -10f, 0);
        cc.Move(targetDir * speed);
    }
}
