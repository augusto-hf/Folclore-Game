using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tornado : MonoBehaviour
{
    shooting shooting;
    private GameObject enemyObject;
    private float distance;
    public float minimumDistance = 2f;
    public float pullForce = 0.1f;
    public float tornadoLifeTime = 6f;

    void Start()
    {
        enemyObject = GameObject.FindWithTag("Enemy");
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
        distance = Vector2.Distance(enemyObject.transform.position, transform.position);
        if (distance <= minimumDistance)
        {//puxa inimigos, na direção do tornado de acordo com a massa*tempo*força do puxão
            enemyObject.transform.position = Vector2.MoveTowards(enemyObject.transform.position, transform.position, enemyObject.GetComponent<Rigidbody2D>().mass * Time.deltaTime * pullForce);
            //buraco negro: enemyObject.GetComponent<Rigidbody2D>().AddForce((transform.position - enemyObject.transform.position) * pullForce);
        }
    }
}