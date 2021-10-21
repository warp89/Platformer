using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPanelScript : MonoBehaviour
{    
    [SerializeField]
    private GameObject deathPanel;
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void DeathPanelOn()
    {
        deathPanel.SetActive(true);
    }
}
