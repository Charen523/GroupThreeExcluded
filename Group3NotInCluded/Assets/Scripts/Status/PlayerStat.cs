using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerStat
{
    public StatsChangeType statsChangeType;
    [Range(1, 10)] public int maxHealth; //life sprite? image? 의 개수.
    [Range(1f, 20f)] public float speed;
    [Range(1f, 10f)] public float bulletSpeed; //총알 속도: 빠를수록 정확도가 높아짐.
    [Range(1f, 10f)] public float bulletFrequency; //총알 빈도: 높을수록 자주 생김.
    [Range(1f, 10f)] public float boostGage; 
    //public AttackSO attackSO; merge 후 주석풀기
}