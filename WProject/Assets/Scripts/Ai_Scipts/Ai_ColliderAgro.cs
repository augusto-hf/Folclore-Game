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
        ai_enemy_stats = gameObject.GetComponentInParent<Ai_Enemy_Stats>();
    }


    void GetPlayer(Transform player)
    {
        Player = player;
        _AgroCountDown = ai_enemy_stats.Aggro;
        switch (ai_enemy_stats.TypeOfEnemy)
        {
            case 0:
                Ai_MelleType ai_melletype = gameObject.GetComponentInParent<Ai_MelleType>();
                ai_melletype.Player = Player;
                ai_melletype._AgroCountDown = _AgroCountDown;
                break;
            case 1:
               
                Ai_ShotType ai_shottype = gameObject.GetComponentInParent<Ai_ShotType>();
                ai_shottype.Player = Player;
                ai_shottype._AgroCountDown = _AgroCountDown;
                break;

            default:
                break;
        }
    }

   

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GetPlayer(other.transform);

        }

    }
}
