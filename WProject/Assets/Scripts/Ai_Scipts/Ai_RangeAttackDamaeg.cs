using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_RangeAttackDamaeg : MonoBehaviour
{
    [SerializeField] GameObject Effect;
    [SerializeField] internal Ai_ShotType Ai_shotType;
    [SerializeField] internal Ai_ShootingAttack ai_shootingattack;
    [SerializeField] Rigidbody2D Bullet;
    GameObject Enemy;
    internal bool Clone;
    internal bool FollwoPlayer;
    void Start()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        Ai_shotType = Enemy.GetComponent<Ai_ShotType>();
        ai_shootingattack = Enemy.GetComponent<Ai_ShootingAttack>();
        Bullet = gameObject.GetComponent<Rigidbody2D>();
        Bullet.AddForce(ai_shootingattack._GunBarrel.transform.up * Ai_shotType.ai_enemy_stats.força, ForceMode2D.Impulse);

        if (Clone == false)
        {
            ai_shootingattack.CreateBullet(new Vector2(1f, 0));
            ai_shootingattack.CreateBullet(new Vector2(-1f, 0));
        }
      


        if (FollwoPlayer == true)
        {
            FlowPlayer();
        }
    }


    void FlowPlayer()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        Vector2 MoveDi = (Player.transform.position - transform.position).normalized * Ai_shotType.ai_enemy_stats.força;
        Bullet.velocity = new Vector2(MoveDi.x, MoveDi.y);
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, Ai_shotType.ai_enemy_stats.força * Time.deltaTime);
        
    }



    void danoAndknockback(Rigidbody2D RbPlayer)
    {

        Vector2 Direcao = Ai_shotType.Player.position - Ai_shotType._Enemy.transform.position;
        Direcao.y = 0;
        RbPlayer.AddForce(Direcao.normalized * Ai_shotType.ai_enemy_stats.força, ForceMode2D.Force);

        //dar dano
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "Player")
        {
            danoAndknockback(collision.gameObject.GetComponent<Rigidbody2D>());
        }
       // GameObject effect = Instantiate(Effect, transform.position, Quaternion.identity);
       

      //  Destroy(effect, 5f);
        //Destroy(gameObject);
    }
}
