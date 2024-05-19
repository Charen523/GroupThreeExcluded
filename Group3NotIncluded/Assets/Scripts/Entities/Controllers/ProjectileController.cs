using System;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private LayerMask levelCollisionLayer;

    private AttackSO attackData;
    private float currentDuration;
    private Vector2 direction;
    private bool isReady;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;



    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (!isReady)
        {
            return;
        }

        currentDuration += Time.deltaTime;

        if (currentDuration >= attackData.duration)
        {
            DestroyProjectile();
        }

        _rigidbody.velocity = direction * attackData.speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsLayerMatched(levelCollisionLayer.value, collision.gameObject.layer))
        {
            DestroyProjectile();
        }
        else if (IsLayerMatched(attackData.target.value, collision.gameObject.layer))
        {
            HealthSystem healthSystem = collision.GetComponent<HealthSystem>();
            if (healthSystem != null)
            {
                bool isAttackApplied = healthSystem.ChangeHealth(-attackData.power);
            }

            DestroyProjectile();
        }
    }

    private bool IsLayerMatched(int layerMask, int objectLayer)
    {
        return layerMask == (layerMask | (1 << objectLayer));
    }


    public void InitializeAttack(Vector2 direction, AttackSO attackData)
    {
        this.direction = direction;
        this.attackData = attackData;

        UpdateProjectileSprite();
        currentDuration = 0;
        _spriteRenderer.color = attackData.projectileColor;

        isReady = true;
    }

    private void UpdateProjectileSprite()
    {
        transform.localScale = Vector3.one * attackData.size;
    }
    private void DestroyProjectile()
    {
        gameObject.SetActive(false);
    }
}