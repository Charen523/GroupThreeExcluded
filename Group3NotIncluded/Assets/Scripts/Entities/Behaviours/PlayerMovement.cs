using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private PlayerInputController controller;
    private PlayerStatHandler playerStatus;
    private BoostSystem boostSystem;
    private Rigidbody2D rb;

    private bool isBoost;
    private float speed;
    private readonly float rotationSpeed = 0.1f;
    private Vector2 playerDirection = Vector2.zero;

    private void Awake()
    {
        controller = GetComponent<PlayerInputController>();
        playerStatus = GetComponent<PlayerStatHandler>();
        boostSystem = GetComponent<BoostSystem>();
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
        ApplyRotate(playerDirection);

        isBoost = isBoost && boostSystem.CanBoost;
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
        speed = playerStatus.GetSpeed();
        rb.velocity = direction * speed * (isBoost ? 3 : 1) * Time.deltaTime;
    }

    private void ApplyRotate(Vector2 direction)
    {
        if (playerDirection != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed);
        }
    }
}
