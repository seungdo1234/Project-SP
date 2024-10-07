using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEventHandler : EntityAnimationEventHandler
{
    private PlayerAnimationData data;

    protected override void Awake()
    {
        base.Awake();
        data = new PlayerAnimationData();

    }

    public void BasicAttackAnimationEvent()
    {
        anim.SetTrigger(data.BasicAttackParameterHash);
    }

    public void CriticalAttackAnimationEvent()
    {
        anim.SetTrigger(data.CriticalAttackParameterHash);
    }

    public void SpecialAttackAnimationEvent()
    {
        anim.SetTrigger(data.SpecialAttackParameterHash);
    }
}
