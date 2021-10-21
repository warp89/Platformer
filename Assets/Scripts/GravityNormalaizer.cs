using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityNormalaizer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.attachedRigidbody.gravityScale != 1)
        {
            collision.collider.attachedRigidbody.gravityScale = 1;
        }
    }
}
