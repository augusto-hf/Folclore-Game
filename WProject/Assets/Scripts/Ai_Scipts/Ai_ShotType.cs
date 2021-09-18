using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_ShotType : MonoBehaviour
{
    [SerializeField] internal Ai_Enemy_Stats ai_enemy_stats;

    [SerializeField] internal Transform Player;
    [SerializeField] Transform _EnemyHead;
    [SerializeField] internal Transform _Enemy;
    [SerializeField] LayerMask mask;


    float _AgroCountDown;
    float fireRate;
    float TimetoFire;


    void Start()
    {
        fireRate = 1f;
        TimetoFire = Time.time;
        Player = GameObject.FindWithTag("Player").transform;
        _AgroCountDown = 100f;
    }

    void Update()
    {
        EnemyBehaviorRange();
    }

    void EnemyBehaviorRange()
    {
        Ai_ShootingAttack ai_shootingattack = GetComponentInChildren<Ai_ShootingAttack>();


      
        RaycastHit2D hit = Physics2D.Raycast(_EnemyHead.position, _EnemyHead.TransformDirection(Vector2.left), ai_enemy_stats.ViewDistance);

        if (_AgroCountDown > 0)
        {
            
            Vector2 look = Player.position - ai_shootingattack._GunBarrel.position;
            float Angulo = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg - 90f;
            ai_shootingattack._Rb_GunBarrel.rotation = Angulo;
  
            if (Vector2.Distance(_Enemy.position, Player.position) > ai_enemy_stats.StopDistance)
            {
                _Enemy.position = Vector2.MoveTowards(_Enemy.position, Player.position, ai_enemy_stats.Speed * Time.deltaTime);
            }

            if (Vector2.Distance(_Enemy.position, Player.position) <= ai_enemy_stats.StopDistance)
            {
                if (Time.time > TimetoFire)
                {
                    ai_shootingattack.FireBallAttack();
                    TimetoFire = Time.time + fireRate;
                }


            }
            _AgroCountDown -= Time.deltaTime;


        }
        if (_AgroCountDown <= 0)
        {
            //Player = null;
        }
    }

    void GetPlayer()
    {
        //Player = hit.transform;
        _AgroCountDown = ai_enemy_stats.Aggro;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GetPlayer();
    }

}
