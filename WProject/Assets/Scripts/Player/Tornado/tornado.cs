using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tornado : MonoBehaviour
{
    shooting shooting;
    private float distance;
    public float minimumDistance = 6f, tornadoLifeTime = 6f, pullForce = 2f, rotateSpeed = 90f;
    private float nextDamageTick;
    public int DamagePerTick = 10;

    void Start()
    {
        nextDamageTick = Time.time;
        tornadoLifeTime = 5f;
    }
    void Update()
    {
        tornadoVaccun();
        tornadoLifeCounter();
    }
    void tornadoLifeCounter()
    {
        tornadoLifeTime -= Time.deltaTime;
        if (tornadoLifeTime < 0)
        {
            Destroy(gameObject);
        }
    }
    void tornadoVaccun()
    {
        Collider2D[] enemysToPull = Physics2D.OverlapCircleAll(transform.position, minimumDistance); //seleciona todos os objetos proximos do tornado
        foreach (Collider2D enemy in enemysToPull) //seleciona cada criatura do array de criaturas pego acima
        {
            if (enemy.CompareTag("Enemy"))//filtra os que tem tag de "Enemy"
            {
                //puxa inimigos, na direção do tornado de acordo com a massa*tempo*força do puxão
                enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, transform.position, enemy.GetComponent<Rigidbody2D>().mass * Time.deltaTime * pullForce);
                //gira inimigos
                //enemy.transform.RotateAround(Vector2.zero, transform.position, enemy.GetComponent<Rigidbody2D>().mass * rotateSpeed * Time.deltaTime);
                if (Time.time >= nextDamageTick)
                {
                    enemy.GetComponent<Ai_Enemy_Stats>().TakeDamage(DamagePerTick);
                    nextDamageTick = Time.time + 1;
                }
            }
        }
        //enemyObject.transform.position = Vector2.MoveTowards(enemyObject.transform.position, transform.position, enemyObject.GetComponent<Rigidbody2D>().mass * Time.deltaTime * pullForce);
        //buraco negro: enemyObject.GetComponent<Rigidbody2D>().AddForce((transform.position - enemyObject.transform.position) * pullForce);
    }
    void damageEnemy()
    {

    }
}