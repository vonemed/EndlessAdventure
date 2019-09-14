using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{
    NavMeshAgent agent;

    void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void Move(Vector3 _position)
    {
        agent.SetDestination(_position);
        agent.updateRotation = true;
    }
}
