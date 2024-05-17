using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : Controller
{
    public event Action<Vector2> OnMoveEvent; //움직임 이벤트
    public event Action<bool> OnBoostEvent;
    
    protected PlayerStatHandler stats { get; private set; }

    //멀티플레이 구현할 때 플레이어1과 2 각각 스크립트 만들 것 대비.
    protected virtual void Awake() 
    {
        stats = GetComponent<PlayerStatHandler>();
    }

    protected override void Update()
    {
        base.Update(); // 부모 클래스의 Update 메서드 호출
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        OnMoveEvent?.Invoke(context.ReadValue<Vector2>().normalized);
    }

    //Boost를 누르고 있는 동안 true.
    public void OnBoost(InputAction.CallbackContext context)
    {
        OnBoostEvent?.Invoke(context.phase == InputActionPhase.Performed);
    }

    protected override void HandleAttackDelay()
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
}
