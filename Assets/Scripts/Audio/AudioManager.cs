using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioClip audioMeow;
    [SerializeField] private AudioClip audioBow;
    [SerializeField] private AudioClip audioWhoosh;
    [SerializeField] private AudioClip audioDogDeath;
    [SerializeField] private AudioSource _audioSource;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void PlayBowSound()
    {
        _audioSource.PlayOneShot(audioBow, 0.5f);
    }
    public void PlayMeowSound()
    {
        _audioSource.PlayOneShot(audioMeow, 0.5f);
    }
    public void PlayWhooshSound()
    {
        _audioSource.PlayOneShot(audioWhoosh, 1f);
    }
    public void PlayDogDeathSound()
    {
        _audioSource.PlayOneShot(audioDogDeath, 0.5f);
    }
}
