using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport_same_scene : MonoBehaviour
{
    public Transform player, destination;
    public GameObject thePlayer;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            thePlayer.SetActive(false);
            player.position = destination.position;
            thePlayer.SetActive(true);
        }
    }
}

