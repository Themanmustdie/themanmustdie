using UnityEngine;

public class BoxDispear : MonoBehaviour
{

    public GameObject prefab;

    private void OnCollisionEnter(Collision collision)//测试是否触发触发器
    {
        if (collision.collider.tag == "roll ball")
        {
            Destroy(gameObject);
            Instantiate(prefab, prefab.transform.position, prefab.transform.rotation);
        }
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
