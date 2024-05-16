using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent; //������ �̺�Ʈ
    public event Action<bool> OnBoostEvent;
    
    public void OnMove(InputAction.CallbackContext context)
    {
        OnMoveEvent?.Invoke(context.ReadValue<Vector2>().normalized);
    }

    //Boost�� ������ �ִ� ���� true.
    public void OnBoost(InputAction.CallbackContext context)
    {
        OnBoostEvent?.Invoke(context.phase == InputActionPhase.Performed);
    }
}
