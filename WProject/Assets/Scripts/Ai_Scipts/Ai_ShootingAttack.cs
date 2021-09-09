using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_ShootingAttack : MonoBehaviour
{
    [SerializeField] internal Ai_Movement ai_Movement;
    [SerializeField] internal Ai_RangeAttackDamaeg ai_rangeAttackDamaeg;
    [SerializeField] Transform _ParentItem;
    public GameObject FireBall;


    [SerializeField] GameObject[] BulletGrup = new GameObject[16];
    [SerializeField] Transform _GunBarrel;
    int index;
    bool beginShoot;

    void Start()
    {
        for (int i = 0; i < 16; i++)
        {
            BulletGrup[i] = Instantiate(FireBall);
            BulletGrup[i].transform.SetParent(_ParentItem);
            BulletGrup[i].transform.SetPositionAndRotation(_ParentItem.position, _ParentItem.rotation);
        }
        StartCoroutine(Disebleaitem());

    }
   
   
   public void FireBallAttack()
    {
            GameObject bullet = Instantiate(FireBall, _GunBarrel.position, _GunBarrel.rotation);

    }

    IEnumerator Disebleaitem()
    {
        for (int i = 0; i < 16; i++)
        {
            BulletGrup[i].SetActive(false);
            Debug.Log("s");

        }
        yield return new WaitForSeconds(0.1f);
    }
    
 



}
