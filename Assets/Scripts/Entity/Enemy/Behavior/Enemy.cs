using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [field: SerializeField] public EnemyData Data { get; private set; }

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
    }

    private void Start()
    {
        Controller.EnemyBehaviorInit(this);
        Health.HealthInit(Data.maxHealth);
    }

    private void DeActivateEnemy()
    {
        gameObject.SetActive(false);
    }

}
