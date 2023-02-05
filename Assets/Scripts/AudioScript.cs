using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioClip failed;
    public AudioClip success;
    public AudioClip buttonAttack;
    public AudioClip buttonCancel;
    public AudioClip ok;

    public void playOk()
    {
        GetComponent<AudioSource>().clip = ok;
        play();
    }

    public void playFailed()
    {
        GetComponent<AudioSource>().clip = failed;
        play();
    }

    public void playSuccess()
    {
        GetComponent<AudioSource>().clip = success;
        play();
    }

    public void play()
    {
        GetComponent<AudioSource>().Play();
    }

}
