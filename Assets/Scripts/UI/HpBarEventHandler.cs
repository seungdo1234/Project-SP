using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarEventHandler : MonoBehaviour
{
    [SerializeField] private Image hpBar;

    private HealthSystem target;
    private void Awake()
    {
        target = transform.root.GetComponent<HealthSystem>();

        target.OnHealthEvent += UpdateHpBar;
    }

    private void UpdateHpBar(float maxHealth, float curHealth)
    {
        hpBar.fillAmount = curHealth / maxHealth;
    }
}
