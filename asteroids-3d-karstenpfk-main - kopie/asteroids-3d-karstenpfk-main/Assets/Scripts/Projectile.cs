using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //decalare and init shooter vars
    public Rigidbody Kogel;
    public float power = 1500f;
    public float moveSpeed = 2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //instantiate projectile - (overloads) what ?, where ?, a rotation ?
            Rigidbody instance = Instantiate(Kogel, transform.position, transform.rotation) as Rigidbody;
            //vector to represent forward direction of the current transform
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            instance.AddForce(fwd * power);
        }

    }
}

