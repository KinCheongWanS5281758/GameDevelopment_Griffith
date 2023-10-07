using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public List<GameObject> correctSequence;
    private int nextPieceIndex = 0;

    public TextMeshProUGUI scoreText;
    public GameObject cage;

    public GameObject keyTexture;
    private bool canInteract = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            HandleInteraction();
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("PuzzlePiece"))
        {
            keyTexture.SetActive(true);
            canInteract = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("PuzzlePiece"))
        {
            keyTexture.SetActive(false);
            canInteract = false;
        }
    }

    void HandleInteraction()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 2.0f))
        {
            GameObject hitObject = hit.collider.gameObject;

            if (hitObject.CompareTag("PuzzlePiece"))
            {
                Debug.Log(hitObject);
                // Check hit
                if (hitObject == correctSequence[nextPieceIndex])
                {
                    Debug.Log(correctSequence[nextPieceIndex]);
                    // Handle the interaction
                    hitObject.SetActive(false);
                    nextPieceIndex++;

                    // If complete puzzle
                    if (nextPieceIndex >= correctSequence.Count)
                    {
                        // destroy the game object so use can get the rewards
                        Destroy(cage);
                        scoreText.text = "Something happened in middle of the world...";
                    }
                }
                else
                {
                    // Reset
                    ResetPuzzle();
                }
            }
        }
    }

    void ResetPuzzle()
    {
        nextPieceIndex = 0;

        // Retrieve all pieces
        foreach (var piece in correctSequence)
        {
            piece.SetActive(true);
        }
    }

}