using System;
using UnityEngine;

public enum E_GradeType { Common, Rare, Magic, Legendry, Hero}
[Serializable]
public class EnemyData : EntityData
{
    [Header("# Enemy Data Info")]
    public string name;
    public E_GradeType grade;
    public float maxHealth;
    public float moveSpeed;
}
