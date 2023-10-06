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
            scoreText.text = coins.ToString() + "/7";
        }
    }
}
