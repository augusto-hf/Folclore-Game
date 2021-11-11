using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioFxScript : MonoBehaviour
{
    [SerializeField] AudioClip footstepClip;
    [SerializeField] float footstepsdelayBetweenClips;
    public float footstepsVolume = 1.0f;
    private float footstepsTime;
    bool footstepsHavePlayed;
    AudioSource BGM, footstepsSource;

    private void Start()
    {
        footstepsSource = transform.Find("footsteps").GetComponent<AudioSource>();
        BGM = transform.Find("BGM").GetComponent<AudioSource>();
    }
    void Update()
    {
        if (footstepsTime < (Time.time * 1000) && (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0))
        {
            PlayFootsteps();
        }
        else if (footstepsHavePlayed && Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            footstepsSource.Stop();     
        }
        fxVolume();
    }
    void PlayFootsteps()
    {
        footstepsSource.PlayOneShot(footstepClip);
        footstepsTime = (Time.time * 1000) + footstepsdelayBetweenClips;
        footstepsHavePlayed = true;
    }
    void fxVolume()
    {
        footstepsSource.volume = footstepsVolume;   
    }
}
