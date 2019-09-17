using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Stats))]
public class Combat : MonoBehaviour
{
    Stats selfStats;

    public float attackSpeed;
    private float attackCooldown = 0f;

    void Start()
    {
        selfStats = GetComponent<Stats>();
        attackSpeed = selfStats.attackSpeed.GetValue();
    }

    void Update()
    {
        attackCooldown -= Time.deltaTime;
    }
    public void Attack(Stats targetStats)
    {
        if (attackCooldown <= 0f)
        {
            targetStats.TakeDamage(selfStats.attackDamage.GetValue());
            attackCooldown = 1f / attackSpeed;
        }
    }
}
