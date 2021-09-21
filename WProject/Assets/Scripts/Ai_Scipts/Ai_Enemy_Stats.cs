using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_Enemy_Stats : MonoBehaviour
{
    public int Health;
    int VidaAtual;
    public int Damage;
    public int TypeOfEnemy;/*Tipod o inimigo
                            * 0 = Melle
                            * 1 = range
                            */
    public float ViewDistance;
    public int Speed;
    public float StopDistance;
    public float Aggro;

    public float força;
    void Start()
    {
        VidaAtual = Health;
    }

    public void TomarDamage(int Dano)
    {
        Dano -= VidaAtual;
        Health = VidaAtual;
    }




}
