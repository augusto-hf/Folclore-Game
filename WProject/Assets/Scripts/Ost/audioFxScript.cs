using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioFxScript : MonoBehaviour
{
    [SerializeField] AudioClip BGM_Clip, ambience_Clip, footstep_Clip, InventoryOpen_Clip, InventoryClose_Clip, PressButton_Clip;
    [SerializeField] float footstepsdelayBetweenClips;
    public float footstepsVolume = 1.0f, inventoryVolume = 1.0f;
    private float footstepsTime;
    bool footstepsHavePlayed, inventoryState;
    AudioSource BGM, ambience, footstepsSource, InventorySounds, PressButton;

    private void Start()
    {
        BGM = transform.Find("BGM").GetComponent<AudioSource>();
        ambience = transform.Find("ambience").GetComponent<AudioSource>();
        footstepsSource = transform.Find("footsteps").GetComponent<AudioSource>();
        InventorySounds = transform.Find("InventorySounds").GetComponent<AudioSource>();

        PressButton = transform.Find("PressButton").GetComponent<AudioSource>();

        BGM.clip = BGM_Clip;
        ambience.clip = ambience_Clip;
    }
    void Update()
    {
        BGMControl();
        ambienceControl();
        playFootstepsControl();
        playInventoryControl();
        fxVolume();
    }
    void BGMControl()
    {
        BGM.Play();
    }
    void ambienceControl()
    {
        ambience.Play();       
    }
    void playFootstepsControl()
    {
        if (footstepsTime < (Time.time * 1000) && (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0))
        {
            footstepsSource.PlayOneShot(footstep_Clip);
            footstepsTime = (Time.time * 1000) + footstepsdelayBetweenClips;
            footstepsHavePlayed = true;
        }
        else if (footstepsHavePlayed && Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            footstepsSource.Stop();
        }
    }
    void playInventoryControl()
    {
        if (Input.GetButtonDown("Inventory") && !inventoryState)
        {
            InventorySounds.PlayOneShot(InventoryOpen_Clip);
            inventoryState = true;
        }
        else if (Input.GetButtonDown("Inventory") && inventoryState)
        {
            InventorySounds.PlayOneShot(InventoryClose_Clip);
            inventoryState = false;
        }
    }
    void fxVolume()
    {
        footstepsSource.volume = footstepsVolume;
        InventorySounds.volume = inventoryVolume;
    }
    
}
