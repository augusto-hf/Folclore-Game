using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPathWithPlayer : MonoBehaviour
{
    public float npcSpeed = 1;
    public Transform[] moveSpots;
    public bool playerIsNear, pathEnded;
    private int currentObjective = 0, randomSpot, currentDirectionH, currentDirectionV;
    public int[] directionH, directionV;

    void Start()
    {
        //randomSpot = Random.Range(0, moveSpots.Length);
        currentDirectionH = directionH[currentObjective];
        currentDirectionV = directionV[currentObjective];

    }

    void Update()
    {
        if (playerIsNear)
        {
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[currentObjective].position, npcSpeed * Time.deltaTime);
        }
        if(Vector2.Distance(transform.position, moveSpots[currentObjective].position) < 0.2f && currentObjective < (moveSpots.Length - 1))
        {
            currentObjective++;
            currentDirectionH = directionH[currentObjective];
            currentDirectionV = directionV[currentObjective];
        }
        if (currentObjective == (moveSpots.Length - 1))
        {
            pathEnded = true;
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
