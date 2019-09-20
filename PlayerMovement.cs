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
            FaceTarget();
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

    void FaceTarget()
    {
        Vector3 direction = (currentTarget.position - transform.position).normalized; // The direction towards target
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z)); // Rotation towards target

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f); // Smooth rotation
    }
}
