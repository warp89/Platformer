using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField]
    private float damage;
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Damagable"))
        {
            Health health = collision.collider.GetComponentInParent<Health>();
            health.TakeDamage(damage);
        }
    }
}
