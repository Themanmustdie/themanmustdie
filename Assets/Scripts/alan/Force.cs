using UnityEngine;

public class Force : MonoBehaviour {
    public GameObject rope;
    readonly bool flag;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(rope == null){
            if (GetComponent<Rigidbody>() == null)
            {
                gameObject.AddComponent<Rigidbody>();
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "floor"){
            GetComponent<Rigidbody>().AddForce(Vector3.right * 250);
            Destroy(gameObject, 5.0f);
        }
    }

}
