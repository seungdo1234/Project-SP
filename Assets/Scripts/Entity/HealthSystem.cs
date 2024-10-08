using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float curHealth;
    private float maxHealth;

    public event Action<float> OnHealthEvent;
    public event Action<bool> OnDeathEvent;

    private bool isDie = false;

    private readonly string enemyLayerName = "Enemy";
    private readonly string enemyDieLayerName = "EnemyDie";
    private void Awake()
    {
        OnDeathEvent += SetDeath;
    }
    public void HealthInit(float maxHealth)
    {
        this.maxHealth = maxHealth;
        curHealth = maxHealth;
        OnDeathEvent?.Invoke(false);
    }


    public void ActivateHealthEvent(float amount)
    {
        if (isDie)
            return;

        curHealth += amount;

        if (curHealth <= 0)
        {
            OnDeathEvent?.Invoke(true);
        }
        else if (amount < 0)
        {

        }

        OnHealthEvent?.Invoke(amount);
    }

    private void SetDeath(bool isTrue)
    {
        isDie = isTrue;
        gameObject.layer = isDie ? LayerMask.NameToLayer(enemyDieLayerName) : LayerMask.NameToLayer(enemyLayerName);
    }
}
