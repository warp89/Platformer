using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectorScript : MonoBehaviour
{
    public bool detected;
    private void OnTriggerEnter2D(Collider2D collision)
    {       
        if (collision.CompareTag("Damagable"))
        {
            detected = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Damagable"))
        {
            detected = false;
        }
    }

}
