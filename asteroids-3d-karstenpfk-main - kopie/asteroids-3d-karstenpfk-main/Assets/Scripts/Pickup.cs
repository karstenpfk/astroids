using UnityEngine;

public class Pickup : MonoBehaviour
{

    protected virtual void OnTriggerEnter(Collider other)
    {
        Spaceship spaceship = other.GetComponent<Spaceship>();
        if (spaceship != null)
        {
            spaceship.ActivatePickup();
            Destroy(gameObject);
        }
    }


}
