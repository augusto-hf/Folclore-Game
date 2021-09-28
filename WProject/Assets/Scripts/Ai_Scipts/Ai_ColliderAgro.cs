using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_ColliderAgro : MonoBehaviour
{


    [SerializeField] internal Transform Player;
    [SerializeField] internal Ai_Enemy_Stats ai_enemy_stats;
    float  _AgroCountDown;
    void Start()
    {
        switch (ai_enemy_stats.TypeOfEnemy)
        {
            case 0:
                //Ai_ShotType ai_shottype;
                break;
            case 1:
                break;

            default:
                break;
        }
    }

    void GetPlayer(Transform player)
    {
        Player = player;
        _AgroCountDown = ai_enemy_stats.Aggro;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GetPlayer(other.transform);

        }
    }
}
