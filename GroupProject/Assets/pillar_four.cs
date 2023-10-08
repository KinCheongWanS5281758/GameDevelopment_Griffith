using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pillar_four : MonoBehaviour
{
    public int pillarHP = 100; // The health of the pillar
    public int innerDamageMultiplier = 4; // Damage multiplier for inner zone
    public int outerDamageMultiplier = 2; // Damage multiplier for outer zone
    public int initialHP = 100;

    // Define the radii for the inner and outer zones
    public float innerZoneRadius = 30.0f;
    public float outerZoneRadius = 70.0f;

    private bool hasHealedPlayer = false;

    // Define states for the pillar's behavior
    private enum PillarState
    {
        Idle,
        Damaging
    }

    private PillarState currentState = PillarState.Idle;
    private float damageCooldown = 1.0f;
    private float damageTimer = 0.0f;
    private Transform playerTransform;
    private float distanceToPillar;

    public Image hpBarImage; // Reference to the HP bar UI Image
    private float originalHPBarWidth; // Store the original size of the HP bar

    public AudioSource hitSound;
    public AudioSource breakSound;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, innerZoneRadius);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, outerZoneRadius);
    }

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }

        // Initialize the HP bar
        originalHPBarWidth = hpBarImage.rectTransform.sizeDelta.x;
        UpdateHPBar();
    }

    private void Update()
    {
        distanceToPillar = Vector3.Distance(transform.position, playerTransform.position);

        switch (currentState)
        {
            case PillarState.Idle:
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
                damageTimer += Time.deltaTime;
                if (damageTimer >= damageCooldown)
                {
                    if (distanceToPillar <= innerZoneRadius)
                    {
                        TakeDamage(innerDamageMultiplier);
                    }
                    else if (distanceToPillar <= outerZoneRadius)
                    {
                        TakeDamage(outerDamageMultiplier);
                    }
                    damageTimer = 0.0f;
                }

                if (distanceToPillar > outerZoneRadius)
                {
                    currentState = PillarState.Idle;
                }
                break;
        }

        // send pillar HP msg to the player
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            // Send a message to the player object
            player.SendMessage("ReceivePillarFourHP", pillarHP);
        }

    }

    public void TakeDamage(int damage)
    {
        pillarHP -= damage;

        if (pillarHP <= 0 && !hasHealedPlayer) {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.SendMessage("HealPlayer", 50);
            hasHealedPlayer = true;
        }
      
        if (pillarHP <= 0)
        {

            // Handle pillar destruction
            breakSound.Play();
            Destroy(gameObject);
        }
        else
        {
            hitSound.Play();
        }

        // Update the HP bar
        UpdateHPBar();
    }

    private void UpdateHPBar()
    {
        float fillAmount = (float)pillarHP / (float)initialHP;
        hpBarImage.fillAmount = fillAmount;

        // Update the HP bar's width
        hpBarImage.rectTransform.sizeDelta = new Vector2(originalHPBarWidth * fillAmount, hpBarImage.rectTransform.sizeDelta.y);
    }
}
