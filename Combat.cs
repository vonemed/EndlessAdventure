using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Stats))]
public class Combat : MonoBehaviour
{
    Stats selfStats;

    public int attackSpeed;
    private float attackCooldown = 0f;
    const float combatCooldown = 0.5f; // If player is not in combat for 5 seconds
    float lastAttackTime;

    float attackDelay = 0.3f;

    public event System.Action OnAttack; // Delegate
    public bool inCombat { get; private set; }

    void Start()
    {
        selfStats = GetComponent<Stats>();
        attackSpeed = selfStats.attackSpeed.GetValue();
    }

    void Update()
    {
        attackCooldown -= Time.deltaTime;

        if (Time.time - lastAttackTime > combatCooldown)
        {
            inCombat = false;
        }
    }
    
    public void Attack(Stats targetStats)
    {
        if (attackCooldown <= 0f)
        {
            StartCoroutine(damageDelay(targetStats, attackDelay));

            if (OnAttack != null)
                OnAttack();

            attackCooldown = 1f / attackSpeed; // Reset cooldown
            inCombat = true;
            lastAttackTime = Time.time;
        }
    }

    IEnumerator damageDelay(Stats targetStats, float delay)
    {
        yield return new WaitForSeconds(delay);

        targetStats.TakeDamage(selfStats.attackDamage.GetValue());

        if (targetStats.currentHealth <= 0)
        {
            inCombat = false;
        }
    }
}
