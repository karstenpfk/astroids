using UnityEngine;

public class Projectile : MonoBehaviour
{

    //decalare and init shooter vars
    //public GameObject Kogel;
    //public float power = 1500f;
    public float moveSpeed = 20f;
    Rigidbody rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        Destroy(gameObject, 1f);

        //vector to represent forward direction of the current transform
        //Vector3 fwd = transform.TransformDirection(Vector3.forward);


        rb.linearVelocity = transform.right * moveSpeed;

    }
}



