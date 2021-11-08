using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public int Damage = 25;
    public float bulletLifetime;
    public GameObject hitEffect;

    private void Start()
    {
            Physics2D.IgnoreLayerCollision(7, 8);
    }

    void Update()
    {
        
        bulletLifetime -= Time.deltaTime;
        if (bulletLifetime < 0)
        {
            Destroy(gameObject);
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.CompareTag("Enemy"))
       {
            collision.gameObject.GetComponent<Ai_Enemy_Stats>().TakeDamage(Damage);
       }
        Destroy(gameObject);
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        
    }
}