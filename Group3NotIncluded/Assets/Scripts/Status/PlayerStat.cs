using System;
using UnityEngine;

[Serializable]
public class PlayerStat : UnitStat
{
    //EnemyStat으로부터 maxHealth와 attackSO 상속받음.
    public StatsChangeType statsChangeType;
    [Range(1f, 20f)] public float speed; //플레이어 이속
    [Range(1f, 10f)] public float boostGage;
}