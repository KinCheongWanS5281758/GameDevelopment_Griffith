using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tips_dialog : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public GameObject canvasObject;


    void Start()
    {
        canvasObject.SetActive(true);
    }

    void Update()
    {
        canvasObject.SetActive(true);
    }

    public void ShowTips(string textInfo)
    {
        Debug.Log("ShowTips method called with text: " + textInfo);
        textComponent.text = textInfo;
    }
}

