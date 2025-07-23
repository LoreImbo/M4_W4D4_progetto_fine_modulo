using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDamage : MonoBehaviour
{
    public int damage = 3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LifeController life = other.GetComponent<LifeController>();
            if (life != null)
            {
                life.TakeDamage(damage);
            }
        }
    }
}
