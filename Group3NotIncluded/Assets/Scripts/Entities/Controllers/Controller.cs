using System;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    public event Action<Vector2> OnLookEvent;
    public event Action<AttackSO> OnAttackEvent;

    protected float timeSinceLastAttack = float.MaxValue;

    protected virtual void Update()
    {
        HandleAttackDelay();
    }

    //ÃÑ¾Ë ºóµµ.
    protected abstract void HandleAttackDelay(); 

    public void CallAttackEvent(AttackSO attackSO)
    {
        OnAttackEvent?.Invoke(attackSO);
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }
}