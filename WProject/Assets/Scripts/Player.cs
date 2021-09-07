using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int maxHealth = 100;
    public int maxBlindness = 100;
    public int currentBlindness;
    public int currentHealth;

    public HealthBar healthBar;
    public BlindnessBar blindnessBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        currentBlindness = maxBlindness;
        blindnessBar.SetMaxBlindness(maxBlindness);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentBlindness -= damage;
        healthBar.SetHealth(currentHealth);
        blindnessBar.SetBlindness(currentBlindness);
    }
}
