using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InteractionObject : MonoBehaviour
{
    // Reference to the GameObject you want to interact with
    public GameObject interactableObject;

    private void Update()
    {
        // Check if the "E" key is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Perform the interaction when the "E" key is pressed
            InteractWithObject();
        }
    }

    void InteractWithObject()
    {
        // Add your interaction logic here
        // For example, you can activate/deactivate the GameObject, play a sound, or trigger an animation.
        if (interactableObject != null)
        {
            interactableObject.SetActive(!interactableObject.activeSelf);
        }
    }
}
