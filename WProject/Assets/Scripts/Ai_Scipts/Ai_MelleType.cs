using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_MelleType : MonoBehaviour
{
    [SerializeField] internal Ai_Enemy_Stats ai_enemy_stats;

    [SerializeField] internal Transform Player;
    [SerializeField] Transform _EnemyHead;
    [SerializeField] internal Transform _Enemy;
    [SerializeField] LayerMask mask;

    internal float _AgroCountDown;
  


    void Update()
    {
      EnemyBehaviorMelle();
    }
    

    
    void EnemyBehaviorMelle()
    {
        Ai_MelleAtack ai_melleatack = GetComponentInChildren<Ai_MelleAtack>();

        if (_AgroCountDown > 0)
        {
            if (Vector2.Distance(_Enemy.position, Player.position) > ai_enemy_stats.StopDistance)
            {
                _Enemy.position = Vector2.MoveTowards(_Enemy.position, Player.position, ai_enemy_stats.Speed * Time.deltaTime);

            }
            if (Vector2.Distance(_Enemy.position, Player.position) <= ai_enemy_stats.StopDistance)
            {

                ai_melleatack.MelleAttack();
            }
        }

   
    }

}
