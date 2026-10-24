using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    

    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public List<AudioClip> clips = new List<AudioClip>();

    private AudioSource source;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySelectSFX()
    {
        source.PlayOneShot(clips[0]);
    }
    public void PlayEnemyLaserSFX()
    {
        source.PlayOneShot(clips[1]);
    }
    public void PlayPlayerLaserSFX()
    {
        source.PlayOneShot(clips[2]);
    }
    public void PlayExplosionSFX()
    {
        source.PlayOneShot(clips[3]);
    }
    public void PlayPickupSFX()
    {
        source.PlayOneShot(clips[4]);
    }
}
