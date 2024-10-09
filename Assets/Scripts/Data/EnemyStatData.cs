using System;
using UnityEngine;


public enum E_GradeType { Common, Rare, Magic, Legendary, Hero}
[Serializable]
public class EnemyStatData : EntityStatData
{
    [Header("# Enemy Data Info")]
    public string Name;
    public E_GradeType Grade;
    public float Health;
    public float Speed;
}
