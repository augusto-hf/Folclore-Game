using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioFxScript : MonoBehaviour
{
    [SerializeField] AudioClip[] clips;
    [SerializeField] float FootstepsdelayBerweenClips;
    private float footstepsTime;
    bool canPlay;
    public AudioSource footsteps;


    void Update()
    {
        if (footstepsTime < Time.time && (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0))
        {
            PlayFootsteps();
        }
        else if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            //footsteps.Pause();
            
        }

        if (!canPlay)
        {

        }
    }
    void PlayFootsteps()
    {
        int clipIndex = Random.Range(0, clips.Length);
        AudioClip clip = clips[clipIndex];
        footsteps.PlayOneShot(clip);
        footstepsTime = (Time.time * 1000) + FootstepsdelayBerweenClips;
    }
}
