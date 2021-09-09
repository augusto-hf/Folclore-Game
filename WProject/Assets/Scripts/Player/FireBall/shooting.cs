using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Text cdText;
    public float bulletForce = 10f;
    public float attackSpeed = 2f;
    private float nextAttack = 0f;

    internal bool _PlayerStardDialogue;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && _PlayerStardDialogue == false && Time.time > nextAttack)
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
        nextAttack = Time.time + attackSpeed;
    }
}
