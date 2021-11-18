using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioFxScript : MonoBehaviour
{
    [SerializeField] AudioClip BGM_Clip, ambience_Clip, footstep_Clip, InventoryOpen_Clip, InventoryClose_Clip, PressButton_Clip;
    [SerializeField] float footstepsdelayBetweenClips;
    [SerializeField] float footstepsVolume = 1.0f, inventoryVolume = 1.0f, FxVolueme = 1.0f;
    [SerializeField] float BGMVolume = 1.0f, ambienceVolume = 1.0f, musicVolume = 1.0f;
    private float footstepsTime;
    bool footstepsHavePlayed, inventoryState;
    [SerializeField] AudioSource BGM, ambience, footstepsSource, InventorySounds, PressButton;

    private void Start()
    {
    
        BGM.clip = BGM_Clip;
        ambience.clip = ambience_Clip;
        BGM.Play();
        ambience.Play();
    }
    void Update()
    {
        playFootstepsControl();
        playInventoryControl();
        Volume();
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
    void Volume()
    {
        //trilha sonora e ambientação
        BGM.volume = BGMVolume * musicVolume;
        ambience.volume = ambienceVolume * musicVolume;

        // efeitos sonoros
        footstepsSource.volume = footstepsVolume * FxVolueme;
        InventorySounds.volume = inventoryVolume * FxVolueme;
    }
    
}
