using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [field: SerializeField] public float CurHealth { get; private set; }
    private float maxHealth;

    public event Action<float, float> OnHealthEvent;
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
        CurHealth = maxHealth;

        OnHealthEvent?.Invoke(this.maxHealth, CurHealth);
        OnDeathEvent?.Invoke(false);
    }


    public void ActivateHealthEvent(float amount)
    {
        if (isDie)
            return;

        CurHealth += amount;
        CurHealth = Mathf.Max(0, CurHealth);

        OnHealthEvent?.Invoke(maxHealth, CurHealth);

        if (CurHealth <= 0)
        {
            OnDeathEvent?.Invoke(true);
        }
        else if (amount < 0)
        {

        }

    }

    private void SetDeath(bool isTrue)
    {
        isDie = isTrue;
        gameObject.layer = isDie ? LayerMask.NameToLayer(enemyDieLayerName) : LayerMask.NameToLayer(enemyLayerName);

        if (isDie)
        {
            UIManager.Instance.StatusUI.DeActivateStatusUI();
        }
    }
}
