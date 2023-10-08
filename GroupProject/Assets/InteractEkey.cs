using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using TMPro;

public class InteractEkey : MonoBehaviour
{
    public GameObject keyTexture;
    public bool keyActive = false; // Corrected declaration with type "bool"

    // Start is called before the first frame update
    void Start()
    {
        keyTexture.SetActive(keyActive);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // OnTriggerEnter should not be defined inside Update
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("PuzzlePiece"))
        {
            keyActive = true;
            keyTexture.SetActive(keyActive);
        }
    }
}
