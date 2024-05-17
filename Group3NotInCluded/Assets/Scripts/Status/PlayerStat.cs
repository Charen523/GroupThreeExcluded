using System;
using UnityEngine;

[Serializable]
public class PlayerStat : UnitStat
{
    //EnemyStat���κ��� maxHealth�� attackSO ��ӹ���.
    public StatsChangeType statsChangeType;
    [Range(1f, 10f)] public float speed = 5f; //�÷��̾� �̼�
    [Range(10f, 50f)] public float maxBoostGage = 10f;
}