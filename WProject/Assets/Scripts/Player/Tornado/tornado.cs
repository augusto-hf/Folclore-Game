using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tornado : MonoBehaviour
{
    shooting shooting;
    private GameObject enemyObject;
    private float distance, pullForce;
    public float minimumDistance = 2f;
    public float pullForceReference = 1f, pullForceMultplier;
    public float tornadoLifeTime = 6f;

    void Start()
    {
        enemyObject = GameObject.FindWithTag("Enemy");
        pullForce = pullForceReference;
        tornadoLifeTime = 5f;
    }
    void Update()
    {
        tornadoMove();
        tornadoPullForce();
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
    void tornadoMove()
    {

    }
    void tornadoPullForce()
    {
        if (pullForce <= pullForceReference * 2)
        {//aumenta o pullforce, mas não pode ser mais doque o dobro da original
            pullForce += Time.deltaTime + pullForce;
        }
    }
    void tornadoVaccun()
    {
        distance = Vector2.Distance(enemyObject.transform.position, transform.position);
        if (distance <= minimumDistance)
        {
            enemyObject.GetComponent<Rigidbody2D>().AddForce((transform.position - enemyObject.transform.position) * pullForce);
        }
    }
}