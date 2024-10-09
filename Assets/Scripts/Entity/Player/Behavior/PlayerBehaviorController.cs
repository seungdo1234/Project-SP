using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerBehaviorController : MonoBehaviour
{

    public event Action<HealthSystem> OnAttackEvent;
    public event Func<HealthSystem> OnDetactEvent;

    private Coroutine playerBehaviorCoroutine;

    private bool IsAnimationPlaying;
    public void PlayerBehaviorInit()
    {
        ActivateBehavior();
    }

    private void ActivateBehavior()
    {
        if (playerBehaviorCoroutine != null)
        {
            StopCoroutine(playerBehaviorCoroutine);
        }

        playerBehaviorCoroutine = StartCoroutine(PlayerBehaviorCoroutine());
    }
    private IEnumerator PlayerBehaviorCoroutine()
    {
        while (true)
        {
            if (!IsAnimationPlaying)
            {
                HealthSystem target = OnDetactEvent.Invoke();
                if (target != null)
                {
                    OnAttackEvent?.Invoke(target);
                    IsAnimationPlaying = true;
                }
            }
            yield return null;
        }
    }
    public void CallAttackAnimationEnd()
    {
        IsAnimationPlaying = false;
    }
}
