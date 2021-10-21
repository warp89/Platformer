using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public float maxHealth;
    [HideInInspector]
    public float currentHealth;
    public bool isAlive;
    private AnimationChanger animationChanger;
    [SerializeField]
    private HealthBarScript healthBar;
    [SerializeField]
    private DeathPanelScript deathPanel;
    private void Awake()
    {
        currentHealth = maxHealth;
        isAlive = true;
        animationChanger = GetComponent<AnimationChanger>();
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        AliveChecker();
        if (gameObject.tag == "Player")
        {
            healthBar.SetHealthBar(currentHealth);
        }

    }
    public void AliveChecker()
    {
        if (currentHealth > 0)
        {
            isAlive = true;
        }
        else
        {
            isAlive = false;
            if (TryGetComponent(out AnimationChanger animator))
            {
                animationChanger.AnimationStateChanger(isAlive, isAlive, isAlive, !isAlive);
                StartCoroutine(WaitEndAnimation());
            }
            else
            {
                if (TryGetComponent(out EnemyMovingScript movingEnemy))
                {
                    //”правление анимацией в EnemyMovingScript
                }
                else
                {
                    Destroy(gameObject);
                }

            }
        }
    }
    IEnumerator WaitEndAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        deathPanel.DeathPanelOn();
    }
}
