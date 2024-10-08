using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float curHealth;
    private float maxHealth;
    
    public event Action<float> OnHealthEvent;
    public void HealthInit(float maxHealth)
    {
        this.maxHealth = maxHealth;
        curHealth = maxHealth;
    }

    public void ActivateHealthEvent(float amount) {
        Debug.Log(amount);
        curHealth += amount;
    }
}
