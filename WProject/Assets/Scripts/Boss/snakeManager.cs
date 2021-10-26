using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakeManager : MonoBehaviour
{
    [SerializeField] float speed = 280;
    [SerializeField] float turnSpeed = 180;
    [SerializeField] List<GameObject> bodyParts = new List<GameObject>();
    List<GameObject> snakeBody = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        GameObject temp = Instantiate(bodyParts[0], transform.position, transform.rotation, transform);
        if (!temp.GetComponent<MarkerManager>())// verigica se tem MarkManager, se não tiver ele coloca
            temp.AddComponent<MarkerManager>();
        if (!temp.GetComponent<Rigidbody2D>())// verigica se tem Rigidbody2D, se não tiver ele coloca
        {
            temp.AddComponent<Rigidbody2D>();
            temp.AddComponent<Rigidbody2D>().gravityScale = 0;
        }
        snakeBody.Add(temp);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SnakeMovement();
    }
    void SnakeMovement()
    {
        snakeBody[0].GetComponent<Rigidbody2D>().velocity = snakeBody[0].transform.right * speed * Time.deltaTime;
    }
}
