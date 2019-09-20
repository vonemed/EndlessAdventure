using UnityEngine;

public class Stats : MonoBehaviour
{
    public Attribute health;
    public Attribute attackDamage;
    public Attribute attackSpeed;

    public int currentHealth;
    int currentDamage;

    public event System.Action<int, int> HealthChange;
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

        if (currentHealth > 0)
        {
            Debug.Log(transform.name + " takes " + damage + " damage.");
        }

        if (HealthChange != null)
        {
            HealthChange(health.GetValue(), currentHealth);
        }

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
