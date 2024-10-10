using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatusUIEventHandler : MonoBehaviour
{
    [Header("# Status UI Component Info")]
    [SerializeField] private Image entityImage;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI gradeText;
    [SerializeField] private TextMeshProUGUI speedText;


    private Enemy targetEnemy;
    private void Start()
    {
        UIManager.Instance.StatusUI = this;
    }

    public void ActivateStatusUI(Enemy enemy)
    {
        gameObject.SetActive(true);

        targetEnemy = enemy;

        nameText.text = enemy.Data.Name;
        gradeText.text = GetGradeStringValue(enemy.Data.Grade);
        speedText.text = enemy.Data.Speed.ToString();
        healthText.text = $"{enemy.Health.CurHealth} / {enemy.Data.Health}";

        enemy.Health.OnHealthEvent += UpdateHealthText;
    }

    public void DeActivateStatusUI()
    {
        targetEnemy.Health.OnHealthEvent -= UpdateHealthText;

        targetEnemy = null;

        gameObject.SetActive(false);
    }

    private void UpdateHealthText(float maxHealth, float curHealth)
    {
        healthText.text = $"{curHealth} / {maxHealth}";
    }
    private string GetGradeStringValue(E_GradeType grade)
    {
        return grade switch
        {
            E_GradeType.Common => "일반" , 
            E_GradeType.Rare => "레어" , 
            E_GradeType.Magic => "매직" , 
            E_GradeType.Legendary => "전설" , 
            E_GradeType.Hero => "히어로" ,
            _ => "Default"
        };
    }
}
