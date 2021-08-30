 using UnityEngine;
using System.Collections;

public class BasicFollow : MonoBehaviour 
{

	private Vector3 startingPosition;
	public Transform followTarget;
	private Vector3 targetPos;
	public float moveSpeed;
    public float offSetX;
    public float offSetY;
    public float offSetZ;

    void Start()
	{
		startingPosition = transform.position;
	}

	void Update () 
	{
		if(followTarget != null)
		{
			targetPos = new Vector3(followTarget.position.x + offSetX, followTarget.position.y + offSetY, transform.position.z + offSetZ);
			Vector3 velocity = (targetPos - transform.position) * moveSpeed;
			transform.position = Vector3.SmoothDamp (transform.position, targetPos, ref velocity, 1.0f, Time.deltaTime);
		}
	}
}

