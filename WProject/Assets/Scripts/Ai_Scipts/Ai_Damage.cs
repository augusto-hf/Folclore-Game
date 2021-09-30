using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AI_Damage : MonoBehaviour
{
 
    Player Healt;
    [SerializeField] Transform Player;
    [SerializeField] Transform Enemy;
    [SerializeField] Rigidbody2D RbPlayer;
    public void Damage(int Dano,Player healt)
    {
      
        
            Healt = healt;
            Vector2 Direcao = Player.position - Enemy.position;
            Direcao.y = 0;
            RbPlayer.AddForce(Direcao.normalized * 20, ForceMode2D.Force);
            Healt.TakeDamage(Dano);
            Healt.IVframe = true;
            //Healt = null;
            StartCoroutine(IncibleFrame());
        

    }

    
    IEnumerator IncibleFrame()
    {
        yield return new WaitForSeconds(2f);
        Healt.IVframe = false;
        Debug.Log("i");

    }

}
