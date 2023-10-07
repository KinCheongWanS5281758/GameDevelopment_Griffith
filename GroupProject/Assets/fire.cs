using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
	public float rotateSpeed = 30.0f;

	// Update is called once per frame
	void Update()
	{
		transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f);
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player")
		{
			col.gameObject.SendMessage("ApplyFirePickup");
			Destroy(gameObject);
		}
	}
}
