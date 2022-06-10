using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemManager : MonoBehaviour
{
    public static ParticleSystemManager Instance;

    public GameObject DogDeathParticleSystem;

    public GameObject WinParticleSystem;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void PlayDogDeathParticle(Vector3 position)
    {
        Instantiate(DogDeathParticleSystem, position, Quaternion.identity);
    }

    public void PlayWinParticleSystem()
    {
        Instantiate(WinParticleSystem);
    }

}
