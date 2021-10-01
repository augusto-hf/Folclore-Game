using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_Doge : MonoBehaviour
{
    //Dash
    float startMoveSpeed;
    public float dashSpeed;
    public float dashEnd;
    private float dashTime;
    public float startDashTime;
    private int direction;
    private bool isDashing;
    private bool _BeginDash;
    Vector2 movementRef;
    private Transform _PBullet;

    [SerializeField] internal Rigidbody2D Enemy;

    [SerializeField] internal Ai_Enemy_Stats ai_enemy_stats;


    void Start()
    {
        ai_enemy_stats = gameObject.GetComponentInParent<Ai_Enemy_Stats>();
    }

    void FixedUpdate()
    {
        if (isDashing == true)
        {
            Enemy.MovePosition(Enemy.position + movementRef * ai_enemy_stats.Speed * Time.fixedDeltaTime);

        }

    }



    void Dash()
    {
        //recebe o comando de dar dash caso as variaveis do dash estejam zeradas
        if (_BeginDash == true || Input.GetKeyDown("s"))
        {//da o dash
            startMoveSpeed = ai_enemy_stats.Speed;
            movementRef = Enemy.position;
            isDashing = true;
            ai_enemy_stats.Speed = ai_enemy_stats.Speed * dashSpeed;
            dashTime = startDashTime;
        }
        else
        {
            if (dashTime > 0 || ai_enemy_stats.Speed > startMoveSpeed)
            {
                dashTime -= Time.deltaTime;

                ai_enemy_stats.Speed -= Time.deltaTime + dashEnd;

                if (ai_enemy_stats.Speed < startMoveSpeed)
                {
                    ai_enemy_stats.Speed = startMoveSpeed;
                }
            }
        }
        if (dashTime <= 0 && ai_enemy_stats.Speed == startMoveSpeed)
        {//reseta indicador de dash
            isDashing = false;

        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _BeginDash = true;
            //other

        }
    }
}
