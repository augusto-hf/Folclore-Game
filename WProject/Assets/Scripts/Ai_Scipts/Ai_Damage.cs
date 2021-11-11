using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AI_Damage : MonoBehaviour
{
 
    Player Healt;
    [SerializeField] Transform Enemy;
    [SerializeField] Rigidbody2D RbPlayer;


    public void Damage(int Dano,Player healt, Rigidbody2D rPlayer)
    {

            RbPlayer = rPlayer;
            Healt = healt;
            Vector2 Direcao = RbPlayer.transform.position - Enemy.position;
            Direcao.y = 0;
            RbPlayer.AddForce(Direcao.normalized * 30, ForceMode2D.Force);
            Healt.TakeDamage(Dano);
            Healt.IVframe = true;
            
  

    }


  
}
