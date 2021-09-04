using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_RangeAttackDamaeg : MonoBehaviour
{
    [SerializeField] GameObject Effect;

    [SerializeField] internal Ai_Movement ai_Movement;


    void Start()
    {
        ai_Movement = FindObjectOfType<Ai_Movement>();

    }

    void danoAndknockback(Rigidbody2D RbPlayer)
    {

        Vector2 Direcao = ai_Movement.Player.position - ai_Movement._Enemy.transform.position;
        Direcao.y = 0;
        RbPlayer.AddForce(Direcao.normalized * ai_Movement.ai_enemy_stats.força, ForceMode2D.Force);

        //dar dano
    }
    void OnColisionEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            danoAndknockback(other.gameObject.GetComponent<Rigidbody2D>());
        }
        GameObject effect = Instantiate(Effect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }
}
