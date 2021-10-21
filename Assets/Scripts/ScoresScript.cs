using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoresScript : MonoBehaviour
{
    [SerializeField]
    private int scores;
    
    void Start()
    {
        scores = 0;
    }

    public void AddScores(int addedScroes)
    {
        Debug.Log("addedScroes");
        scores += addedScroes;
    }
    public int GetScores()
    {
        return scores;
    }
    
}
