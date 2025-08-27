using System.Collections.Generic;

using UnityEngine;

public enum targetTypeEnum
{
    Player,
    Enemy,
    objects
}

public class Damager : MonoBehaviour
{


    [SerializeField] List<targetTypeEnum> targetType = new();
    [SerializeField] float damage;
    Collider hitbox;

    private void Start()
    {
        hitbox = GetComponent<Collider>();
    }
    public void Enable()
    {
        hitbox.enabled = true;
    }
    public void Disable()
    {
        hitbox.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Damageable[] damageables = other.GetComponents<Damageable>();

        if (other.TryGetComponent(out Damageable damageable))
        {
            if (targetType.Contains(damageable.GetTargetType()))
            {
                damageable.RecieveDamage(damage);
            }

        }
    }
}
