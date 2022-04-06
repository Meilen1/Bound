using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource pickup;
    public AudioSource bgm;
    public AudioSource screamer1;
    public AudioSource mainMenuMusic;

    void Start()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        
    }

    //ARRANCAN LOS METODOS

    //PICKUPS SFX
    public void PlayPickup(float p)
    {
        pickup.pitch = p;
        pickup.Play();
    }


    //BACKGROUNDMUSIC
    public void PlayBGM()
    {
        bgm.Play();
    }
    public void StopBGM()
    {
        bgm.Stop();
    }
    public void FadeInBGM(float fadetime)
    {
        float timer = Time.time / fadetime;
        bgm.volume = Mathf.Lerp(0, 1, timer);
    }
    public void FadeOutBGM(float fadetime)
    {
        float timer = Time.time / fadetime;
        bgm.volume = Mathf.Lerp(1, 0, timer);
    }



    //SCREAMER SFX
    public void PlayScreamer1()
    {
        screamer1.volume = 0.8f;   
        screamer1.Play();
    }
    public void FadeOutScreamer1(float fadetime)
    {
        float timer = Time.time / fadetime;
        screamer1.volume = Mathf.Lerp(1, 0, timer);
    }
    public void StopScreamer1()
    {
        screamer1.Stop();
    }


    //MAIN MENU MUSIC
    public void PlayMainMenuMusic()
    {
        mainMenuMusic.Play();
    }
    public void StopMainMenuMusic()
    {
        mainMenuMusic.Stop();
    }
}
