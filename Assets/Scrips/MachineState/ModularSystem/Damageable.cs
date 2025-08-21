using UnityEngine;

public class Damageable : MonoBehaviour
{
    HealthSystem healthSystem;
    public void Initialize(HealthSystem healthSystem)
    {
        this.healthSystem = healthSystem;
    }
    public void RecieveDamage(float damage)
    {
       healthSystem.SetHealth(healthSystem.GetHealth() - damage);
    }
}
