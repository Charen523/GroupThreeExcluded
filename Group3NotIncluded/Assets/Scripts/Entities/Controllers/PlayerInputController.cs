using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : Controller
{
    public event Action<Vector2> OnMoveEvent; //������ �̺�Ʈ
    public event Action<bool> OnBoostEvent;
    
    protected PlayerStatHandler stats { get; private set; }

    //��Ƽ�÷��� ������ �� �÷��̾�1�� 2 ���� ��ũ��Ʈ ���� �� ���.
    protected virtual void Awake() 
    {
        stats = GetComponent<PlayerStatHandler>();
    }

    protected override void Update()
    {
        base.Update(); // �θ� Ŭ������ Update �޼��� ȣ��
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        OnMoveEvent?.Invoke(context.ReadValue<Vector2>().normalized);
    }

    //Boost�� ������ �ִ� ���� true.
    public void OnBoost(InputAction.CallbackContext context)
    {
        OnBoostEvent?.Invoke(context.phase == InputActionPhase.Performed);
    }

    protected override void HandleAttackDelay()
    {
        // ���� ������
        if (timeSinceLastAttack <= stats.currentStat.attackSO.delay)
        {
            timeSinceLastAttack += Time.deltaTime;
        }
        // ����
        if (timeSinceLastAttack > stats.currentStat.attackSO.delay)
        {
            timeSinceLastAttack = 0;
            CallAttackEvent(stats.currentStat.attackSO);
        }
    }
}
