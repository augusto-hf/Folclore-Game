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
    public float Speed;
    public float StopDistance;
    public float Aggro;

    public float for�a;
    void Start()
    {
        VidaAtual = Health;
    }

    public void TakeDamage(int Dano)
    {
        VidaAtual -= Dano;
        Health = VidaAtual;
        Debug.Log("Vida atual:" + Health);
        if (Health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }




}
