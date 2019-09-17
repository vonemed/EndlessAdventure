using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : Stats
{
    void Start()
    {
        health = 100f;
        attackDamage = 10f;
        attackSpeed = 2f;
    }
}
