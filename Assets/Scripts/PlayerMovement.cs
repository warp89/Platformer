using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float runSpeed;
    [SerializeField]
    private Transform groundColliderTransform;
    [SerializeField]
    private float jumpOffset;
    [SerializeField]
    private LayerMask groundMask;
    private float lastDirection;
    private bool isGrounded;
    private Rigidbody2D rigidbody;
    private AnimationChanger animationChanger;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animationChanger = GetComponent<AnimationChanger>();
        lastDirection = 1;
    }

    private void FixedUpdate()
    {
        Vector2 overlapCirclePosition = groundColliderTransform.position;
        isGrounded = Physics2D.OverlapCircle(overlapCirclePosition, jumpOffset, groundMask);

    }

    public void Move(float direction, bool isJump)
    {

        if (isJump && isGrounded)
        {
            Jump();
        }
        Movement(direction);
        if (direction !=0)
        {
            lastDirection = direction;
        }
        gameObject.transform.localScale = FlipX(direction != 0 ? direction : lastDirection);

        animationChanger.AnimationStateChanger(direction != 0 && isGrounded, isJump && isGrounded);

    }

    private void Movement(float direction)
    {
        rigidbody.velocity = new Vector2(direction * runSpeed, rigidbody.velocity.y);
    }

    private void Jump()
    {
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
    }

    private Vector3 FlipX(float direction)
    {
        return new Vector3(direction, gameObject.transform.localScale.y, gameObject.transform.localScale.z);

    }
}
