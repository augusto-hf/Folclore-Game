using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicScript : MonoBehaviour
{
    public AudioSource BGM;
    void Start()
    {
        BGM = GetComponent<AudioSource>();
    }
    void Update()
    {
        
    }
    void ChangeMusic(AudioClip music)
    {
        BGM.Stop();
        BGM.clip = music;
        BGM.Play();
    }
}
