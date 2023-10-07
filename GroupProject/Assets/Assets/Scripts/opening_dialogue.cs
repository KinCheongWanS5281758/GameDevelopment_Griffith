using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class opening_dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public Image leftCharacterImage;
    public Image rightCharacterImage;
    public string[] lines;
    private int index;
    public string levelName;

    public GameObject canvasObject;

    private void Start()
    {
        textComponent.text = string.Empty;
        leftCharacterImage.gameObject.SetActive(false);
        rightCharacterImage.gameObject.SetActive(false);
        StartDialogue();
    }

    private void Update()
    {
        // Input.GetMouseButtonDown(0) -> mouse left key
        if (index < lines.Length && Input.GetMouseButtonDown(0))
        {
            NextLine();
        }
        else if (index >= lines.Length)
        {
            canvasObject.gameObject.SetActive(false);
            // direct user to main world
            SceneManager.LoadScene(levelName);
        }
    }

    private void StartDialogue()
    {
        index = 0;
        NextLine();
    }

    private void NextLine()
    {
        if (index < lines.Length)
        {
            // Show text
            textComponent.text = lines[index];
            DisplayCharacterImages(lines[index]);
            index++;
        }
    }

    private void DisplayCharacterImages(string line)
    {
        if (line.Contains("Aether:"))
        {
            leftCharacterImage.gameObject.SetActive(true);
            rightCharacterImage.gameObject.SetActive(false);
        }
        else if (line.Contains("Zhongli:"))
        {
            leftCharacterImage.gameObject.SetActive(false);
            rightCharacterImage.gameObject.SetActive(true);
        }
        else
        {
            leftCharacterImage.gameObject.SetActive(false);
            rightCharacterImage.gameObject.SetActive(false);
        }
    }
}
