using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_ShootingAttack : MonoBehaviour
{
    [SerializeField] internal Ai_Movement ai_Movement;
    [SerializeField] internal Ai_RangeAttackDamaeg ai_rangeAttackDamaeg;
    [SerializeField] Transform _ParentItem;
    public GameObject FireBall;


    [SerializeField] Transform _GunBarrel;
    int index;
    bool beginShoot;

    void Start()
    {
   

    }
   
   
   public void FireBallAttack()
    {
            GameObject bullet = Instantiate(FireBall, _GunBarrel.position, _GunBarrel.rotation);
        if (Random.Range(0,50f) == 1)
        {
            bullet.GetComponent<Ai_RangeAttackDamaeg>().FollwoPlayer = true;
        }
 


    }





}
