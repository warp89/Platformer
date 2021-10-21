using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomBarrel : MonoBehaviour
{
    [SerializeField]
    private GameObject barrel;
    [SerializeField]
    private GameObject boomEffector;    

    private void Start()
    {
        Destroy(barrel);
        Instantiate(boomEffector, gameObject.transform);
        StartCoroutine(Boom());        
    }
    IEnumerator Boom()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
