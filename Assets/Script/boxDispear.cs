using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxDispear : MonoBehaviour {

    public GameObject prefab;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider game)//测试是否触发触发器
    {
        Destroy(gameObject);
        Instantiate(prefab, prefab.transform.position, prefab.transform.rotation);
    }
}
