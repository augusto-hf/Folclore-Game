using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakeManager : MonoBehaviour
{
    
    [SerializeField] float distanceBetween = .2f , speed = 280, turnSpeed = 180, angle, snakeAngle, minumumDistance = 1.5f;
    [SerializeField] List<GameObject> bodyParts = new List<GameObject>();
    List<GameObject> snakeBody = new List<GameObject>();
    Vector3 circleOrigin, snakeHeadPosition;
    RaycastHit2D hitInfo;
    bool iFoundMyDetectors = false, playerOnRight, playerOnLeft, playerOnFront;
    GameObject RightSide, LeftSide, FrontSide;

    private float countUp = 0, distanceR, distanceL, distanceF;
    private GameObject player;
    public ParticleSystem flamethrower;
    // Start is called before the first frame update
    void Start()
    {
        if (bodyParts.Count > 0)
        {
            CreateBodyParts();
        }
        player = GameObject.FindGameObjectWithTag("Player");

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
        PlayerDetector();
        SnakeMovement();
        RotateTowardsTarget();
        AttackManager();
    }
    private void RotateTowardsTarget()
    {
        Vector2 direction = player.transform.position - snakeBody[0].transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        snakeBody[0].transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }
    void SnakeMovement()
    {
        snakeBody[0].GetComponent<Rigidbody2D>().velocity = snakeBody[0].transform.right * speed * Time.deltaTime;
        if (snakeBody[0])
        {

        }

        for (int i = 1; i < snakeBody.Count; i++)
        {
            MarkerManager markM = snakeBody[i - 1].GetComponent<MarkerManager>();
            snakeBody[i].transform.position = markM.markerList[0].position;
            snakeBody[i].transform.position = markM.markerList[0].position;
            markM.markerList.RemoveAt(0);
        }
    }
    void PlayerDetector()
    {
        if (!iFoundMyDetectors)
        {
            RightSide = snakeBody[0].transform.Find("RightSide").gameObject;
            LeftSide = snakeBody[0].transform.Find("LeftSide").gameObject;
            FrontSide = snakeBody[0].transform.Find("FrontSide").gameObject;
            iFoundMyDetectors = true;
        }

        //achar a distancia do jogador e os detectores
        distanceR = Vector2.Distance(player.transform.position, RightSide.transform.position);
        distanceL = Vector2.Distance(player.transform.position, LeftSide.transform.position);
        distanceF = Vector2.Distance(player.transform.position, FrontSide.transform.position);
        //Detectar jogador a direita
        if (distanceR < minumumDistance)
        {
            playerOnRight = true;
        }
        else if (distanceR > minumumDistance){
            playerOnRight = false;
        }
        //Detectar jogador a esquerda
        if (distanceL < minumumDistance)
        {
            playerOnLeft = true;
        }
        else if (distanceL > minumumDistance)
        {
            playerOnLeft = false;
        }
        //Detectar jogador a frente
        if (distanceF < minumumDistance)
        {
            playerOnFront = true;
        }
        else if (distanceF > minumumDistance)
        {
            playerOnFront = false;
        }
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
    void AttackManager()
    {
        if (playerOnFront)
        {
            flamethrower.Play();
        }
        if (!playerOnFront)
        {
            flamethrower.Stop();
        }
    }
}

/*
 * 
 * MOVIMENTOS TESTES DO BOITATA
 * 
if (!playerOnRight && !playerOnLeft && !playerOnFront)
{

}
else if (playerOnRight)
{
    Debug.Log("player on my right");
    snakeBody[0].transform.Rotate(new Vector3(0, 0, -turnSpeed * Time.deltaTime * 1));
}
else if (playerOnLeft)
{
    Debug.Log("player on my left");
    snakeBody[0].transform.Rotate(new Vector3(0, 0, -turnSpeed * Time.deltaTime * -1));
}
*/
