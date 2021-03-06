using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{

    public string name;
    public Sprite NpcImage;
    [TextArea(3, 10)]
    public string[] sentences;
    public bool[] isNpcLines;
    public AudioClip[] voiceLines;
}