using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_ShootingAttack : MonoBehaviour
{
    [SerializeField] internal Ai_ShotType ai_shottype;
    [SerializeField] internal Ai_RangeAttackDamaeg ai_rangeAttackDamaeg;
    [SerializeField] Transform _ParentItem;
    public GameObject FireBall;


    [SerializeField] Transform _GunBarrel;
    int index;
    bool beginShoot;

 
   public void FireBallAttack()
    {
        GameObject bullet = Instantiate(FireBall, _GunBarrel.position, _GunBarrel.rotation);
        Debug.Log(Random.Range(0, 20) == 0);
        if (Random.Range(0,20) == 0)
        {
            bullet.GetComponent<Ai_RangeAttackDamaeg>().FollwoPlayer = true;
        }
 


    }





}
