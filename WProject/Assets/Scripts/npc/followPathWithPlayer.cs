using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPathWithPlayer : MonoBehaviour
{
    public float npcSpeed;
    public Transform[] moveSpots;
    public bool playerIsNear;
    private int currentObjective = 0, randomSpot;

    // Start is called before the first frame update
    void Start()
    {
        //randomSpot = Random.Range(0, moveSpots.Length);
    }
    // Update is called once per frame
    void Update()
    {
        if (playerIsNear)
        {
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[currentObjective].position, npcSpeed * Time.deltaTime);
        }
        if(Vector2.Distance(transform.position, moveSpots[currentObjective].position) < 0.2f && currentObjective < (moveSpots.Length - 1))
        {
            currentObjective++;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerIsNear = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        playerIsNear = false;
    }
}
