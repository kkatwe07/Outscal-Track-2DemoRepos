using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform[] Waypoints;

    [SerializeField] float speed = 1.5f;

    [SerializeField] Transform target;

    [SerializeField] float chaseRange;

    int waypointIndex = 0;

   
    void Start()
    {      
        transform.position = Waypoints[waypointIndex].transform.position;
    }

    
    void Update()
    {
        float distanceToTarget = Vector2.Distance(transform.position, target.position);

        if (distanceToTarget < chaseRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }


        transform.position = Vector2.MoveTowards(transform.position, Waypoints[waypointIndex].transform.position, speed * Time.deltaTime);

        if (transform.position == Waypoints[waypointIndex].transform.position)
        {
            waypointIndex++;
        }

        if (waypointIndex == Waypoints.Length)
        {
            waypointIndex = 0;
        }

        
    }

    
}
