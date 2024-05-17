using System;
using UnityEngine;

[Serializable]
public class EnemyStat
{
    [Range(1, 5)] public int maxHealth;
    public AttackSO attackSO;
}