using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damageAmount = 10f;

    public void ApplyDamage(GameObject target)
    {
        PlayerHealth targetHealth = target.GetComponent<PlayerHealth>();
        if (targetHealth != null)
            targetHealth.TakeDamage(damageAmount);
    }
}
