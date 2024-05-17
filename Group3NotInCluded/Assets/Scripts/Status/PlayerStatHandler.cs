using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatHandler : EnemyStatHandler
{
    [SerializeField] private PlayerStat baseStats;
    public new PlayerStat currentStat { get; private set; }
    //예상: 버프 발생시 리스트로 추가해서 계산?
    //public List<CharacterStat> statsModifiers = new List<CharacterStat>();

    protected override void Awake()
    {
        UpdatePlayerStat();
    }

    private void UpdatePlayerStat()
    {
        AttackSO attackSO = null;
        if (baseStats.attackSO != null)
        {
            attackSO = Instantiate(baseStats.attackSO);
        }

        currentStat = new PlayerStat
        {
            attackSO = attackSO,
            maxHealth = baseStats.maxHealth,
            statsChangeType = baseStats.statsChangeType,
            speed = baseStats.speed,
            boostGage = baseStats.boostGage
        };
    }
}