using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirar : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cam;

    public Rigidbody2D rb;

    Vector2 mousePos;

    void Update()
    {
        //pega a posição do mouse
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    private void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        //Debug.Log("Mouse Position:"+ mousePos);

    }
}
