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
            Player Healt = collision.gameObject.GetComponentInParent<Player>();
            Rigidbody2D bPlayer = collision.gameObject.GetComponentInParent<Rigidbody2D>();
            ai_damage.Damage(ai_enemy_stats.Damage, Healt, bPlayer);
        }

    }
}
