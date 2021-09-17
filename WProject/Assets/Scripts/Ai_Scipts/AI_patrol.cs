using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AI_patrol : MonoBehaviour
{
    private List<GameObject> Waypoints = new List<GameObject>();
    Transform Enemy;
    [SerializeField] internal Ai_Enemy_Stats ai_enemy_stats;
    [SerializeField] LayerMask mask;

    int index;
    void Start()
    {
       
        Waypoints = GameObject.FindGameObjectsWithTag("Waypoint").ToList();
    }

    void Walk()
    {
        Enemy.position = Vector2.MoveTowards(Enemy.position, Waypoints[index].transform.position, ai_enemy_stats.Speed * Time.deltaTime);
        RaycastHit2D hit = Physics2D.Raycast(Enemy.position, Enemy.TransformDirection(Vector2.left), ai_enemy_stats.ViewDistance, mask);


        if (Vector2.Distance(Enemy.position, Waypoints[index].transform.position) <= 1f)
        {
            index++;
            if (index >= Waypoints.Count)
            {
                index = 0;
            }
        }

        
    }
    
}
