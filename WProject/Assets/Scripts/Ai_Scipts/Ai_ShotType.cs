using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_ShotType : MonoBehaviour
{
    [SerializeField] internal Ai_Enemy_Stats ai_enemy_stats;
    [SerializeField] internal Transform Player;
    [SerializeField] Transform _EnemyHead;
    [SerializeField] internal Transform _Enemy;
    [SerializeField] internal Transform _WalkBackpoint;
    [SerializeField] LayerMask mask;
    [SerializeField] Rigidbody2D _Barrel;
    public Animator Enemy;

    Ai_ShootingAttack ai_shootingattack;
    internal float _AgroCountDown;
    float fireRate;
    float TimetoFire;
    // fazer um sistema para que o inimigo se aveste do jogador quando ele esta muito dele e que ele ande em zique sague


    void Start()
    {
        fireRate = 3f;
        TimetoFire = Time.time;
        ai_shootingattack = GetComponentInChildren<Ai_ShootingAttack>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        _AgroCountDown = 100;
    }

    void Update()
    {
        EnemyBehaviorRange();
        Aim();
    }

    void Aim()
    {
        if (Player != null)
        {
            Vector2 look = Player.position - ai_shootingattack._GunBarrel.position;
            float Angulo = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg - 90f;
            _Barrel.rotation = Angulo;

            //Enemy
            Vector2 lookE = Player.position - _Enemy.position;
            float AnguloE = Mathf.Atan2(lookE.y, lookE.x) * Mathf.Rad2Deg - 90f;
            _Enemy.GetComponent<Rigidbody2D>().rotation = AnguloE;
        }
     
    }

    void EnemyBehaviorRange()
    {

        RaycastHit2D hit = Physics2D.Raycast(_EnemyHead.position, _EnemyHead.TransformDirection(Vector2.left), ai_enemy_stats.ViewDistance);

        if (_AgroCountDown > 0)
        {
            if (Vector2.Distance(_Enemy.position, Player.position) > ai_enemy_stats.StopDistance)
            {
                _Enemy.position = Vector2.MoveTowards(_Enemy.position, Player.position, ai_enemy_stats.Speed * Time.deltaTime);
            }
           
            if (Vector2.Distance(_Enemy.position, Player.position) <= ai_enemy_stats.StopDistance)
            {

               // _Enemy.position = Vector2.MoveTowards(_Enemy.position, _WalkBackpoint.position, ai_enemy_stats.Speed * Time.deltaTime);
                if (Time.time > TimetoFire)
                {
                    StartCoroutine(Anim());
                    ai_shootingattack.FireBallAttack();

                    TimetoFire = Time.time + fireRate;
                }

            }

            _AgroCountDown -= Time.deltaTime;
        }
        if (_AgroCountDown <= 0)
        {
            Player = null;
        }
    }

    IEnumerator Anim()
    {
        Enemy.SetBool("MelleAttack", true);

        yield return new WaitForSeconds(1f);
        Enemy.SetBool("MelleAttack", false);

    }




}
