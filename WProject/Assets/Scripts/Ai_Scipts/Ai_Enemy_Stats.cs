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
    //Dash
    public float dashSpeed;
    public float dashEnd;
    public float startDashTime;
    [SerializeField] GameObject Effect;

    public float força;
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
            
            StartCoroutine(Die());

        }
    }
   

    IEnumerator Die()
    {

        GameObject effect = Instantiate(Effect, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
        Destroy(effect, 5f);
    }




}
