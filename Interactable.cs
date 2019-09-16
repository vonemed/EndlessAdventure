using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float reachRadius = 2f; // Interaction radius
    Transform player; // Player position

    Vector3 dist; // Distance from item to player
    virtual protected void Interaction()
    {

    }

    void Update ()
    {
        if (player != null)
        {
            dist = transform.position - player.position;

            if (dist.magnitude <= reachRadius)
            {
                Interaction();
                Debug.Log("Interaction!!");
            }
        }
    }

    public void PlayerPos (Transform _player)
    {
        player = _player;
    }

    // Drawing a radius in editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, reachRadius);
    }
}
