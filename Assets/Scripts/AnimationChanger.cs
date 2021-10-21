using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationChanger : MonoBehaviour
{
    Animator animator;
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    public void AnimationStateChanger(bool isRunning, bool isJumping)
    {
        animator.SetBool(GlobalButtons.IS_RUNNING, isRunning);
        animator.SetBool(GlobalButtons.IS_JUMPING, isJumping);
    }
    public void AnimationStateChanger(int isAttack)
    {
        switch (isAttack)
        {
            case 1: animator.SetBool(GlobalButtons.IS_ATTACK1, true); break;

            case 2: animator.SetBool(GlobalButtons.IS_ATTACK2, true); break;

            case 3: animator.SetBool(GlobalButtons.IS_SHOOTING, true); break;

            default:
                animator.SetBool(GlobalButtons.IS_SHOOTING, false);
                animator.SetBool(GlobalButtons.IS_ATTACK1,false);
                animator.SetBool(GlobalButtons.IS_ATTACK2, false);
                break;
        }
        
    }
    public void AnimationStateChanger(bool isRunning, bool isJumping, bool isShooting, bool isDead)
    {
        animator.SetBool(GlobalButtons.IS_RUNNING, isRunning);
        animator.SetBool(GlobalButtons.IS_JUMPING, isJumping);
        animator.SetBool(GlobalButtons.IS_SHOOTING, isShooting);
        animator.SetBool(GlobalButtons.IS_DEAD, isDead);
    }
}