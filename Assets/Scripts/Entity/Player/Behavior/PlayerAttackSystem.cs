using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackSystem : MonoBehaviour
{
    private bool isAttack;

    private Player player;
    private HealthSystem target;

    private Coroutine attackTargetCoroutine;
    public void PlayerAttackInit(Player player)
    {
        this.player = player;
        player.Controller.OnAttackEvent += PlayerAttack;
    }

    private void PlayerAttack(HealthSystem target)
    {
        this.target = target;
        isAttack = true;

        if (attackTargetCoroutine != null)
        {
            StopCoroutine(attackTargetCoroutine);
        }
        attackTargetCoroutine = StartCoroutine(AttackTargetCoroutine());
    }

    private IEnumerator AttackTargetCoroutine()
    {
        while (true)
        {
            // 애니메이션
            yield return null;
        }
    }
}
