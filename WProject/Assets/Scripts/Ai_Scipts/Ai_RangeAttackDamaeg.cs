using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_RangeAttackDamaeg : MonoBehaviour
{
    [SerializeField] GameObject Effect;
    [SerializeField] internal Ai_Movement ai_Movement;
    [SerializeField] Rigidbody2D Bullet;
    GameObject Enemy;
    Transform _GunBarrel;

    void Start()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        ai_Movement = Enemy.GetComponent<Ai_Movement>();
        Bullet = gameObject.GetComponent<Rigidbody2D>();
        Debug.Log("20");
        Debug.Log(Bullet);
        Bullet.AddForce(Enemy.transform.right * ai_Movement.ai_enemy_stats.força * -1, ForceMode2D.Impulse);
    }



    void danoAndknockback(Rigidbody2D RbPlayer)
    {

        Vector2 Direcao = ai_Movement.Player.position - ai_Movement._Enemy.transform.position;
        Direcao.y = 0;
        RbPlayer.AddForce(Direcao.normalized * ai_Movement.ai_enemy_stats.força, ForceMode2D.Force);

        //dar dano
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "Player")
        {
            danoAndknockback(collision.gameObject.GetComponent<Rigidbody2D>());
        }
        GameObject effect = Instantiate(Effect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }
}
