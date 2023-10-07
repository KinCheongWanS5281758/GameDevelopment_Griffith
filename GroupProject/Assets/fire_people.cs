using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class fire_people : MonoBehaviour
{
    private Transform _transform;
    private Rigidbody _rigidbody;

    public Image healthbar;
    private float originalHealthBarWidth;

    public Text scoreText;
    public int fire = 0;


    // Use this for initialization
    void Start()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody>();

    }

    private void Update()
    {

    }

    // Increment fire when picked up
    public void ApplyFirePickup()
    {
        fire++;
        UpdateFireCount();
    }

    // Increment fire
    public void UpdateScore(int addScore)
    {
        fire = fire + addScore;
        if (scoreText)
        {
            scoreText.text = "Fire: " + fire.ToString();
        }
    }

    public void UpdateFireCount()
    {
        // Update the GUI to show the number of coins
        if (scoreText)
        {
            scoreText.text = fire.ToString() + "/9";
        }
    }
}
