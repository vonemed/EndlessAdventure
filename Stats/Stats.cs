using UnityEngine;

public class Stats : MonoBehaviour
{
    public Attribute health;
    public Attribute attackDamage;
    public Attribute attackSpeed;

    int currentHealth;
    int currentDamage;

    void Start()
    {
        currentHealth = health.GetValue();
        currentDamage = attackDamage.GetValue();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Debug.Log("Dead");
    }
}
