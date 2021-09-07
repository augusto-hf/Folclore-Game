using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 10f;


    internal bool _PlayerStardDialogue;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && _PlayerStardDialogue == false)
        {
            Shoot();
        }
    }
    void Shoot()
    {
        //spawna o tiro
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position,firePoint.rotation);
        //chama o Rigid Body 2D da bala
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        //e usa o RB2D pra adicionar a força e acelerar a bala
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
