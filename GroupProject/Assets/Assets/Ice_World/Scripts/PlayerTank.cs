using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerTank : MonoBehaviour
{
    public float moveSpeed = 20.0f; // units per second
    public float rotateSpeed = 3.0f;
    public int health = 200;
    private int maxHealth;

    private Transform _transform;
    private Rigidbody _rigidbody;

    public Camera mainCamera;

    public Image healthbar;
    private float originalHealthBarWidth;

    public TextMeshProUGUI scoreText;
    private int score = 0;

    // Coins instead of Ammo
    public int coins = 0;
    // spawn ice crystal
    private bool iceCrystalSpawned = false;
    // prefab of ice crystal
    public GameObject iceCrystalPrefab;

    // bool for exit spawn, only happen once
    private bool EditSpawned = false;

    // For boss stage..
    public int totalPillarHP = 0;
    private int pillarOneHP = 0;
    private int pillarTwoHP = 0;
    private int pillarThreeHP = 0;
    private int pillarFourHP = 0;
    public GameObject Exit;

    // Check for ice crystal collection
    // Only for Ice World
    private void CheckIceCrystalCollection()
    {
        if (coins >= 9 && !iceCrystalSpawned)
        {
            // Spawn the ice crystal at a specific position
            Vector3 spawnPosition = new Vector3(-77f, 7f, 25.8f); 
            Instantiate(iceCrystalPrefab, spawnPosition, Quaternion.identity);

            // Mark the ice crystal as spawned
            iceCrystalSpawned = true;

            scoreText.text = "Ice Crystal Spawn! Grab it!";
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
            // Player dies
            SceneManager.LoadScene("Die");
        }

        // check for ice crystal
        CheckIceCrystalCollection();
    }

    // Apply Damage if hit by bullet
    public void ApplyDamage(int damage)
    {
        health -= damage;
        updateHPBar(health);
    }

    public void updateHPBar(int damage) {

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

    // Function to receive the pillar HP from each pillar
    public void ReceivePillarOneHP(int pillarHP)
    {
        pillarOneHP = pillarHP;
        CalculateTotalPillarHP();
    }

    public void ReceivePillarTwoHP(int pillarHP)
    {
        pillarTwoHP = pillarHP;
        CalculateTotalPillarHP();
    }

    public void ReceivePillarThreeHP(int pillarHP)
    {
        pillarThreeHP = pillarHP;
        CalculateTotalPillarHP();
    }

    public void ReceivePillarFourHP(int pillarHP)
    {
        pillarFourHP = pillarHP;
        CalculateTotalPillarHP();
    }

    private void CalculateTotalPillarHP()
    {
        // reset current total
        totalPillarHP = 0;
        totalPillarHP = pillarOneHP + pillarTwoHP + pillarThreeHP + pillarFourHP;
        // Debug.Log("Total Pillar HP: " + totalPillarHP);

        if (totalPillarHP <= 0) {
            Vector3 spawnExit = new Vector3(-77f, 7f, 25.8f);

            // Spawn the Exit at a specific position
            if(!EditSpawned)
            {
                Vector3 spawnHellPosition = new Vector3(313f, 29f, 577f);
                Instantiate(Exit, spawnHellPosition, Quaternion.identity);

                scoreText.text = "Zhongli: Here's the exit! Hurry up!";
            }
        }
    }

    // get the info from other pillar...
    // if one of the pillar breaks, heal player 50hp
    // this can only do once in each pillar
    public void HealPlayer(int amount)
    {
        health += amount;
        updateHPBar(health);
    }

}
