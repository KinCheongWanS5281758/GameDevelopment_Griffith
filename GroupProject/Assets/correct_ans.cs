using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class correct_ans : MonoBehaviour
{
    public GameObject walls;
    public AudioSource pickupSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "Player")
        {
            if (pickupSound != null)
            {
                pickupSound.Play();
            }
            Destroy(walls);
        }
    }
}
