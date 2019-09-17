using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : Stats
{
    void Start()
    {
        health = 100f;
        attackDamage = 5f;
        attackSpeed = 2f;
    }

}
