using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DuckMovement : MonoBehaviour
{
    public NavMeshAgent agent; //drag enemy object's NavMeshAgent component here
    public LayerMask whatIsGround;

    //Patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange; //see below





    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>(); //agent is the enemy's nav mesh agent component
        walkPointSet = false;

    }
    private void Update()
    {
        Patroling();
    }
    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint(); //if the walkpoint is not set it will search for walk point

        if (walkPointSet)
            agent.SetDestination(walkPoint); //if the walkpoint IS set it will patrol with search walk point method (SetDestination can be used due to navmesh agent and unityengine.ai)

        Vector3 distanceToWalkPoint = transform.position - walkPoint; //clause to make sure that patroling finishes so new one can start, walkpoint is random values added to the enemy transform position (x+random_value, y=is constant since we dont want the enemy to jump around, z+random_value) since patroling is random every time

        //when Walkpoint is reached, it will automatically search for new one meaning it continues to patrol
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //calculate random point in range
        float randomX = Random.Range(-walkPointRange, walkPointRange); //walkpointrange is public float which can be changed in unity = the amount of the value can change in between patrols e.g. if start location is 0,0,0 and this value is set to 5: on first patrol the max range it can go is 5,0,5
        float randomZ = Random.Range(-walkPointRange, walkPointRange);


        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }
}