using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{
    NavMeshAgent agent;
    Transform currentTarget;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (currentTarget != null)
        {
            agent.SetDestination(currentTarget.position);
        }
    }

    public void Move (Vector3 _position)
    {
        agent.SetDestination(_position);
    }

    public void Follow (Interactable _target)
    {
        agent.stoppingDistance = _target.reachRadius;
        agent.updateRotation = true;

        currentTarget = _target.transform;
    }

    public void StopFollow ()
    {
        agent.stoppingDistance = 0f; // Reset the stopping distance
        agent.updateRotation = true;

        currentTarget = null; // Reset current target
    }
}
