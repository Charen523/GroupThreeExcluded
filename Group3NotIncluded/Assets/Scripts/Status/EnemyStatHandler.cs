using UnityEngine;

public class EnemyStatHandler : MonoBehaviour
{
    [SerializeField] private EnemyStat baseStats;
    public EnemyStat currentStat { get; private set; }

    private void Awake()
    {
        UpdateEnemyStat();
    }

    private void UpdateEnemyStat()
    {
        AttackSO attackSO = null;
        if (baseStats.attackSO != null)
        {
            attackSO = Instantiate(baseStats.attackSO);
        }

        currentStat = new EnemyStat { attackSO = attackSO };
        currentStat.maxHealth = baseStats.maxHealth;
    }
}