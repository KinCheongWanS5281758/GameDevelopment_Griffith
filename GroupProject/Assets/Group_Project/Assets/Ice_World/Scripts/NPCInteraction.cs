using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public GameObject NPCDialog;
    private bool canInteract = false;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            canInteract = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is within the "PuzzlePiece" tag area
        if (canInteract)
        {
            NPCDialog.SetActive(true);
        }
        else
        {
            NPCDialog.SetActive(false);
        }
    }
}
