using UnityEngine;

public class Explore : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "floor")
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            Destroy(gameObject, 2.0f);
        }

    }
    // Use this for initialization
    void Start()
    {
        var items = GetComponentsInChildren<Transform>();
        foreach (Transform child in items)
        {
            var collider = child.GetComponent<BoxCollider>();
            collider.attachedRigidbody.AddExplosionForce(300f, -transform.position, 100, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}