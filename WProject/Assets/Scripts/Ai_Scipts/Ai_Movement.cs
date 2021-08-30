using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_Movement : MonoBehaviour
{
    [SerializeField] internal Ai_Enemy_Stats ai_enemy_stats;
    [SerializeField] Transform Player;
    [SerializeField] Transform _EnemyHead;
    [SerializeField] Transform _Enemy;
    [SerializeField] LayerMask mask;
 
   
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(_EnemyHead.position, _EnemyHead.TransformDirection(Vector2.left), ai_enemy_stats.ViewDistance, mask);
        Debug.Log(hit != null);

        if (hit.collider != null)
        {
            Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            _Enemy.LookAt(Player);
            if (Vector2.Distance(_Enemy.position, Player.position) > ai_enemy_stats.StopDistance)
            {
                _Enemy.position = Vector2.MoveTowards(_Enemy.position, Player.position, ai_enemy_stats.Speed * Time.deltaTime);

            }
        }
    }

}
