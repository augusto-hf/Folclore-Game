using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject tro�o1;
    public float spawnRate;

    private float nextSpawn = 0f;

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawn && tro�o1.activeSelf)
        {
            nextSpawn = Time.time + spawnRate;

            Instantiate(enemy, transform.position, enemy.transform.rotation);
        }
        
    }
}
