using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakeManager : MonoBehaviour
{
    
    [SerializeField] float distanceBetween = .2f , speed = 280, turnSpeed = 180, angle, snakeAngle;
    [SerializeField] List<GameObject> bodyParts = new List<GameObject>();
    List<GameObject> snakeBody = new List<GameObject>();
    Vector3 lookDir;

    private float countUp = 0;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        if (bodyParts.Count > 0)
        {
            CreateBodyParts();
        }
    }
    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (bodyParts.Count > 0)
        {
            CreateBodyParts();
        }
        PlayerFinder();
        SnakeMovement();
    }
    void SnakeMovement()
    {

        snakeBody[0].GetComponent<Rigidbody2D>().velocity = (player.transform.position - snakeBody[0].transform.position).normalized * speed * Time.deltaTime;
        if (snakeBody[0].transform.position.y > player.transform.position.y)
        {
            snakeBody[0].transform.Rotate(new Vector3(0, 0, -turnSpeed * Time.deltaTime * 1));
        }
        for (int i = 1; i < snakeBody.Count; i++)
        {
            MarkerManager markM = snakeBody[i - 1].GetComponent<MarkerManager>();
            snakeBody[i].transform.position = markM.markerList[0].position;
            snakeBody[i].transform.position = markM.markerList[0].position;
            markM.markerList.RemoveAt(0);
        }
    }
    void PlayerFinder()
    {

    }
    void CreateBodyParts()
    {
        //cria a cabeça
        if (snakeBody.Count == 0)
        {
            GameObject temp1 = Instantiate(bodyParts[0], transform.position, transform.rotation, transform);
            if (!temp1.GetComponent<MarkerManager>())// verigica se tem MarkManager, se não tiver ele coloca
                temp1.AddComponent<MarkerManager>();
            if (!temp1.GetComponent<Rigidbody2D>())// verigica se tem Rigidbody2D, se não tiver ele coloca
            {
                temp1.AddComponent<Rigidbody2D>();
                temp1.GetComponent<Rigidbody2D>().gravityScale = 0;
            }
            snakeBody.Add(temp1);
            bodyParts.RemoveAt(0);
        }
        MarkerManager markM = snakeBody[snakeBody.Count - 1].GetComponent<MarkerManager>();
        if (countUp == 0)
        {
            markM.ClearMarkerList();
        }
        countUp += Time.deltaTime;
        if (countUp >= distanceBetween)
        {
            //parte onde adiciona os componentes das partes da cobra caso ela não venha com eles 
            GameObject temp = Instantiate(bodyParts[0], markM.markerList[0].position, markM.markerList[0].rotation, transform);
            if (!temp.GetComponent<MarkerManager>())// verigica se tem MarkManager, se não tiver ele coloca
                temp.AddComponent<MarkerManager>();
            if (!temp.GetComponent<Rigidbody2D>())// verigica se tem Rigidbody2D, se não tiver ele coloca
            {
                temp.AddComponent<Rigidbody2D>();
                temp.GetComponent<Rigidbody2D>().gravityScale = 0;
            }
            snakeBody.Add(temp);
            bodyParts.RemoveAt(0);
            temp.GetComponent<MarkerManager>().ClearMarkerList();
            countUp = 0;
        }
    }
}
