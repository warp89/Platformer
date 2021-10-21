using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Shooter shooter;
    private Whip whip;
    [SerializeField]
    private Health health;
    private float lastDirection;
    private bool tookControl = true;
    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        shooter = GetComponent<Shooter>();
        whip = GetComponent<Whip>();
    }
    private void Update()
    {
        if (health.isAlive && tookControl)
        {
            float direction = Input.GetAxisRaw(GlobalButtons.HORIZONTAL_AXIS);
            bool isJump = Input.GetButtonDown(GlobalButtons.JUMP);
            if (direction!=0)
            {
                lastDirection = direction;
            }
            if (Input.GetButtonDown(GlobalButtons.FIRE3))
            {
                shooter.Shoot(lastDirection);
            }
            if (Input.GetButtonDown(GlobalButtons.FIRE1))
            {
                whip.WhipAttackOrdinary();
            }
            if (Input.GetButtonDown(GlobalButtons.FIRE2))
            {
                whip.WhipAttackPower();
            }
            playerMovement.Move(direction, isJump);

        }
    }
    public void TakingControl(bool controlledByPlayer)
    {
        tookControl = controlledByPlayer;
    }
}
