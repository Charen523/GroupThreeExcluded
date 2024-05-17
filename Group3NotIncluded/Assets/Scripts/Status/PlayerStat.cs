using System;
using UnityEngine;

[Serializable]
public class PlayerStat : UnitStat
{
    //EnemyStat���κ��� maxHealth�� attackSO ��ӹ���.
    public StatsChangeType statsChangeType;
    [Range(10f, 100f)] public float speed = 20f; //�÷��̾� �̼�
    [Range(1f, 10f)] public float maxBoostGage = 1f;
}