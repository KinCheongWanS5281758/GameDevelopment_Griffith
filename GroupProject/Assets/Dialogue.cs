using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public Image leftCharacterImage;
    public Image rightCharacterImage;
    public string[] lines;
    private int index;

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
        else if (line.Contains("Archon:"))
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

