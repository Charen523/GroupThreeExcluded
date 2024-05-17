using System;
using UnityEngine;

[Serializable]
public class UnitStat
{
    [Range(1, 5)] public int maxHealth;
    public AttackSO attackSO;
}