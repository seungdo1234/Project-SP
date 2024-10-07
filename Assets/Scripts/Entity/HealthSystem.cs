using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private float maxHealth;
    private float curHealth;
    
    public event Action<float> OnHealthEvent;
    public void HealthInit(float maxHealth)
    {
        this.maxHealth = maxHealth;
        curHealth = maxHealth;
    }

    public void ActivateHealthEvent(float amount) {
        
    }
}
