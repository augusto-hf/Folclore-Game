using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator anim;
    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        move();
        Debug.Log("H: " + movement.x);
        Debug.Log("Y: " + movement.y);

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);
    }
    void FixedUpdate()
    {
        //movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        
    }
    void move()
    {
        //input
        if (Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0 && Input.GetAxisRaw("Vertical") > 0)
        {//se os dois inputs do teclado forem precionados ao mesmo tempo indo ao norte
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical") - 0.45f;
        }
        else if (Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0 && Input.GetAxisRaw("Vertical") < 0)
        {//se os dois inputs do teclado forem precionados ao mesmo tempo indo ao sul
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical") + 0.45f;
        }
        else if (Input.GetAxisRaw("Horizontal")!=0 || Input.GetAxisRaw("Vertical") !=0)
        {//se o movimento do teclado acontecer mas n for diagonal
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }
        else if (Input.GetAxisRaw("HorizontalC") != 0 || Input.GetAxisRaw("VerticalC") !=0 && Input.GetAxisRaw("Horizontal") == 0 || Input.GetAxisRaw("Vertical") == 0)
        {//se o movimento do teclado for 0 e o movimento do controle existir de alguma forma
            movement.x = Input.GetAxisRaw("HorizontalC");
            movement.y = Input.GetAxisRaw("VerticalC");
        }

    }
}
