using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : Controller
{
    public event Action<Vector2> OnMoveEvent; 
    public event Action<bool> OnBoostEvent;
    
    protected PlayerStatHandler stats { get; private set; }

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

        //test
        Vector2 playerAimDirection = context.ReadValue<Vector2>().normalized;
        CallLookEvent(playerAimDirection);
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
