using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_RangeAttackDamaeg : MonoBehaviour
{
    [SerializeField] GameObject Effect;
    [SerializeField] internal Ai_ShotType Ai_shotType;
    [SerializeField] internal Ai_ShootingAttack ai_shootingattack;
    [SerializeField] Player Healt;
    [SerializeField] Rigidbody2D Bullet;
    [SerializeField] Transform _gunBarrel;

    GameObject Enemy;
    GameObject EnemyHit;


    void Start()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        EnemyHit = GameObject.FindGameObjectWithTag("EnemyHitbox");

        Ai_shotType = Enemy.GetComponent<Ai_ShotType>();
        Bullet = gameObject.GetComponent<Rigidbody2D>();
        _gunBarrel = Ai_shotType._Barrel.transform;
        //Bullet.AddForce(_gunBarrel.up * Ai_shotType.ai_enemy_stats.forca, ForceMode2D.Impulse);

    }

 

    void Update()
    {
        colIgnore();
        Physics2D.IgnoreLayerCollision(6, 7);
    }

    void colIgnore()
    {
        Physics2D.IgnoreCollision(Enemy.GetComponent<Collider2D>(), Bullet.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(EnemyHit.GetComponent<Collider2D>(), Bullet.GetComponent<Collider2D>());

    }

    void danoAndknockback(Rigidbody2D RbPlayer)
    {

        Vector2 Direcao = Ai_shotType.Player.position - Ai_shotType._Enemy.transform.position;
        Direcao.y = 0;
        RbPlayer.AddForce(Direcao.normalized * Ai_shotType.ai_enemy_stats.forca, ForceMode2D.Force);
        Healt.TakeDamage(Ai_shotType.ai_enemy_stats.Damage);
        Healt = null;
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "PlayerHitboc")
        {
            Healt = collision.gameObject.GetComponent<Player>();
            danoAndknockback(collision.gameObject.GetComponent<Rigidbody2D>());
            
        }
        GameObject effect = Instantiate(Effect, transform.position, Quaternion.identity);
       

        Destroy(effect, 5f);
        Destroy(gameObject);
    }
}
