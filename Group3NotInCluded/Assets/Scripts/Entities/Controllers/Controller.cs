using System;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    //���� event.
    public event Action<AttackSO> OnAttackEvent;

    protected float timeSinceLastAttack = float.MaxValue;

    protected virtual void Update()
    {
        HandleAttackDelay();
    }

    //�Ѿ� ��.
    protected abstract void HandleAttackDelay(); 

    public void CallAttackEvent(AttackSO attackSO)
    {
        OnAttackEvent?.Invoke(attackSO);
    }
}