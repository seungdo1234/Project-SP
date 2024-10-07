using UnityEngine;

public class PlayerAnimationData
{
    private string basicAttackParameterName = "TryBasicAttack";
    private string criticalAttackParameterName = "TryCriticalAttack";
    private string specialAttackParameterName = "TrySpecialAttack";

    public int BasicAttackParameterHash { get; private set; }
    public int CriticalAttackParameterHash { get; private set; }
    public int SpecialAttackParameterHash { get; private set; }

    public PlayerAnimationData()
    {
        BasicAttackParameterHash = Animator.StringToHash(basicAttackParameterName);
        CriticalAttackParameterHash = Animator.StringToHash(criticalAttackParameterName);
        SpecialAttackParameterHash = Animator.StringToHash(specialAttackParameterName);
    }
}

public class EnemyAnimationData
{
    private string runParameterName = "IsWalk";
    private string hurtParameterName = "TryHurt";
    private string deathParameterName = "IsDeath";

    public int WalkParameterHash { get; private set; }
    public int HurtParameterHash { get; private set; }
    public int DeathParameterHash { get; private set; }

    public EnemyAnimationData()
    {
        WalkParameterHash = Animator.StringToHash(runParameterName);
        HurtParameterHash = Animator.StringToHash(hurtParameterName);
        DeathParameterHash = Animator.StringToHash(deathParameterName);
    }
}