using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_ShootingAttack : MonoBehaviour
{
    [SerializeField] internal Ai_ShotType ai_shottype;
    [SerializeField] internal Ai_RangeAttackDamaeg ai_rangeAttackDamaeg;
    [SerializeField] Transform _ParentItem;
    public GameObject FireBall;
    int ShootTime = 0;

    [SerializeField] internal Transform _GunBarrel;
    [SerializeField] internal Rigidbody2D _Rb_GunBarrel;
    int index;
    bool beginShoot;

 
   public void FireBallAttack()
    {

        GameObject bullet = Instantiate(FireBall, _GunBarrel.position, _GunBarrel.rotation);
        ShootTime++;
        if (ShootTime >= 5)
        {
            bullet.GetComponent<Ai_RangeAttackDamaeg>().FollwoPlayer = true;
            ShootTime = 0;
        }
        Debug.Log(Random.Range(0, 20) == 0);
        if (Random.Range(0,20) == 0)
        {
            bullet.GetComponent<Ai_RangeAttackDamaeg>().FollwoPlayer = true;
        }
 


    }





}
