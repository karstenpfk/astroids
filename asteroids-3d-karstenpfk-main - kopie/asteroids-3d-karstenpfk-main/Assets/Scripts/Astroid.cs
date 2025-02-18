using Unity.Hierarchy;
using UnityEditor;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.AddForce(Random.Range(-100f, 100f), 0, Random.Range(-100f, 100f));
            
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            Destroy(collision.gameObject);      //to destroy enemy
            Destroy(gameObject);                    //to destroy bullet

        }
    }

}
