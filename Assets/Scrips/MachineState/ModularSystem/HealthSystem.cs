using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    float currentHealth;
    float maxHealth;
    public void SetHealth(float health)
    {
        currentHealth = health;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth <= 0)
        {
            Debug.Log("estirio la pata");
        }
    }
    public float GetHealth()
    {
        return currentHealth;
    }
}
