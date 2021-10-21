using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour
{
    [SerializeField]
    private Transform[] layers;
    [SerializeField]
    private float[] factor;
    private float layerCount;
    [SerializeField]
    private bool fixedX;
    void Start()
    {
        layerCount = layers.Length;
    }
    void Update()
    {
        for (int i = 0; i < layerCount; i++)
        {
            if (fixedX)
            {
                layers[i].position = new Vector2(transform.position.x * factor[i], layers[i].transform.position.y);
            }
            else
            {
                layers[i].position = transform.position * factor[i];
            }
        }
    }
}
