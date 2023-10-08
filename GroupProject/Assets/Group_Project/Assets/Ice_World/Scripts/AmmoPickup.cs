using UnityEngine;
using System.Collections;

public class AmmoPickup : MonoBehaviour
{

	public float rotateSpeed = 30.0f;
	public AudioSource pickupSound;

	// Update is called once per frame
	void Update()
	{
		transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f);
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player")
		{
			if (pickupSound != null)
			{
				pickupSound.Play();
			}

			col.gameObject.SendMessage("ApplyCoinPickup");
			Destroy(gameObject);
		}
	}
}