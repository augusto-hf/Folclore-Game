using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_ShootingAttack : MonoBehaviour
{
    [SerializeField] internal Ai_Movement ai_Movement;
    [SerializeField] Transform _ParentItem;
    public GameObject FireBall;

    
    GameObject[] BulletGrup = new GameObject[16];
    Transform _GunBarrel;
    int index;


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

    void FireBallAttack()
    {
        BulletGrup[index].SetActive(true);
        BulletGrup[index].transform.position = _GunBarrel.position;
        BulletGrup[index].GetComponent<Rigidbody2D>().AddForce(transform.right * ai_Movement.ai_enemy_stats.força, ForceMode2D.Force);
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
