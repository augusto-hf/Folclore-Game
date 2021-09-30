using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int maxHealth;
    public int maxBlindness;
    public int currentBlindness;
    public int currentHealth;

    public HealthBar healthBar;
    public BlindnessBar blindnessBar;

    public int gold = 0;

    public Quest quest;
    public bool IVframe;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        currentBlindness = maxBlindness;
        blindnessBar.SetMaxBlindness(maxBlindness);

        if (quest.isActive)
        {
            quest.goal.EnemyKilled();
            if (quest.goal.IsReached())
            {
                gold += quest.goldReward;
                quest.Complete();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            TakeDamage(20);
        }
        if (currentHealth <=0)
        {
            Debug.Log("Morri");
        }
        if (IVframe == true)
        {
            Physics2D.IgnoreLayerCollision(6, 7, true);
        }
    }

   public void TakeDamage(int damage)
    {
        if (IVframe == false)
        {
            currentHealth -= damage;
            currentBlindness -= damage;
            if (currentBlindness <= 0)
            {
                currentBlindness = 0;
            }


            healthBar.SetHealth(currentHealth);
            blindnessBar.SetBlindness(currentBlindness);
        }
       
    }
}
