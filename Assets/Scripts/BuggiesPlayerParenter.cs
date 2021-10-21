using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuggiesPlayerParenter : MonoBehaviour
{
    [SerializeField]
    private Transform parentTransform;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Damagable")
        {
            collision.collider.attachedRigidbody.gameObject.transform.SetParent(parentTransform);
        }
        if (collision.collider.attachedRigidbody.tag == "Player")
        {
            transform.GetComponentInParent<BuggiesDriveScript>().DriveBuggiesOn();
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Damagable")
        {
            collision.collider.attachedRigidbody.gameObject.transform.SetParent(null);
        }

    }
}
