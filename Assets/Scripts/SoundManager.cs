using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField]
    private AudioClip click, point, death, bgMusic;
    // Start is called before the first frame update
    [SerializeField]
    private AudioSource soundFX, bgMusicSource;
    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void PlayClick()
    {
        soundFX.PlayOneShot(click);
    }
    public void PlayPoint()
    {
        soundFX.PlayOneShot(point);
    }
    public void PlayDeath()
    {
        soundFX.PlayOneShot(death);
    }
    public void PlayMusic()
    {
        bgMusicSource.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
