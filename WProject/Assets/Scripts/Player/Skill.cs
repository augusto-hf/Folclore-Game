using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    public Transform firePoint;
    private Rigidbody2D rbT;
    
    internal bool _PlayerStardDialogue;

    [Header("Tornado Ability")]
    public tornado tornado;
    public GameObject skillTornado;
    public float skillSpeed = 8f, tornadoForce = 0.6f;
    public float nextSkill = 0f, tornadoTimer;
    public bool isTornadoGoing = false;

    [Header("FireBall Ability")]

    [Header("Shield Ability")]
    public GameObject Shield;

    [Header("Generic Ability")]
    public Image imageRenderer;
    public Sprite[] spriteArray;
    public Image abilityImageBW;
    public Sprite[] spriteArrayBW;
    public float cooldown = 8;
    bool isCooldown = false;
    public KeyCode abilityBW;
    public int currentLoadout;

    // Start is called before the first frame update
    void Start()
    {
        abilityImageBW.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        AbilityBW();
        loadoutSelect();
        if (currentLoadout == 1)
        {
            shield();
        }
        else if (currentLoadout == 2)
        {
            tornadoShoot();
        }
        if (isTornadoGoing)
        {
            tornadoBrake();
        }
    }

    void AbilityBW()
    {
        if(Input.GetKey(abilityBW) && isCooldown == false)
        {
            isCooldown = true;
            abilityImageBW.fillAmount = 1;
        }

        if (isCooldown)
        {
            abilityImageBW.fillAmount -= 1 / cooldown * Time.deltaTime;

            if(abilityImageBW.fillAmount <= 0)
            {
                abilityImageBW.fillAmount = 0;
                isCooldown = false;
            }
        }
    }

   

    public void loadoutSelect()
    {
        if (Input.GetButtonDown("Power Select 1"))
        {
            currentLoadout = 1;
            imageRenderer.sprite = spriteArray[0];
            abilityImageBW.sprite = spriteArray[0];
            Debug.Log("Power 1 Selected");
        }
        if (Input.GetButtonDown("Power Select 2"))
        {
            currentLoadout = 2;
            imageRenderer.sprite = spriteArray[1];
            abilityImageBW.sprite = spriteArray[1];
            Debug.Log("Power 2 Selected");
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
    public void tornadoShoot()
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

