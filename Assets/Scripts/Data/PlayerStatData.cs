using System;
using UnityEngine;

[Serializable]
public class PlayerStatData : EntityStatData
{
    [Header("# Player Data Info")]
    public float attackValue;
    public float attackDelayTime;
}
