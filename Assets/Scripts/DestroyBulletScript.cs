using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBulletScript : MonoBehaviour
{
    [SerializeField]
    private float timeToLife = 1f;
    private void Start()
    {
        Destroy(gameObject, timeToLife);
    }
}
