using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private PlayerInputController controller;
    private PlayerStatHandler playerStatus;
    private Rigidbody2D rb;

    private bool isBoost;
    private readonly float SPEED = 5f; //캐릭터 스탯으로 이동 필요.
    private Vector2 playerDirection = Vector2.zero;

    private void Awake()
    {
        controller = GetComponent<PlayerInputController>();
        playerStatus = GetComponent<PlayerStatHandler>();
        rb = GetComponent<Rigidbody2D>();   
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
        controller.OnBoostEvent += Boost;

    }

    private void FixedUpdate()
    {
        ApplyMovement(playerDirection);
    }

    private void Move(Vector2 direction)
    {
        playerDirection = direction;
    }

    private void Boost(bool isPressed)
    {
        isBoost = isPressed;    
    }

    private void ApplyMovement(Vector2 direction)
    {
        //boost 중이면 이속 * 3
        rb.velocity = direction * SPEED * (isBoost ? 3 : 1);
    }
}
