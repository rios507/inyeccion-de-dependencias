using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] targetTypeEnum targetTypeEnum;
    [SerializeField] HealthSystem healthSystem;
    private void Awake()
    {
        if (healthSystem == null)
        {
            TryGetComponent(out healthSystem);
        }
    }
    private void OnEnable()
    {
        healthSystem.Death += () => Destroy(this);
    }
    private void OnDisable()
    {
        healthSystem.Death -= () => Destroy(this);
    }
    public void Initialize(HealthSystem healthSystem)
    {
        this.healthSystem = healthSystem;
    }
    public void RecieveDamage(float damage)
    {
       healthSystem.SetHealth(healthSystem.GetHealth() - damage);
    }
    public targetTypeEnum GetTargetType()
    {
        return targetTypeEnum;
    }
}
