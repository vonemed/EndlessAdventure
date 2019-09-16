using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
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

    public void Move(Vector3 _position)
    {
        agent.SetDestination(_position);
    }

    public void followPlayer(Transform _player)
    {
        currentTarget = _player.transform;
        agent.SetDestination(currentTarget.position);
        agent.updateRotation = true;
    }
}
