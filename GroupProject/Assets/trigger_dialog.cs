using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class trigger_dialog : MonoBehaviour
{
    public GameObject canvasObject;
    public TextMeshProUGUI textComponent;
    public string content;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            textComponent.text = content;
        }
    }
}
