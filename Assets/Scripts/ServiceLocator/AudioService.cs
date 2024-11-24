using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioService : IAudioService
{
    private AudioSource soundEffectSource;
    private AudioSource musicSource;

    private AudioClip shootSFX;
    private AudioClip bgSFX;
    private AudioClip hitSFX;
    public AudioService()
    {
        shootSFX = Resources.Load<AudioClip>("Sounds/ShootSFX");
        bgSFX = Resources.Load<AudioClip>("Sounds/KrakenSFX");
        hitSFX = Resources.Load<AudioClip>("Sounds/HitSFX");

        var audioObject = new GameObject("AudioService");
        soundEffectSource = audioObject.AddComponent<AudioSource>();
        musicSource = audioObject.AddComponent<AudioSource>();

        Object.DontDestroyOnLoad(audioObject); 
    }
    public void ShootSound()
    {
        soundEffectSource.PlayOneShot(shootSFX);
    }
    public void HitSound()
    {
        soundEffectSource.PlayOneShot(hitSFX); 
    }
    public void BackgroundMusic()
    {
        musicSource.clip = bgSFX;
        musicSource.loop = true;
        musicSource.Play();
    }
    public void StopBackgroundMusic()
    {
        musicSource.Stop();
    }
}