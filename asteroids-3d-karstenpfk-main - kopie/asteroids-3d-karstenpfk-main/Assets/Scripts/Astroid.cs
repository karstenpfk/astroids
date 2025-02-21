using Unity.Hierarchy;
using UnityEditor;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    public Rigidbody rb;
    private Astroidspawn astroidspawn;

    void Start()
    {
        astroidspawn = FindFirstObjectByType<Astroidspawn>();
        rb.AddForce(Random.Range(-100f, 100f), 0, Random.Range(-100f, 100f));
            
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet" || collision.gameObject.tag == "player")
        {
            astroidspawn.removeastroid(gameObject);
            Destroy(collision.gameObject);      //to destroy enemy
            Destroy(gameObject);                    //to destroy bullet

        }
    }

}
