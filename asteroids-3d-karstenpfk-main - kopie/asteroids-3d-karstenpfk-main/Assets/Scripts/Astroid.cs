using Unity.Hierarchy;
using UnityEditor;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Astroid : MonoBehaviour
{
    public Rigidbody rb;
    private Astroidspawn astroidspawn;
    GameManager gameManager;

    void Start()
    {
        astroidspawn = FindFirstObjectByType<Astroidspawn>();
        rb.AddForce(Random.Range(-100f, 100f), 0, Random.Range(-100f, 100f));
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet" || collision.gameObject.tag == "player")
        {
            astroidspawn.removeastroid(gameObject);
            Destroy(collision.gameObject);      //to destroy enemy
            Destroy(gameObject);                    //to destroy bullet
            GameObject Particle = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Particle.GetComponent<ParticleSystem>().Play(); // Speel de deeltjes af
            gameManager.DestroyAsteroid();
        }
    }
    public GameObject explosionPrefab; // Variabele voor de deeltjes prefab


}
