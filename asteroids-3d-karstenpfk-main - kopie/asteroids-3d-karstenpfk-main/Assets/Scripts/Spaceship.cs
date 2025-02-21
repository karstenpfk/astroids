using UnityEngine;
using UnityEngine.UIElements;

public class Spaceship : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody rb;
    public float thrust;
    private Vector3 Torque;
    [SerializeField] private float movementSpeed = 6.0f;
    [SerializeField] private float rotationSpeed = 10.0f;

    [SerializeField] private GameObject Kogel;
    [SerializeField] GameObject spawnPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

    }


    void FixedUpdate()
    {
        // float forward = Mathf.Clamp(Input.GetAxisRaw("Vertical"), 1, 0);
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(0, 0, Input.GetAxisRaw("Vertical") * movementSpeed, ForceMode.Acceleration);
        }
        rb.rotation *= Quaternion.AngleAxis(Input.GetAxisRaw("Horizontal") * rotationSpeed, Vector3.up);

        // Update is called once per frame

        if (Input.GetButtonDown("Fire1"))
        {
            //instantiate projectile - (overloads) what ?, where ?, a rotation ?
            Instantiate<GameObject>(Kogel, spawnPoint.transform.position, spawnPoint.transform.rotation);
        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}

