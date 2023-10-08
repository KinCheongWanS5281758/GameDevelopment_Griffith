using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerFinalBoss : MonoBehaviour
{
    public float moveSpeed = 20.0f;
    public float rotateSpeed = 3.0f;
    public int health = 100;
    private int maxHealth;

    private Transform _transform;
    private Rigidbody _rigidbody;

    public Image healthbar;
    private float originalHealthBarWidth;

    public Text scoreText;

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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void ApplyDamage(int damage)
    {
        health -= damage;

        float newWidth = (float)health / (float)maxHealth;
        healthbar.rectTransform.sizeDelta = new Vector2(newWidth * originalHealthBarWidth, healthbar.rectTransform.sizeDelta.y);
    }

    public void ApplyHeartPickup()
    {
        health = +50;

    }

}
