using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class correct_ans_remove_two : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;

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
            Destroy(object1);
            Destroy(object2);
        }
    }
}
