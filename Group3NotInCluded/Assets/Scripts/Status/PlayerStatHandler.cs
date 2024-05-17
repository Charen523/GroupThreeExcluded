using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatHandler : MonoBehaviour
{
    [SerializeField] private PlayerStat baseStat;
    public PlayerStat currentStat { get; private set; }
    //강의에 있던 건데 아마 연산에 쓰임. 
    //예상: 버프 발생시 리스트로 추가해서 계산?
    //public List<CharacterStat> statsModifiers = new List<CharacterStat>();

    private void Awake()
    {
        UpdatePlayerStat();
    }

    private void UpdatePlayerStat()
    {
        currentStat = new PlayerStat();

        currentStat.statsChangeType = baseStat.statsChangeType;
        currentStat.maxHealth = baseStat.maxHealth;
        currentStat.speed = baseStat.speed;
        currentStat.bulletSpeed = baseStat.bulletSpeed;
        currentStat.bulletFrequency = baseStat.bulletFrequency;
        currentStat.boostGage = baseStat.boostGage;
    }
}