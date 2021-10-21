using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private float fireSpeed;
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private float shootDelay = 0.1f;
    [SerializeField]
    private float coolDownTime = 0.4f;
    private float readyToFire;
    private float lastDirection;
    private AnimationChanger animationChanger;

    private void Start()
    {
        readyToFire = shootDelay + coolDownTime;
        animationChanger = GetComponent<AnimationChanger>();
    }

    private void Update()
    {
        readyToFire -= Time.deltaTime;
    }

    public void Shoot(float direction)
    {
        if (readyToFire <= 0)
        {
            animationChanger.AnimationStateChanger(3);
            StartCoroutine(ShootDelay(direction));
            readyToFire = shootDelay + coolDownTime;
        }
        
    }

    IEnumerator ShootDelay(float direction)
    {
        yield return new WaitForSeconds(shootDelay);
        Shooting(direction);
    }

    private void Shooting(float direction)
    {
        GameObject currentBullet = Instantiate(bullet, firePoint.position, Quaternion.identity);
        Rigidbody2D currentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();        
        if (direction >= 0)
        {

            currentBulletVelocity.velocity = new Vector2(fireSpeed, currentBulletVelocity.velocity.y);

        }
        else
        {
            currentBulletVelocity.velocity = new Vector2(-fireSpeed, currentBulletVelocity.velocity.y);
        }
        StartCoroutine(CoolDownTime());
    }

    IEnumerator CoolDownTime()
    {
        yield return new WaitForSeconds(coolDownTime);
        animationChanger.AnimationStateChanger(0);
    }
}

