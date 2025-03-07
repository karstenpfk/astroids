using System.Collections;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] float TimeToDestroy;
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(TimeToDestroy);
        Destroy(gameObject);
    }

    private void Start()
    {
        StartCoroutine(Timer());
    }
}
