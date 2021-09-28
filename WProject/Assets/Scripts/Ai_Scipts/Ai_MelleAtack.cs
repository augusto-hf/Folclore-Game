using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_MelleAtack : MonoBehaviour
{
    [SerializeField] internal Ai_MelleType Ai_MelleType;
    [SerializeField] Player Healt;
    Rigidbody2D RbPlayer;
    bool starCoumt;

    public GameObject Attack;
    public float time;
    public float waitTime;
    public Animator Enemy;

    public void MelleAttack()
    {
        starCoumt = true;
        waitTime -= Time.deltaTime;
        if (waitTime <= 0)
        {
            //Attack.GetComponent<SpriteRenderer>().enabled = true;
            Attack.GetComponent<BoxCollider2D>().enabled = true;
            StartCoroutine(Anim());
        }
        if (starCoumt == true && waitTime <= 0)
        {
            time -= Time.deltaTime;
        }

        if (time <= 0)
        {
            reset();
            starCoumt = false;
        }
       
    }

    void danoAmdknockback()
    {/*
        Vector2 Direcao = Ai_MelleType.Player.position - Ai_MelleType._Enemy.transform.position;
        Direcao.y = 0;
        Debug.Log(Direcao.normalized * Ai_MelleType.ai_enemy_stats.força);
        RbPlayer.AddForce(Direcao.normalized * Ai_MelleType.ai_enemy_stats.força,ForceMode2D.Force);
        */
        Healt.TakeDamage(Ai_MelleType.ai_enemy_stats.Damage);
        


    }

    void reset()
    {
        //Attack.GetComponent<SpriteRenderer>().enabled = false;
        Attack.GetComponent<BoxCollider2D>().enabled = false;
        starCoumt = false;
        Healt = null;
        time = 1f;
        waitTime = 2f;
        //playstop
        //combatmode
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Healt = other.gameObject.GetComponentInParent<Player>();
           //RbPlayer = other.gameObject.GetComponent<Rigidbody2D>();
            danoAmdknockback();
        }

    }
    IEnumerator Anim()
    {
        Enemy.SetBool("MelleAttack", true);

        yield return new WaitForSeconds(1f);
        Enemy.SetBool("MelleAttack", false);

    }



}
