using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuggiesDriveScript : MonoBehaviour
{
    [SerializeField]
    private bool driveBuggies = false;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private float driveSpeed;
    public Transform target;
    private bool lastMoving;

    void FixedUpdate()
    {
        if (transform.position == target.position)
        {
            driveBuggies = false;
        }
        AnimationSwitcher(driveBuggies);
        if (driveBuggies)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, Time.fixedDeltaTime * driveSpeed);
        }        
    }

    private void AnimationSwitcher(bool moving)
    {
        if (moving != lastMoving)
        {
            if (moving)
            {
                animator.SetBool("Move", true);
            }
            else
            {
                animator.SetBool("Move", false);
            }
        }
        lastMoving = moving;
    }
    public void DriveBuggiesOn()
    {
        driveBuggies = true;
    }
}

