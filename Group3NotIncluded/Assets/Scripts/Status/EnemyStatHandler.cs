using UnityEngine;

public class EnemyStatHandler : UnitStatHandler
{
    [SerializeField] private EnemyStat baseStats;
    public EnemyStat currentStat { get; private set; }

    protected override void Awake()
    {
        base.Awake();
    }

    protected void UpdateEnemyStat()
    {
        AttackSO attackSO = null;
        if (baseStats.attackSO != null)
        {
            attackSO = Instantiate(baseStats.attackSO);
        }

        currentStat = new EnemyStat
        {
            attackSO = attackSO,
            maxHealth = baseStats.maxHealth
        };
    }
}