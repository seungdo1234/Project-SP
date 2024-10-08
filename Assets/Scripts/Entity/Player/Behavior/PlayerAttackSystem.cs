using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackSystem : MonoBehaviour
{
    [SerializeField] private float takeDamageOffsetTime = 0.5f;

    private Player player;
    private HealthSystem target;

    private Coroutine attackTargetCoroutine;

    private float damage;
    bool isAttack = false;


    public void PlayerAttackInit(Player player)
    {
        this.player = player;
        player.Controller.OnAttackEvent += PlayerAttack;
    }

    private void PlayerAttack(HealthSystem target)
    {
        this.target = target;

        if (attackTargetCoroutine != null)
        {
            StopCoroutine(attackTargetCoroutine);
        }
        attackTargetCoroutine = StartCoroutine(AttackTargetCoroutine());
    }

    private IEnumerator AttackTargetCoroutine()
    {
        player.Animation.BasicAttackAnimationEvent();
        damage = player.Data.attackValue;
        while (true)
        {
            if (ActivateAttackAnimation())
            {
                isAttack = false;
                break;
            }
            yield return null;
        }

        float curTime = 0f;
        while (true)
        {
            curTime += Time.deltaTime;
            if (curTime >= player.Data.attackDelayTime)
            {
                break;
            }
            yield return null;
        }

        player.Controller.CallAttackAnimationEnd();
    }

    private bool ActivateAttackAnimation( ) // АјАн
    {
        float progress = player.Animation.AnimationProgressTime;

        if (progress >= 1f)
            return false;
;
        if (!isAttack && progress >= takeDamageOffsetTime)
        {
            isAttack = true;
            TakeDamage();
        }

        return progress >= 0.9f;
    }
    private void TakeDamage()
    {
        Debug.Log(target);
        if (target == null)
            return;

        target.ActivateHealthEvent(-damage);
    }

}
