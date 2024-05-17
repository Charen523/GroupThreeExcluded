using UnityEngine;

public class EnemyStatHandler : MonoBehaviour
{
    [SerializeField] private EnemyStat baseStats;
    public EnemyStat currentStat { get; private set; }

    protected virtual void Awake()
    {
        UpdateEnemyStat();
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