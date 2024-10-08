using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationEventHandler : EntityAnimationEventHandler
{
    private EnemyAnimationData data;

    public event Action OnDeathAnimationEndEvent;
    public event Action<bool> OnHurtAnimationEndEvent;
    protected override void Awake()
    {
        base.Awake();
        data = new EnemyAnimationData();
    }

    public void DeathAnimationEvent(bool isDie)
    {
        anim.SetBool(data.DeathParameterHash, isDie);
    }
    public void RunAnimationEvent(bool isRun)
    {
        anim.SetBool(data.WalkParameterHash, isRun);
    }

    public void HurtAnimationEvent()
    {
        anim.SetTrigger(data.HurtParameterHash);
    }

    public void DeathCallback()
    {
        OnDeathAnimationEndEvent?.Invoke();
    }

    public void HurtCallback(bool isTrue)
    {
        OnHurtAnimationEndEvent?.Invoke(isTrue);
    }

    public void ChangeAnimationController(RuntimeAnimatorController changedController)
    {
        anim.runtimeAnimatorController = changedController;
    }
}
