using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerTank : MonoBehaviour
{
    public float moveSpeed = 20.0f; // units per second
    public float rotateSpeed = 3.0f;
    public int health = 100;
    private int maxHealth;

    private Transform _transform;
    private Rigidbody _rigidbody;

    public Camera mainCamera;

    public Image healthbar;
    private float originalHealthBarWidth;

    public Text scoreText;
    private int score = 0;

    // Coins instead of Ammo
    public int coins = 0;
    // spawn ice crystal
    private bool iceCrystalSpawned = false;
    // prefab of ice crystal
    public GameObject iceCrystalPrefab;

    // Check for ice crystal collection
    private void CheckIceCrystalCollection()
    {
        if (coins >= 9 && !iceCrystalSpawned)
        {
            // Spawn the ice crystal at a specific position
            Vector3 spawnPosition = new Vector3(-77f, 7f, 25.8f); 
            Instantiate(iceCrystalPrefab, spawnPosition, Quaternion.identity);

            // Mark the ice crystal as spawned
            iceCrystalSpawned = true;

            scoreText.text = "Ice Crystal Spawn! Grab it";
        }
    }

    // Use this for initialization
    void Start()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody>();

        maxHealth = health;

        rotateSpeed = rotateSpeed * 180 / Mathf.PI;


        if (healthbar != null)
        {
            originalHealthBarWidth = healthbar.rectTransform.sizeDelta.x;
        }
        else
        {
            Debug.LogError("Healthbar reference is not set in the Inspector!");
        }
    }

    private void Update()
    {
        if (health <= 0)
        {
            // Player dies, reload the scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        // check for ice crystal
        CheckIceCrystalCollection();
    }

    // Apply Damage if hit by bullet
    public void ApplyDamage(int damage)
    {
        health -= damage;

        float newWidth = (float)health / (float)maxHealth;

        healthbar.rectTransform.sizeDelta = new Vector2(newWidth * originalHealthBarWidth, healthbar.rectTransform.sizeDelta.y);
    }

    // Increment coins when picked up
    public void ApplyCoinPickup()
    {
        coins++;
        UpdateCoinCount();
    }

    // Increment score
    public void UpdateScore(int addScore)
    {
        score = score + addScore;
        if (scoreText)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    public void UpdateCoinCount()
    {
        // Update the GUI to show the number of coins
        if (scoreText)
        {
            scoreText.text = coins.ToString() + "/9";
        }
    }
}
