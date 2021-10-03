using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip IntroMusic;
    public AudioClip GameplayMusic;
    public AudioClip GameOverMusic;
    public AudioClip WinGameMusic;

    [SerializeField] AudioSource musicSource;

    public void PlayMusic(AudioClip targetMusic)
    {
        musicSource.Stop();
        musicSource.clip = targetMusic;
        musicSource.Play();
    }
}
