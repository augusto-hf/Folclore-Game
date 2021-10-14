using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab, flamethrowerObject;
    private ParticleSystem flamethrower;

    public float bulletForce = 2.5f;
    public float attackSpeed = 2f;
    private float nextAttack = 0f;
    private int currentLoadout = 1;
    public bool isTornadoGoing = false;

    internal bool _PlayerStardDialogue;
    void Awake()
    {
        flamethrower = flamethrowerObject.GetComponent<ParticleSystem>();
    }
    // Update is called once per frame
    void Update()
    {
        attackSelect();
        if (currentLoadout == 1)
        {
            fireballShoot();
        }
        else if (currentLoadout == 2)
        {
            flamethrowerShoot();
        }
    }
    void attackSelect()
    {
        if (Input.GetButtonDown("Power Select 1"))
        {
            currentLoadout = 1;
            flamethrower.Stop();
        }
        if (Input.GetButtonDown("Power Select 2"))
        {
            currentLoadout = 2;
        }
    }
    void fireballShoot()
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
    void flamethrowerShoot()
    {
        if (Input.GetButtonDown("Fire") && _PlayerStardDialogue == false)
        {
            flamethrower.Play();
        }
        if (Input.GetButtonUp("Fire") && _PlayerStardDialogue == false)
        {
            flamethrower.Stop();
        }
    }
}
