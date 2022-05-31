using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource pickup;
    public AudioSource bgm;
    public AudioSource screamer1;
    public AudioSource screamer2;
    public AudioSource mainMenuMusic;
    public AudioSource pPlateOn;
    public AudioSource pPlateOff;
    public AudioSource linternaOn;
    public AudioSource linternaOff;
    public AudioSource pasos1;
    public AudioSource pasos2;
    public AudioSource jumpUp;
    public AudioSource jumpDown;
    public AudioSource doorOpen;
    public AudioSource doorClose;
    public AudioSource hollowRoar;
    public AudioSource accessDenied;
    public AudioSource alarmaNorway;
    public AudioSource alarmaTriple;
    public AudioSource derrumbe1;
    public AudioSource derrumbe2;
    public AudioSource derrumbe3;

    AudioSource[] allSounds;
    public bool isRunning;

    float volumenDeseadoScreamer;
    bool jumpDownIsReady;

    void Start()
    {
        if (instance) //esto es para que audiomanager sea unico. puse uno en cada escena, pero a traves de las escenas se mantiene vivo uno solo.
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this);

        volumenDeseadoScreamer = screamer1.volume; //ojo, esto significa que los 2 screamers tendran el mismo volumen

        allSounds = GetComponentsInChildren<AudioSource>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    //ARRANCAN LOS METODOS



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

    //MAIN MENU MUSIC
    public void PlayMainMenuMusic()
    {
        mainMenuMusic.Play();
    }
    public void StopMainMenuMusic()
    {
        mainMenuMusic.Stop();
    }


    //ALARMAS

    public void PlayAlarmaNorway()
    {
        alarmaNorway.Play();
    }
    public void StopAlarmaNorway()
    {
        alarmaNorway.Stop();
    }
    public void PlayAlarmaTriple()
    {
        alarmaTriple.Play();
    }
    public void StopAlarmaTriple()
    {
        alarmaTriple.Stop();
    }





    //SFX


    public void PlayDerrumbe(int derrumbeID)
    {
        switch(derrumbeID)
        {
            case 1:
                derrumbe1.Play();
                break;

            case 2:
                derrumbe2.Play();
                break;

            case 3:
                derrumbe3.Play();
                break;

            default:
                break;
        }
    }


    //HOLLOW ROAR
    public void PlayHollowRoar(Vector3 pos, float delayTime)
    {
        if (!hollowRoar.isPlaying)
        {
            hollowRoar.gameObject.transform.position = pos; //muevo al audiosource
            hollowRoar.PlayDelayed(delayTime);
        }
    }


    //PICKUPS SFX
    public void PlayPickup(float p)
    {
        pickup.pitch = p;
        pickup.Play();
    }

    public void PlayAccessDenied()
    {
        accessDenied.Play();
    }

    //PRESSURE PLATE SFX
    public void PlayPPlateOn(Vector3 pos)
    {
        pPlateOn.gameObject.transform.position = pos; //muevo al audiosource
        pPlateOn.Play();
    }
    public void PlayPPlateOff(Vector3 pos)
    {
        pPlateOff.gameObject.transform.position = pos; 
        pPlateOff.Play();
    }

    //PUERTAS
    public void PlayDoorOpen(Vector3 pos)
    {
        float randomPitch = Random.Range(0.95f, 1.05f);
        doorOpen.pitch = randomPitch;
        doorOpen.gameObject.transform.position = pos;
        doorOpen.Play();
    }
    public void PlayDoorClose(Vector3 pos)
    {
        float randomPitch = Random.Range(0.95f, 1.05f);
        doorClose.pitch = randomPitch;
        doorClose.gameObject.transform.position = pos;
        doorClose.Play();
    }

    public void PlayScreamer(int screamerID)
    {
        switch (screamerID)
        {
            case 1:
                screamer1.volume = volumenDeseadoScreamer;   //para resetear el volumen en caso de que otro metodo lo haya alterado
                screamer1.Play();
                break;

            case 2:
                screamer2.volume = volumenDeseadoScreamer;   //para resetear el volumen en caso de que otro metodo lo haya alterado
                screamer2.Play();
                break;

            default:
                break;
        }
    }
    public void FadeOutScreamer(int screamerID, float fadetime)
    {
        float timer = Time.time / fadetime;

        switch (screamerID)
        {
            case 1:
                screamer1.volume = Mathf.Lerp(1, 0, timer);
                break;

            case 2:
                screamer2.volume = Mathf.Lerp(1, 0, timer);
                break;

            default:
                break;
        }
    }
    public void StopScreamer(int screamerID)
    {
        switch (screamerID)
        {
            case 1:
                screamer1.Stop();
                break;

            case 2:
                screamer2.Stop();
                break;

            default:
                break;
        }
    }


    //LINTERNA ON/OFF
    public void PlayLinternaOn()
    {
        linternaOn.Play();
    }
    public void PlayLinternaOff()
    {
        linternaOff.Play();
    }


    //PASOS
    public void PlayPasos()
    {
        if (!isRunning)
        {
            if (pasos1.isPlaying == false && pasos2.isPlaying == false) //solo da play si no estaba sonando ya
            {
                float randomPitch = Random.Range(0.95f, 1.05f); // para un poquito de variedad
                int randomClip = Random.Range(0, 2); // 50/50 chances de reproducir uno o el otro
                if (randomClip == 0)
                {
                    pasos1.pitch = randomPitch;
                    pasos1.Play();
                }
                else
                {
                    pasos2.pitch = randomPitch;
                    pasos2.Play();
                }
            }
        }
        else
        {
            if (pasos1.isPlaying == false && pasos2.isPlaying == false) //solo da play si no estaba sonando ya
            {
                float randomPitch = Random.Range(1.1f, 1.2f); // para un poquito de variedad
                int randomClip = Random.Range(0, 2); // 50/50 chances de reproducir uno o el otro
                if (randomClip == 0)
                {
                    pasos1.pitch = randomPitch;
                    pasos1.Play();
                }
                else
                {
                    pasos2.pitch = randomPitch;
                    pasos2.Play();
                }
            }
        }
    }
    public void StopPasos()
    {
        pasos1.Stop();
        pasos2.Stop();
    }
    public void ChangePitchPasos(bool keyDown) //asi cuando corres suenan distinto
    {
        if (keyDown)
        {
            float randomPitch = Random.Range(1.1f, 1.2f);
            pasos1.pitch = randomPitch;
            pasos2.pitch = randomPitch;
        }
        else
        {
            float randomPitch = Random.Range(0.95f, 1.05f);
            pasos1.pitch = randomPitch;
            pasos2.pitch = randomPitch;
        }
    }


    //SALTO
    public void PlayJumpUp()
    {
        if (!jumpUp.isPlaying)
        {
            float randomPitch = Random.Range(0.95f, 1.05f); 
            jumpUp.pitch = randomPitch;
            jumpUp.Play();
            jumpDownIsReady = true;
        }
    }
    public void PlayJumpDown()
    {
        if (jumpDownIsReady)
        {
            if (!jumpDown.isPlaying)
            {
                float randomPitch = Random.Range(0.95f, 1.05f);
                jumpDown.pitch = randomPitch;
                jumpDown.Play();
                jumpDownIsReady = false;
            }
        }
    }



    //AUDIO TRIGGERS
    //a este metodo le pasas un sonido, duracion y volumen de fade, y te lo da play con fade
    public void TriggerSound(AudioSource auso, float fadeDuration, float initialVolume, float finalVolume, bool isPlay)
    {
        if (isPlay)
        {
            auso.Play();
            StartCoroutine(FadeAudioSource.StartFade(auso, fadeDuration, initialVolume, finalVolume));
        }
        else
        {
            auso.Stop();
        }
    }

    public void StopAll()
    {
        for (int i = 0; i < allSounds.Length; i++)
        {
            if (allSounds[i].isPlaying)
            {
                allSounds[i].Stop();
            }
        }
    }
}
