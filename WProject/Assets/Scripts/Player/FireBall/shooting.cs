using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class shooting : MonoBehaviour
{
    public tornado tornado;
    public Transform firePoint;
    public GameObject bulletPrefab, Shield, skillTornado;
    private Rigidbody2D rbT;
    public float bulletForce = 10f;
    public float attackSpeed = 2f, skillSpeed = 8f, tornadoForce = 0.6f;
    private float nextAttack = 0f, nextSkill = 0f, tornadoTimer;
    private int currentLoadout;
    public bool isTornadoGoing = false;

    internal bool _PlayerStardDialogue;
    // Update is called once per frame
    void Update()
    {
        loadoutSelect();
        Shoot();
        if (currentLoadout == 1)
        {
            shield();
        }
        else if (currentLoadout == 2) {
            tornadoShoot();
        }
        if (isTornadoGoing)
        {
            tornadoBrake();
        }
    }
    void loadoutSelect()
    {
        if (Input.GetButtonDown("Power Select 1"))
        {
            currentLoadout = 1;
            Debug.Log("Power 1 Selected");
        }
        if (Input.GetButtonDown("Power Select 2"))
        {
            currentLoadout = 2;
            Debug.Log("Power 2 Selected");
        }
    }
    void Shoot()
    {
    if (Input.GetButtonDown("Fire") && _PlayerStardDialogue == false && Time.time > nextAttack)
    {
        //spawna o tiro
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        //chama o Rigid Body 2D da bala
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        //e usa o RB2D pra adicionar a força e acelerar a bala
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        nextAttack = Time.time + attackSpeed;
    }
    }
    void shield()
    {
        if (Input.GetButtonDown("Power"))
        {
            Shield.SetActive(true);
        }
        if (Input.GetButtonUp("Power"))
        {
            Shield.SetActive(false);
        }
    }
    void tornadoShoot()
    {
        if (Input.GetButtonDown("Power") && _PlayerStardDialogue == false && Time.time > nextSkill)
        {
            isTornadoGoing = true;
            GameObject tornado = Instantiate(skillTornado, firePoint.position, Quaternion.identity);
            rbT = tornado.GetComponent<Rigidbody2D>();
            rbT.AddForce(firePoint.up * tornadoForce, ForceMode2D.Impulse);
            nextSkill = Time.time + skillSpeed;
        }
    }
    void tornadoBrake()
    {
        if (tornado.tornadoLifeTime == tornado.tornadoLifeTime / 2)
        {
            rbT.velocity = Vector2.zero;
            isTornadoGoing = false;
        }
    }
}
