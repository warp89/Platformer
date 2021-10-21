using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndLevelSript : MonoBehaviour
{
    [SerializeField]
    private GameObject endLevelScreen;
    [SerializeField]
    private Text winText;
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.tag == "Player")
        {
            collision.GetComponentInParent<PlayerInput>().TakingControl(false);
            winText.text = $"Level complete! \n Scores: {collision.GetComponentInParent<ScoresScript>().GetScores().ToString().Replace("0","o")}";
            endLevelScreen.SetActive(true);
        } 
    }
}
