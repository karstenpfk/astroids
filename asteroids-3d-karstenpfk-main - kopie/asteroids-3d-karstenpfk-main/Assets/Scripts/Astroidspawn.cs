using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class Astroidspawn : MonoBehaviour
{
    
       
        public GameObject prefab;

        private void Start()
        {
            for (int i = 0; i < 10; i++)
            {
                Vector3 randomPos = new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5, 5f));
                Instantiate(prefab, randomPos, Quaternion.identity);
            }
        }
      
}
