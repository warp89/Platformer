using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingEnemyScript : MonoBehaviour
{
    [SerializeField]
    private GameObject fallingEnemy;
    [SerializeField]
    private int gravityMultipler = 10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Damagable")
        {
            GameObject enemy = Instantiate(fallingEnemy, new Vector2(transform.position.x, transform.position.y + 4), Quaternion.identity);
            enemy.GetComponent<Rigidbody2D>().gravityScale = gravityMultipler;
            Destroy(gameObject);
        }
        
    }
}
