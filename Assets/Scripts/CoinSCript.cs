using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSCript : MonoBehaviour
{
    [SerializeField]
    private int coinScore;
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.attachedRigidbody.tag == "Player")
        {
            collision.GetComponentInParent<ScoresScript>().AddScores(coinScore);
            Destroy(gameObject);
        }
        
    }
}
