using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_ShootingAttack : MonoBehaviour
{
    [SerializeField] internal Ai_ShotType ai_shottype;
    [SerializeField] internal Ai_RangeAttackDamaeg ai_rangeAttackDamaeg;
    [SerializeField] Transform _ParentItem;
    [SerializeField] internal Transform _GunBarrel;
    [SerializeField] internal Rigidbody2D _Rb_GunBarrel;



    public GameObject FireBall;
    bool beginShoot;

 
   public void FireBallAttack()
    {
        GameObject bullet = Instantiate(FireBall, _GunBarrel.position, _GunBarrel.rotation);
    }



  
}
