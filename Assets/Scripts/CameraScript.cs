using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float horizontalMinimum = 0;
    [SerializeField]
    private float horizontalMaximum = 16.5f;
    [SerializeField]
    private float verticalMinimum = 0;
    [SerializeField]
    private float vertivalMaximum = 2;   
    void Update()
    {
        gameObject.transform.position = CameraPosition(player.transform.position);
    }
    private Vector3 CameraPosition(Vector3 playerPosition)
    {
        return new Vector3
        {
            x = Mathf.Clamp(playerPosition.x, horizontalMinimum, horizontalMaximum),
            y = Mathf.Clamp(playerPosition.y, verticalMinimum, vertivalMaximum),
            z = playerPosition.z - 10
        };
    }
}
