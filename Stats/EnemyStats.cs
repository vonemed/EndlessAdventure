using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : Stats
{
    GoldUI gold;

    void Awake()
    {
        gold = GoldUI.instance;
    }

    public override void Die()
    {
        gold.SetScore(50);
        base.Die();
        Destroy(gameObject);
    }
}
