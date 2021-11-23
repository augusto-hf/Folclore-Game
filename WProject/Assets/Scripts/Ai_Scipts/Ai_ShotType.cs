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
    public Animator anim;
    public Transform Pos;
    public float Zvaule;
    float i, x;

    Ai_ShootingAttack ai_shootingattack;
    internal float _AgroCountDown;
    float fireRate;
    float TimetoFire;


    void Start()
    {
        fireRate = 3f;
        TimetoFire = Time.time;
        ai_shootingattack = GetComponentInChildren<Ai_ShootingAttack>();
        ai_enemy_stats = GetComponent<Ai_Enemy_Stats>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        //_Barrel = GetComponentInChildren<Rigidbody2D>();

    }

    void Update()
    {
        Aim();
        EnemyBehaviorRange();
        Animation();
    }

    void Animation()
    {
        Zvaule = Pos.eulerAngles.z;
        if (Zvaule >= 90 && Zvaule < 135)
        {
            i = 0;
            x = 1;
        }
        if (Zvaule >= 45 && Zvaule < 65)
        {
          
        }
        if (Zvaule >= 65 && Zvaule < 90)
        {
            i = -1;
            x = 0;
        }
        else if (Zvaule >= 91 && Zvaule < 140)
        {
            i = -1;
            x = -1;


        }
        else if (Zvaule >= 180 && Zvaule < 225)
        {
            i = 0;
            x = 1;


        }
        else if (Zvaule >= 225 && Zvaule < 270)
        {
            i = 1;
            x = -1;


        }
        else if (Zvaule >= 270 && Zvaule < 315)
        {
            i = 1;
            x = 0;


        }
        else if (Zvaule >= 315 && Zvaule < 350)
        {
          
        }
        else if (Zvaule >= 0 && Zvaule < 45 || Zvaule > 350)
        {
            i = 0;
            x = -1;


        }

        anim.SetFloat("Horizontal", i);
        anim.SetFloat("Vertical", x);
        anim.SetFloat("Vel", 1f);
    }

    void Aim()
    {
        if (Player != null)
        {
            Vector2 look = Player.position - _Barrel.transform.position;
            float Angulo = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg - 90f;
            _Barrel.rotation = Angulo;
         


        }

    }

    void EnemyBehaviorRange()
    {

        RaycastHit2D hit = Physics2D.Raycast(_EnemyHead.position, _EnemyHead.TransformDirection(Vector2.left), ai_enemy_stats.ViewDistance);

            if (Vector2.Distance(_Enemy.position, Player.position) > ai_enemy_stats.StopDistance)
            {
                _Enemy.position = Vector2.MoveTowards(_Enemy.position, Player.position, ai_enemy_stats.Speed * Time.deltaTime);
            }

        if (Vector2.Distance(_Enemy.position, Player.position) <= ai_enemy_stats.StopDistance)
            {

                //_Enemy.position = Vector2.MoveTowards(_Enemy.position, _WalkBackpoint.position, ai_enemy_stats.Speed * Time.deltaTime);
                if (Time.time > TimetoFire)
                {
                    //StartCoroutine(Anim());
                    //ai_shootingattack.FireBallAttack();

                    TimetoFire = Time.time + fireRate;
                }

            }

        if (Time.time > TimetoFire)
        {
            //StartCoroutine(Anim());
            //ai_shootingattack.FireBallAttack();

            TimetoFire = Time.time + fireRate;
        }


    }

    IEnumerator Anim()
    {
        //Enemy.SetBool("MelleAttack", true);

        yield return new WaitForSeconds(1f);
        //Enemy.SetBool("MelleAttack", false);

    }




}
