using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_Doge : MonoBehaviour
{
    float startMoveSpeed;
    int DougeChance;
    private int direction;

    [SerializeField] private bool isDashing;
    [SerializeField] private float dashTime;
    [SerializeField] private bool _BeginDash;
    [SerializeField] private Transform Doget, Doger;
    [SerializeField] internal Rigidbody2D Enemy;
    [SerializeField] internal Ai_Enemy_Stats ai_enemy_stats;


    void Start()
    {
        ai_enemy_stats = gameObject.GetComponentInParent<Ai_Enemy_Stats>();
    }

    void FixedUpdate()
    {
        

    }

   

    void Dash()
    {
        if (_BeginDash == true && dashTime <= 0 )
        {
            isDashing = true;
            //ai_enemy_stats.Speed = ai_enemy_stats.Speed * ai_enemy_stats.dashSpeed;
            dashTime = ai_enemy_stats.startDashTime;
        }
        
    }

    void Update()
    {
        if (isDashing == true)
        {
            float Ran = 0;
            Ran = Random.Range(0, 1);
            switch (Ran)
            {
                case 0:
                    Enemy.position = Vector2.MoveTowards(Enemy.position, Doget.position, ai_enemy_stats.dashSpeed);
                    break;
                case 1:
                    Enemy.position = Vector2.MoveTowards(Enemy.position, Doger.position, ai_enemy_stats.dashSpeed);
                    break;


                default:
                    break;
            }
            //Enemy.velocity = Vector2.up * ai_enemy_stats.dashSpeed;
            //Enemy.MovePosition(Enemy.position * ai_enemy_stats.Speed * Time.fixedDeltaTime);
        }
        if (dashTime > 0)
        {
            dashTime -= Time.deltaTime;
        }
        if (dashTime <= 0 )
        {
            //dashTime = ai_enemy_stats.startDashTime;
            //Enemy.velocity = Enemy.position * ai_enemy_stats.Speed;
            isDashing = false;
            _BeginDash = false;

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DougeChance = Random.Range(0, 50);

        Debug.Log(DougeChance == 1);
        if (other.tag == "Player_Bullet" && DougeChance == 1)
        {
            _BeginDash = true;
            Dash();

        }
    }
}
