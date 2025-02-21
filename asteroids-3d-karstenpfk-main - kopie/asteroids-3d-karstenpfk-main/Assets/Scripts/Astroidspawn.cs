using UnityEngine;
using System.Collections.Generic;

public class Astroidspawn : MonoBehaviour
{
    [SerializeField] private List<GameObject> asteroids;

    public GameObject prefab;

    private void Start()
    {
        asteroids = new List<GameObject>();

        for (int i = 0; i < 7; i++)
        {
            Vector3 randomPos = new Vector3(Random.Range(-15f, 15f), 0, Random.Range(-15, 15f));
            GameObject go = Instantiate(prefab, randomPos, Quaternion.identity);
            asteroids.Add(go);
        }
    }

    public void removeastroid(GameObject astroid)
    {
        asteroids.Remove(astroid);
    }

}
