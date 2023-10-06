using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockGate : MonoBehaviour
{
    // Adjustable Rotate Speed
    public float rotationSpeed = 60.0f;
    public GameObject Wall;

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
            // make object disappear...
            Destroy(Wall);
            gameObject.SetActive(false);
        }
    }
}
