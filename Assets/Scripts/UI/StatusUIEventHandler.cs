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



    private void Start()
    {
        UIManager.Instance.StatusUI = this;
    }

    public void ActivateStatusUI(EnemyStatData stat, float curHealth)
    {
        nameText.text = stat.Name;
        gradeText.text = GetGradeStringValue(stat.Grade);
        speedText.text = stat.Speed.ToString();
    }

    public void DeActivateStatusUI()
    {

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
