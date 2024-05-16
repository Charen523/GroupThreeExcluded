using System;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public event Action<AttackSO> OnAttackEvent;

    public void CallAttackEvent(AttackSO attackSO)
    {
        OnAttackEvent?.Invoke(attackSO);
    }
}