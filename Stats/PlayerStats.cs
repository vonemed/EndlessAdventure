using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : Stats
{
    public override void Die()
    {
        base.Die();
        Destroy(gameObject);
        Debug.Log("Player is dead");
    }
}
