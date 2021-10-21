using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneTriggerScript : MonoBehaviour
{
    [SerializeField]
    private CutSceneScript cutScene;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.tag == "Player")
        {
            Debug.Log(collision.attachedRigidbody.tag);
            cutScene.StartCutScene(gameObject,collision.attachedRigidbody.gameObject);
        }
    }
}
