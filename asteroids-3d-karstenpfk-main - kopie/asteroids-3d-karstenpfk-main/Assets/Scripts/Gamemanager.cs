using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject asteroidPrefab; // Variabele voor de asteroïde prefab
    public int asteroidCount = 4; // Aantal asteroïden dat gespawned moet worden
    private int roundCount = 0; // Variabele om het aantal rondes bij te houden
    public int score = 0; // Variabele om de score bij te houden
    public TMP_Text scoreText; // UI Text element om de score weer te geven
    Spaceship Ship;


    [SerializeField] private GameObject pickupPrefab;

    //private int lives = 3; // Aantal levens

    void Start()
    {
        StartNewRound(); // Roep de StartNewRound() functie aan in Start()
        UpdateScoreText(); // Update de score tekst bij de start
        Ship = FindFirstObjectByType<Spaceship>();
        Invoke("SpawnPickup", 5f);
    }

    void Update()
    {
        CheckForAsteroids(); // Controleer of er nog asteroïden zijn
    }

    void StartNewRound()
    {
        roundCount++; // Verhoog het aantal rondes

        // Verhoog het aantal asteroïden elke 2 rondes
        if (roundCount % 2 == 0)
        {
            asteroidCount++;
        }

        for (int i = 0; i < asteroidCount; i++)
        {
            // Gebruik Random.Range om de asteroïden op een random positie te plaatsen
            Vector3 randomPosition = new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f));
            Instantiate(asteroidPrefab, randomPosition, Quaternion.identity);
        }
    }

    void CheckForAsteroids()
    {
        // Controleer of er nog asteroïden zijn
        if (GameObject.FindGameObjectsWithTag("Astroid").Length == 0)
        {
            StartNewRound(); // Start een nieuwe ronde als er geen asteroïden meer zijn
        }
    }

    // Voeg een functie toe om een asteroïde te vernietigen en punten toe te voegen
    public void DestroyAsteroid()
    {
        AddScore(65); // Voeg 65 punten toe voor elke vernietigde asteroïde
    }

    // Functie om punten toe te voegen
    void AddScore(int points)
    {
        score += points;
        Ship.pointCounter += points;
        UpdateScoreText(); // Update de score tekst
    }

    // Functie om de score tekst bij te werken
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    // Functie om een hart te verwijderen
    public void LoseHeart()
    {
        //if (lives > 0)
        //{
        //    lives--; // Verminder het aantal levens
     
        //    if (lives <= 0)
        //    {
        //        // Voeg hier logica toe voor wanneer de speler geen levens meer heeft
        //        Debug.Log("Game Over");
        //    }
        //}
    }

    public void SpawnPickup()
    {
        GameObject go = Instantiate<GameObject>(pickupPrefab);
        go.transform.position = new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f));
        Invoke("SpawnPickup", 5f);
    }
}


