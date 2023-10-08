using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class only_aim_shoot : MonoBehaviour
{

	protected Transform playerTransform;// Player Transform

	// Turret
	public GameObject turret;
	public float turretRotSpeed = 4.0f;

	// Bullet shooting rate
	public float shootRate = 3.0f;
	protected float elapsedTime;

	// Ranges for chase and attack
	public float attackRange = 600.0f;

	// Bullet
	public GameObject bullet;
	public GameObject bulletSpawnPoint;

	private GameObject objPlayer;

	/*
     * Initialize the Finite state machine for the NPC tank
     */
	void Start()
	{
		elapsedTime = 0.0f;

		// Get the target enemy(Player)
		objPlayer = GameObject.FindGameObjectWithTag("Player");
		playerTransform = objPlayer.transform;

		if (!playerTransform)
			print("Player doesn't exist..");
	}


	// Update each frame
	void Update()
	{
		UpdateAttackState();

		// Update the time
		elapsedTime += Time.deltaTime;

	}

	/*
	 * Attack state
	 */
	protected void UpdateAttackState()
	{
		if (objPlayer != null)
		{
			// Always Turn the turret towards the player
			if (turret)
			{
				Quaternion turretRotation = Quaternion.LookRotation(playerTransform.position - transform.position);
				turret.transform.rotation = Quaternion.Slerp(turret.transform.rotation, turretRotation, Time.deltaTime * turretRotSpeed);
			}

			// see if player is Line of Sight
			RaycastHit hit;
			if (Physics.Linecast(transform.position + new Vector3(0f, 1f, 0f), playerTransform.position + new Vector3(0f, 1f, 0f), out hit))
			{
				if (hit.collider.gameObject.tag == "Player")
				{
					// Shoot the bullets
					ShootBullet();
				}
			}
		}
	}


	/*
     * Shoot Bullet
     */
	private void ShootBullet()
	{
		if (elapsedTime >= shootRate)
		{
			if ((bulletSpawnPoint) & (bullet))
			{
				// Shoot the bullet
				Instantiate(bullet, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
			}
			elapsedTime = 0.0f;
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, attackRange);
	}

}