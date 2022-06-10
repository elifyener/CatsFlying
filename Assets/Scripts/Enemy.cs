using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    

	public float health = 4f;

	public static int EnemiesAlive = 0;


	public static float point = 0;

	void Start ()
	{
		EnemiesAlive++;
	}

	void OnCollisionEnter2D (Collision2D colInfo)
	{
		if (colInfo.relativeVelocity.magnitude > health)
		{
			Die();
		}
	}

	void Die ()
	{
		ParticleSystemManager.Instance.PlayDogDeathParticle(transform.position);
		AudioManager.Instance.PlayDogDeathSound();

		point += 50;

		EnemiesAlive--;
		if (EnemiesAlive <= 0)
		{
			ParticleSystemManager.Instance.PlayWinParticleSystem();
			FinishScreen.Instance.OpenWinScreen();
		}
		Destroy(gameObject);
	}
}
