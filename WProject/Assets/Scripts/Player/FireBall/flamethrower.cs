using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flamethrower : MonoBehaviour
{
    public int Damage = 1;
    private float tickTime = 1f, nextTick;
    
    // Start is called before the first frame update
  
    // Update is called once per frame
    void OnParticleCollision(GameObject collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && Time.time > nextTick)
        {
            collision.gameObject.GetComponent<Ai_Enemy_Stats>().TakeDamage(Damage);
            nextTick = Time.time + tickTime;
        }
    }
}
