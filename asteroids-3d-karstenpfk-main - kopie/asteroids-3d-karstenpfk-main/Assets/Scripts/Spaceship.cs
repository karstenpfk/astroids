using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

    public class Spaceship : MonoBehaviour
{
    private Rigidbody rb;
    public float thrust;
    private Vector3 Torque;
    [SerializeField] private float movementSpeed = 6.0f;
    [SerializeField] private float rotationSpeed = 10.0f;

    [SerializeField] private GameObject Kogel;
    [SerializeField] GameObject spawnPoint;

    public int lives = 3; // Aantal hartjes
    public float invincibilityDuration = 2f; // Duur van de onkwetsbaarheid
    private bool isInvincible = false; // Of het ruimteschip momenteel onkwetsbaar is
    [SerializeField] private GameObject forceField; // Referentie naar het krachtveld GameObject


    [SerializeField] private HeartDisplay heartDisplay; // Referentie naar de HeartDisplay
     public int pointCounter; 
     private HeartDisplay heart;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        forceField.SetActive(false); // Zorg ervoor dat het krachtveld uit staat bij de start

        heartDisplay.UpdateHearts(lives); // Update de hartjes bij de start
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // Instantiate projectile - (overloads) what ?, where ?, a rotation ?
            Instantiate(Kogel, spawnPoint.transform.position, spawnPoint.transform.rotation);
        }
        if (pointCounter >= 10000)
        {
            if (lives < 4){

            lives++;
            }
            heartDisplay.UpdateHearts(lives);
            pointCounter = 0;
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(0, 0, Input.GetAxisRaw("Vertical") * movementSpeed, ForceMode.Acceleration);
        }
        rb.rotation *= Quaternion.AngleAxis(Input.GetAxisRaw("Horizontal") * rotationSpeed, Vector3.up);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //print("hit");
        if (collision.gameObject.CompareTag("Astroid") && !isInvincible)
        {
            StartCoroutine(TakeDamage());
        }
    }

    private IEnumerator TakeDamage()
    {
        lives--; // Verminder het aantal hartjes

        heartDisplay.UpdateHearts(lives); // Update de hartjes in de UI

        // Controleer of het ruimteschip geen hartjes meer heeft
        if (lives < 0)
        {
            Destroy(gameObject); // Vernietig het ruimteschip
            SceneManager.LoadScene("eindscherm");
        }

        isInvincible = true; // Maak het ruimteschip tijdelijk onkwetsbaar
        forceField.SetActive(true); // Activeer het krachtveld

        // Wacht voor de duur van de onkwetsbaarheid
        yield return new WaitForSeconds(invincibilityDuration);

        isInvincible = false; // Maak het ruimteschip weer kwetsbaar
        forceField.SetActive(false); // Deactiveer het krachtveld

    }

    public void ActivatePickup()
    {
        Debug.Log("Pickup collected");
    }
}

