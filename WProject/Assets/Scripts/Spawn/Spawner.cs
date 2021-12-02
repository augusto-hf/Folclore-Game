using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy, fireBall, spawnEffect;
    public float spawnRate;
    public int enemyCount;


    private float nextSpawn = 0f;

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Time.time > nextSpawn && fireBall.activeSelf && enemyCount > 0)
        {
            nextSpawn = Time.time + spawnRate;
            enemyCount--;
            GameObject effect = Instantiate(spawnEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
            Instantiate(enemy, transform.position, enemy.transform.rotation);
        }
    }
}
