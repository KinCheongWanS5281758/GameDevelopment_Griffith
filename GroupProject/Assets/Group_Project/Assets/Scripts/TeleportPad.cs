using System.Collections;
using UnityEngine;
// for loading scene
using UnityEngine.SceneManagement;

public class TeleportPad : MonoBehaviour
{
    // public Transform teleportTarget;
    public string levelName;
    public GameObject thePlayer;

    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(levelName);
        // thePlayer.transform.position = teleportTarget.transform.position;
    }
}
