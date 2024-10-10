using System;
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

    [Header("# Entity Data Info")]
    [SerializeField] private Sprite[] entitySprites;
    
    private Enemy targetEnemy;
    private void Start()
    {
        UIManager.Instance.StatusUI = this;
        gameObject.SetActive(false);
    }

    public void ActivateStatusUI(Enemy enemy)
    {
        try
        {
            gameObject.SetActive(true);

            targetEnemy = enemy;

            nameText.text = enemy.Data.Name;
            gradeText.text = GetGradeStringValue(enemy.Data.Grade);
            speedText.text = enemy.Data.Speed.ToString();
            healthText.text = $"{enemy.Health.CurHealth} / {enemy.Data.Health}";

            entityImage.sprite = GetEntitySprite(enemy.Data.Name);
        
            enemy.Health.OnHealthEvent += UpdateHealthText;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void DeActivateStatusUI()
    {
        if(!gameObject.activeSelf)
            return;
        
        targetEnemy.Health.OnHealthEvent -= UpdateHealthText;

        targetEnemy = null;

        gameObject.SetActive(false);
    }

    private void UpdateHealthText(float maxHealth, float curHealth)
    {
        healthText.text = $"{curHealth}/{maxHealth}";
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

    private Sprite GetEntitySprite(string name)
    {
        return name switch
        {
            "Skeleton" => entitySprites[0],
            "Elite Orc" => entitySprites[1],
            "Wizard" => entitySprites[2],
            "Werebear" => entitySprites[3],
            "Orc rider" => entitySprites[4],
            _ => null
        };
    }
}
