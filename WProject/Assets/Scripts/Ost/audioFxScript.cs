using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioFxScript : Skill
{
    [SerializeField] AudioClip BGM_Clip, ambience_Clip, footstep_Clip, InventoryOpen_Clip, InventoryClose_Clip, PressButton_Clip, Fire_Clip, Tornado_Clip, LancaChamas_Clip;
    [SerializeField] float footstepsdelayBetweenClips;
    [SerializeField] float footstepsVolume = 1.0f, inventoryVolume = 1.0f, FxVolueme = 1.0f, AbilityVolume = 1.0f;
    [SerializeField] float BGMVolume = 1.0f, ambienceVolume = 1.0f, musicVolume = 1.0f, fireVolume = 1.0f, tornadoVolume = 1.0f, lanchaChamasVolume = 1.0f;
    private float footstepsTime;
    bool footstepsHavePlayed, inventoryState;
    [SerializeField] AudioSource BGM, ambience, footstepsSource, InventorySounds, PressButton, Fire, Tornado, LancaChamas;

    private void Start()
    {

        BGM.clip = BGM_Clip;
        ambience.clip = ambience_Clip;
        BGM.Play();
        ambience.Play();
    }
    void Update()
    {
        Volume();
        playFootstepsControl();
        playInventoryControl();
        playFireControl();
        playTornadoControl();
        playLancaChamasControl();
        
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

        //Ataques
        Fire.volume = fireVolume * AbilityVolume;
        Tornado.volume = tornadoVolume * AbilityVolume;
        LancaChamas.volume = lanchaChamasVolume * AbilityVolume;
    }

    void playFireControl()
    {
        if (Input.GetButtonDown("Fire") && _PlayerStardDialogue == false && Time.time > nextSkill)
        {
            Fire.PlayOneShot(Fire_Clip);
        }
    }

    void playTornadoControl()
    {
        if (Input.GetButtonDown("Power") && _PlayerStardDialogue == false && Time.time > nextSkill && IsInvoking("tornadoShoot"))
        {
            Fire.PlayOneShot(Tornado_Clip);
        }
    }

    void playLancaChamasControl()
    {
        if (Input.GetButtonDown("Fire") && currentLoadout == 2 && _PlayerStardDialogue == false && Time.time > nextSkill)
        {
            Fire.PlayOneShot(LancaChamas_Clip);
        }
    }

}
