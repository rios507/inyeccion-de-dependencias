using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public delegate void OnHealthChange();
    public OnHealthChange MaxHealthArchived;
    public OnHealthChange Death;

    float currentHealth;
    float maxHealth;
    public void Initialized()
    {

    }
    public void SetHealth(float health)
    {
        currentHealth = health;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
            MaxHealthArchived?.Invoke();
        }
        if (currentHealth <= 0)
        {
            Debug.Log("estirio la pata");
            Death?.Invoke();
        }
    }
    public float GetHealth()
    {
        return currentHealth;
    }
}
