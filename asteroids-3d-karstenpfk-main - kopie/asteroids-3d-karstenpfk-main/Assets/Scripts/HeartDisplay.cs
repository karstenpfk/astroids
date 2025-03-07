using UnityEngine;
using UnityEngine.UI;


public class HeartDisplay : MonoBehaviour
{
    [SerializeField] private Image[] hearts;
   



    void Start()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].gameObject.SetActive(true);
        }
    }


    public void UpdateHearts(int lives)
    {

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < lives)
            {
                hearts[i].gameObject.SetActive(true);
            }
            else
            {
                hearts[i].gameObject.SetActive(false);
            }

        }
    }
    
}
