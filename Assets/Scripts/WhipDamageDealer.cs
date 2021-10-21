using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipDamageDealer : MonoBehaviour
{
    [SerializeField]
    private float damage;   
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.CompareTag("Damagable"))
        {
            Health health = collision.GetComponentInParent<Health>();
            health.TakeDamage(damage);
        }
    }

}
