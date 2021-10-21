using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    [SerializeField]
    private Image healthImage;
    [SerializeField]
    private Health player;
    private float maxHealth;
    private float currentHealth;

    void Start()
    {
        maxHealth = player.maxHealth;         
    }
    public void SetHealthBar(float currentHealth)
    {        
        healthImage.fillAmount = currentHealth / maxHealth;
    }
    
}
