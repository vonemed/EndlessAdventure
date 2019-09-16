using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteract : Interactable
{
    public bool chasing = false;
    public override void Interaction()
    {
        base.Interaction();
        Attack();
    }

    public void Attack()
    {
        // Player attacking enemy
        chasing = true;
        Debug.Log("Enemy is being attacked!");
    }
}
