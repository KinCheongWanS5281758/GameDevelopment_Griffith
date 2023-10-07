using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class fire_people : MonoBehaviour
{
    private Transform _transform;
    private Rigidbody _rigidbody;

    public TextMeshProUGUI scoreText;
    public int fire;

    // spawn ice crystal
    private bool fireCrystalSpawned = false;
    // prefab of ice crystal
    public GameObject fireCrystalPrefab;

    private void CheckIceCrystalCollection()
    {
        if (fire >= 7 && !fireCrystalSpawned)
        {
            // Spawn the ice crystal at a specific position
            Vector3 spawnPosition = new Vector3(342f, 20f, 258f);
            Instantiate(fireCrystalPrefab, spawnPosition, Quaternion.identity);

            // Mark the ice crystal as spawned
            fireCrystalSpawned = true;

            scoreText.text = "I see your potential. Please, use this crystal to save our world.";
        }
    }

    // Use this for initialization
    void Start()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        CheckIceCrystalCollection();
    }

    // Increment fire when picked up
    public void ApplyFirePickup()
    {
        fire++;
        UpdateFireCount();
    }

    public void UpdateFireCount()
    {
        // Update the GUI to show the number of coins
        if (scoreText)
        {
            scoreText.text = "Fire: " + fire.ToString() + "/7";
        }
    }
}
