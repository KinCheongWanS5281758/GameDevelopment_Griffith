using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IceCrystal : MonoBehaviour
{
    // Adjustable Rotate Speed
    public float rotationSpeed = 60.0f;
    public string levelName;

    void Update()
    {
        // around Y-axis
        Vector3 rotation = new Vector3(0, rotationSpeed * Time.deltaTime, 0);
        transform.Rotate(rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Load the main world scene when the ice crystal is collected
            SceneManager.LoadScene(levelName);
        }
    }
}