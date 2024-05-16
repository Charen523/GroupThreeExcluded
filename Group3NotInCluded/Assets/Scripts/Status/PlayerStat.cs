using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerStat
{
    public StatsChangeType statsChangeType;
    [Range(1, 10)] public int maxHealth; //life sprite? image? �� ����.
    [Range(1f, 20f)] public float speed;
    [Range(1f, 10f)] public float bulletSpeed; //�Ѿ� �ӵ�: �������� ��Ȯ���� ������.
    [Range(1f, 10f)] public float bulletFrequency; //�Ѿ� ��: �������� ���� ����.
    [Range(1f, 10f)] public float boostGage; 
    //public AttackSO attackSO; merge �� �ּ�Ǯ��
}