using UnityEngine;

public abstract class UnitStatHandler<T> : MonoBehaviour where T : UnitStat
{
    [SerializeField] protected T baseStats;
    public T currentStat { get; protected set; }

    protected virtual void Awake()
    {
        UpdateStat();
    }

    protected virtual void UpdateStat()
    {
        AttackSO attackSO = null;
        if (baseStats.attackSO != null)
        {
            attackSO = Instantiate(baseStats.attackSO);
        }

        currentStat = (T)System.Activator.CreateInstance(typeof(T));
        currentStat.attackSO = attackSO;
        currentStat.maxHealth = baseStats.maxHealth;
    }
}
