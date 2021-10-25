 using UnityEngine;
using System.Collections;

public class BasicFollow : MonoBehaviour 
{

	private Vector3 startingPosition;
	public GameObject followTarget;
	private Vector3 targetPos, velocity;
    private Vector2 targetPos2D, velocity2D, rbPosition;
    private Rigidbody2D rb2D;
	public float moveSpeed;
    public float offSetX;
    public float offSetY;
    public float offSetZ;
    public bool rigidbody2dMovement, smoothMovement;

    void Awake()
    {
        startingPosition = transform.position;
        if (rigidbody2dMovement)
        {
            rb2D = gameObject.GetComponent<Rigidbody2D>();
        }
    }
    void FixedUpdate () 
	{
        if (followTarget != null)
        {
            if (rigidbody2dMovement)
            {
                targetPos2D = new Vector2(followTarget.transform.position.x + offSetX, followTarget.transform.position.y + offSetY);
                velocity2D = (targetPos2D - rb2D.position) * moveSpeed;
                if (smoothMovement)
                {
                    rb2D.MovePosition(rb2D.position + velocity2D * Time.fixedDeltaTime);
                }
                else
                {
                    rb2D.position = targetPos2D;
                }
            }
            else
            {
                targetPos = new Vector3(followTarget.transform.position.x + offSetX, followTarget.transform.position.y + offSetY, transform.position.z + offSetZ);
                velocity = (targetPos - transform.position) * moveSpeed;
                if (smoothMovement)
                {
                    transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, 1.0f, Time.deltaTime);
                }
                else
                {
                    transform.position = targetPos;
                }
            }
        }
    }
}

