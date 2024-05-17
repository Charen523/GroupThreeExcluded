using System;
using UnityEngine;

[Serializable]
public class PlayerStat : UnitStat
{
    //EnemyStat���κ��� maxHealth�� attackSO ��ӹ���.
    public StatsChangeType statsChangeType;
    [Range(1f, 20f)] public float speed; //�÷��̾� �̼�
    [Range(1f, 10f)] public float boostGage;
}