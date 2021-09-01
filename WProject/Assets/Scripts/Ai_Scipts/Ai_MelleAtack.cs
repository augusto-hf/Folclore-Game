using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_MelleAtack : MonoBehaviour
{
    [SerializeField] internal Ai_Movement ai_movement;
    public GameObject Attack;
    bool starCoumt;
    public float time;
    public float waitTime;
  public void MelleAttack()
    {
        starCoumt = true;
        waitTime -= Time.deltaTime;
        if (waitTime <= 0)
        {
            Attack.GetComponent<SpriteRenderer>().enabled = true;
            Attack.GetComponent<BoxCollider2D>().enabled = true;
        }
        
        if (starCoumt == true && waitTime <= 0)
        {
            time -= Time.deltaTime;
        }

        if (time <= 0)
        {
            Attack.GetComponent<SpriteRenderer>().enabled = false;
            Attack.GetComponent<BoxCollider2D>().enabled = false;
            starCoumt = false;
        }
       
    }

    void danoAmdknockback(Rigidbody2D RbPlayer)
    {
      
        Vector2 Direcao = ai_movement.Player.position - ai_movement._Enemy.transform.position;
        Direcao.y = 0;
        Debug.Log(Direcao.normalized * ai_movement.ai_enemy_stats.força);
        RbPlayer.AddForce(Direcao.normalized * ai_movement.ai_enemy_stats.força,ForceMode2D.Force);

        reset();

    }

    void reset()
    {
        Attack.GetComponent<SpriteRenderer>().enabled = false;
        Attack.GetComponent<BoxCollider2D>().enabled = false;
        starCoumt = false;
        time = 5f;
        waitTime = 3f;
        //playstop
        //combatmode
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            danoAmdknockback(other.gameObject.GetComponent<Rigidbody2D>());
        }

    }


    void OnTriggerExit2D(Collider2D other)
    {
     
        //Reseta o attaque e dar um cooldown para o attque
    }
}
