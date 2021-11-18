using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveScript : MonoBehaviour
{   //general variables
    public float moveSpeed = 5f;
    private float startMoveSpeed, LastMove = 1;
    public Rigidbody2D rb;
    public Animator anim;
    Vector2 movement;

    //dash variables
    public float dashSpeed, dashEnd, dashTime, startDashTime;
    private int direction;
    private bool isDashing;
    Vector2 movementRef;

    void Start()
    {
        startMoveSpeed = moveSpeed;
    }
    void Update()
    {
        move();
        dash();
        //Debug.Log("H: " + movement.x);
        //Debug.Log("Y: " + movement.y);

        if (isDashing == false)
        {
            verifyLastMove();
            anim.SetFloat("LastMove", LastMove);
            anim.SetFloat("Horizontal", movement.x);
            anim.SetFloat("Vertical", movement.y);
            anim.SetFloat("Speed", movement.sqrMagnitude);
        }
    }

    private void verifyLastMove()
    {
        if (movement.x > 0.1)
        {
            LastMove = 1;
        }
        else if (movement.x < -0.1)
        {
            LastMove = -1;
        }
    }

    void FixedUpdate()
    {       
        if (isDashing == false)//movimento sem dash
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
        else//movimento com dash
        {
            rb.MovePosition(rb.position + movementRef * moveSpeed * Time.fixedDeltaTime);
        }
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
        else if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {//se o movimento do teclado acontecer mas n for diagonal
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }
        else if (Input.GetAxisRaw("HorizontalC") != 0 || Input.GetAxisRaw("VerticalC") != 0 && Input.GetAxisRaw("Horizontal") == 0 || Input.GetAxisRaw("Vertical") == 0)
        {//se o movimento do teclado for 0 e o movimento do controle existir de alguma forma
            movement.x = Input.GetAxisRaw("HorizontalC");
            movement.y = Input.GetAxisRaw("VerticalC");
        }
    }
    void dash()
    {   //recebe o comando de dar dash caso as variaveis do dash estejam zeradas
        if (Input.GetButtonDown("Dash") && dashTime <= 0 && moveSpeed == startMoveSpeed)
        {//da o dash
            movementRef = movement;
            isDashing = true;
            moveSpeed = moveSpeed * dashSpeed;
            dashTime = startDashTime;
        }
        else
        {//reseta tudo relacionado ao dash         
            if (dashTime > 0 || moveSpeed > startMoveSpeed)
            {
                dashTime -= Time.deltaTime;
                //O MODIFICADOR AO LADO DO DELTATIME DEFINE A DISTANCIA DO DASH!!! NÃO ESQUEÇA!!!
                moveSpeed -= Time.deltaTime + dashEnd;
                //contra medida para bugs:
                if (moveSpeed < startMoveSpeed)
                {
                    moveSpeed = startMoveSpeed;
                }
            }
        }
        if (dashTime <= 0 && moveSpeed == startMoveSpeed) {//reseta indicador de dash
        isDashing = false;
        }
    }
}
