using UnityEngine;

public class Spaceship : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Input.GetAxisRaw("horizontal") * Time.deltaTime;
        transform.Rotate(0, speed, 0);

    }

    
}
