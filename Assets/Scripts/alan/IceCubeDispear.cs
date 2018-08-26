using UnityEngine;

public class IceCubeDispear : MonoBehaviour
{

    public GameObject prefab;

    private void OnCollisionEnter(Collision collision)//测试是否触发触发器
    {
        if (collision.collider.tag == "floor")
        {
            Destroy(gameObject);
            Instantiate(prefab, prefab.transform.position, prefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
