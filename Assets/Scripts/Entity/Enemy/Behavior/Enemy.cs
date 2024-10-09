using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [field: SerializeField] public EnemyStatData Data { get; private set; }

    public EnemyBehaviorController Controller { get; private set; }
    public EnemyAnimationEventHandler Animation { get; private set; }
    public HealthSystem Health { get; private set; }

    private void Awake()
    {
        Controller = GetComponent<EnemyBehaviorController>();
        Health = GetComponent<HealthSystem>();
        Animation = GetComponentInChildren<EnemyAnimationEventHandler>();

        Health.OnDeathEvent += Animation.DeathAnimationEvent;
        Animation.OnDeathAnimationEndEvent += DeActivateEnemy;

        Controller.EnemyBehaviorInit(this);
    }
    public void EnemyInit(RuntimeAnimatorController changedController, EnemyStatData data)
    {
        Data = data;
        Health.HealthInit(Data.Health);
        Animation.ChangeAnimationController(changedController);
        Controller.ActivateBehavior();
    }

    private void DeActivateEnemy()
    {
        GameManager.Instance.EnemySpawn.TryEnemySpawn();
    }

}
