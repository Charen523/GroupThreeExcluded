using System;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public event Action<Vector2> OnLookEvent;
    public event Action<AttackSO> OnAttackEvent;

    private float timeSinceLastAttack = float.MaxValue;

    protected EnemyStatHandler stats { get; private set; }

    protected virtual void Awake()
    {
        stats = GetComponent<EnemyStatHandler>();
    }

    protected virtual void Update()
    {
        HandleAttackDelay();
    }

    protected void HandleAttackDelay()
    {
        // 공격 딜레이
        if (timeSinceLastAttack <= stats.currentStat.attackSO.delay)
        {
            timeSinceLastAttack += Time.deltaTime;
        }
        // 공격
        if (timeSinceLastAttack > stats.currentStat.attackSO.delay)
        {
            timeSinceLastAttack = 0;
            CallAttackEvent(stats.currentStat.attackSO);
        }
    }

    public void CallAttackEvent(AttackSO attackSO)
    {
        OnAttackEvent?.Invoke(attackSO);
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }
}