using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{
    NavMeshAgent agent;
    Interactable interactable;

    void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void Move (Vector3 _position)
    {
        agent.isStopped = false;
        agent.SetDestination(_position);
        agent.updateRotation = true;
    }

    public void Follow (Vector3 _position)
    {
        agent.stoppingDistance = interactable.reachRadius;
        agent.isStopped = false;
        agent.SetDestination(_position);
        agent.updateRotation = true;
    }

    public void StopFollow ()
    {
        agent.isStopped = true;
        agent.updateRotation = false;
    }

    public void StoppingDist(Interactable _interactable)
    {
        interactable = _interactable;
    }
}
