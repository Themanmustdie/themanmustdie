using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceCubeDispear : MonoBehaviour {

    public GameObject prefab;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)//测试是否触发触发器
    {
        if (collision.collider.tag == "floor")
        {
            Destroy(gameObject);
            Instantiate(prefab, prefab.transform.position, prefab.transform.rotation);
        }
    }
}
