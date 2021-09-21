using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_Damage : MonoBehaviour
{
    [SerializeField]Player Healt;
    int VidaAtual;
    int SomaDamage;
    int Result;
    
    
    public void Damage(int Dano)
    {
        SomaDamage = Dano;
        Result = SomaDamage - VidaAtual;
        //Healt = Result;
    }
}
