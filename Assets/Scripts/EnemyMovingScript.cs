using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovingScript : MonoBehaviour
{
    [SerializeField]
    private float speed, timeToRevert;
    private Rigidbody2D rigidbody;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private PlayerDetectorScript detector;
    private Health health;
    private const float IDLE = 0;
    private const float WALK = 1;
    private const float ATTACK = 2;
    private const float REVERT = 3;
    private const float DEAD = 4;
    private float currentState, currentTimeToRevert;

    void Start()
    {
        currentTimeToRevert = 0;
        currentState = WALK;
        rigidbody = GetComponent<Rigidbody2D>();
        health = GetComponent<Health>();
    }

    void Update()
    {
        if (currentTimeToRevert > timeToRevert)
        {
            currentTimeToRevert = 0;
            currentState = REVERT;
        }
        if (health.currentHealth <= 0)
        {
            currentState = DEAD;
        }
        if (detector.detected)
        {
            currentState = ATTACK;
        }
        switch (currentState)
        {
            case IDLE:
                currentTimeToRevert += Time.deltaTime;
                ResetAnimation();
                animator.SetBool("Idle", true);
                break;
            case WALK:
                rigidbody.velocity = Vector2.right * speed;
                ResetAnimation();
                animator.SetBool("Walk", true);
                break;
            case ATTACK:
                ResetAnimation();
                animator.SetBool("Attack", true);
                break;
            case REVERT:
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);
                speed *= -1;
                currentState = WALK;
                break;
            case DEAD:
                ResetAnimation();
                animator.SetBool("Dead", true);
                StartCoroutine(WaitEndAnimation());
                break;
            default:
                break;
        }

    }

    private void ResetAnimation()
    {
        animator.SetBool("Idle", false);
        animator.SetBool("Walk", false);
        animator.SetBool("Attack", false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyLimiter"))
        {
            currentState = IDLE;
            animator.SetBool("Idle", true);
        }
    }
    IEnumerator WaitEndAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
