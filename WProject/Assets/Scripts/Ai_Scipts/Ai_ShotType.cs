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
   
    private Vector3 startingPosition;
    public Transform followTarget;
    private Vector3 targetPos;
    public float moveSpeed;
    public float offSetX;
    public float offSetY;
    public float offSetZ;
    public bool smoothMovement;

    float _AgroCountDown;
    float fireRate;
    float TimetoFire;


    void Start()
    {
        fireRate = 1f;
        TimetoFire = Time.time;
        startingPosition = transform.position;
    }

    void Update()
    {
        EnemyBehaviorRange();
    }

    void EnemyBehaviorRange()
    {

        if (_Enemy != null)
        {
            targetPos = new Vector3(_Enemy.position.x + offSetX, _Enemy.position.y + offSetY, transform.position.z + offSetZ);
            Vector3 velocity = (targetPos - transform.position) * moveSpeed;
            if (smoothMovement)
            {
                transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, 1.0f, Time.deltaTime);
            }
            else
            {
                transform.position = targetPos;
            }
        }
        RaycastHit2D hit = Physics2D.Raycast(_EnemyHead.position, _EnemyHead.TransformDirection(Vector2.left), ai_enemy_stats.ViewDistance);
        Ai_ShootingAttack ai_shootingattack = GetComponentInChildren<Ai_ShootingAttack>();
        Debug.Log(hit.collider.gameObject.tag == "Player");

        Debug.DrawRay(_EnemyHead.position, _EnemyHead.TransformDirection(Vector2.left), Color.green);
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
            Player = null;
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
