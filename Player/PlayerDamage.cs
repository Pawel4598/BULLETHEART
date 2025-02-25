using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public float damageAmount = 25f;

    public void ApplyDamage(GameObject target)
    {
        EnemyHealth targetHealth = target.GetComponent<EnemyHealth>();
        if (targetHealth != null )
            targetHealth.TakeDamage(damageAmount);
    }
}
