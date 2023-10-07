using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pillar_four : MonoBehaviour
{
    public int pillarHP = 100; // The health of the pillar
    public float innerDamageMultiplier = 4.0f; // Damage multiplier for inner zone
    public float outerDamageMultiplier = 2.0f; // Damage multiplier for outer zone

    // Define the radii for the inner and outer zones
    public float innerZoneRadius = 30.0f;
    public float outerZoneRadius = 70.0f;

    // Define states for the pillar's behavior
    private enum PillarState
    {
        Idle,
        Damaging
    }

    private PillarState currentState = PillarState.Idle;
    private float damageCooldown = 1.0f;
    private float damageTimer = 0.0f;

    private Transform playerTransform; // Reference to the player's transform
    private float distanceToPillar; // Declare the distanceToPillar variable here

    private void OnDrawGizmosSelected()
    {
        // Draw Gizmos to visualize the trigger zones
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, innerZoneRadius);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, outerZoneRadius);
    }

    private void Start()
    {
        // Find and store a reference to the player's transform
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    private void Update()
    {
        distanceToPillar = Vector3.Distance(transform.position, playerTransform.position); // Calculate the distance here

        switch (currentState)
        {
            case PillarState.Idle:
                // Check if the player is within the inner or outer zone
                if (playerTransform != null)
                {
                    if (distanceToPillar <= innerZoneRadius)
                    {
                        currentState = PillarState.Damaging;
                    }
                    else if (distanceToPillar <= outerZoneRadius)
                    {
                        currentState = PillarState.Damaging;
                    }
                }
                break;

            case PillarState.Damaging:
                // Apply damage only once every second
                damageTimer += Time.deltaTime;
                if (damageTimer >= damageCooldown)
                {
                    if (distanceToPillar <= innerZoneRadius)
                    {
                        TakeDamage(2); // Apply 2 damage if player is in the inner zone
                    }
                    else if (distanceToPillar <= outerZoneRadius)
                    {
                        TakeDamage(1); // Apply 1 damage if player is in the outer zone
                    }
                    damageTimer = 0.0f; // Reset the timer
                }

                // Check if the player is no longer within the inner or outer zone
                if (distanceToPillar > outerZoneRadius)
                {
                    currentState = PillarState.Idle;
                }
                break;
        }
    }

    // Function to handle damage to the pillar
    public void TakeDamage(int damage)
    {
        pillarHP -= damage;

        if (pillarHP <= 0)
        {
            // Handle pillar destruction (e.g., disable the pillar or play a destruction animation)
            Destroy(gameObject);
        }
    }
}
