using UnityEngine;

public class BoxDispear : MonoBehaviour
{

    public GameObject prefab;

    void OnTriggerEnter()//测试是否触发触发器
    {
        Destroy(gameObject);
        Instantiate(prefab, prefab.transform.position, prefab.transform.rotation);
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
