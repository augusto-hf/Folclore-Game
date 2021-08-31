using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_MelleAtack : MonoBehaviour
{
    public GameObject Attack;
    bool starCoumt;
    public float time;
  public void MelleAttack()
    {
        starCoumt = true;
        Attack.SetActive(true);
        if (starCoumt == true)
        {
            time -= Time.deltaTime;
        }

        if (time <= 0)
        {
            Attack.SetActive(false);
            starCoumt = false;
        }
    }
}
