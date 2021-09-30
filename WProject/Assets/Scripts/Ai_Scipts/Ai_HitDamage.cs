using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_HitDamage : MonoBehaviour
{

    [SerializeField] AI_Damage ai_damage;
    int Dano;
    [SerializeField] internal Ai_Enemy_Stats ai_enemy_stats;

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "Player")
        {
            Player Healt = collision.gameObject.GetComponent<Player>();
            ai_damage.Damage(ai_enemy_stats.Damage, Healt);
        }

    }
}
