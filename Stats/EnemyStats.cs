using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : Stats
{
    public override void Die()
    {
        base.Die();

        Destroy(gameObject);
    }
}
