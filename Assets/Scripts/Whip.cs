using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whip : MonoBehaviour
{
    [SerializeField]
    private float coolDownTime = 0.1f;
    private AnimationChanger animationChanger;

    private void Start()
    {
        animationChanger = GetComponent<AnimationChanger>();
    }

    public void WhipAttackOrdinary()
    {
        animationChanger.AnimationStateChanger(1);
        StartCoroutine(CoolDownTime());
    }

    public void WhipAttackPower()
    {
        animationChanger.AnimationStateChanger(2);
        StartCoroutine(CoolDownTime());
    }

    IEnumerator CoolDownTime()
    {
        yield return new WaitForSeconds(coolDownTime);
        animationChanger.AnimationStateChanger(0);
    }
}
