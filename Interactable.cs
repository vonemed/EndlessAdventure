using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float reachRadius = 2f; // Interaction radius
    Transform player; // Player position
    public bool focused = false; // Indicator whether player is focused on object or not

    Vector3 dist; // Distance from item to player
    public virtual void Interaction()
    {

    }

    void Update ()
    {
        if (focused)
        {
            dist = transform.position - player.position;

            if (dist.magnitude <= reachRadius)
            {
                Interaction();
            }
        }
    }

    public void Focuse (Transform _player)
    {
        player = _player;
        focused = true;
    }

    // Drawing a radius in editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, reachRadius);
    }
}
