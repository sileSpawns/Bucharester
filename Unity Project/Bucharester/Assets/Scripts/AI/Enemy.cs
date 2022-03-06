using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;

    float health = 50f;
    float speed = 5f;

    public float lookRadius = 2f;

    public Transform player;
    public Transform[] scoutingPoints;
    State<Enemy> currentState = null;

    public int nr;

    void Awake()
    {
        ChangeState(new LookForPlayer()); 
    }

    private void FixedUpdate()
    {
        currentState.Execute(this);
    }

    public void ChangeState(State<Enemy> newState)
    {
        if (currentState != null)
            currentState.OnExit(this);

        currentState = newState;
        currentState.OnEnter(this);
           
    }

    public void StartScouting()
    {

        if (targetFound(scoutingPoints[0]))
            agent.SetDestination(scoutingPoints[1].position);

        if (targetFound(scoutingPoints[1]))
            agent.SetDestination(scoutingPoints[2].position);

        if (targetFound(scoutingPoints[2]))
            agent.SetDestination(scoutingPoints[3].position);

        if (targetFound(scoutingPoints[3]))
            agent.SetDestination(scoutingPoints[0].position);



    }

    /// <summary>
    /// Checks to see if the target is within the sight radius
    /// </summary>
    public bool targetFound(Transform target)
    {
        float distance = (target.position - transform.position).sqrMagnitude;
        if (distance <= lookRadius * lookRadius)
            return true;
        else
            return false;
    }

    /// <summary>
    /// used to draw the perception sight sphere
    /// </summary>
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
