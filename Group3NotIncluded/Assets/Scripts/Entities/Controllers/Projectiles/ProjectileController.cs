using System;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] protected LayerMask levelCollisionLayer;

    protected AttackSO attackData;
    protected float currentDuration;
    protected Vector2 direction;
    protected bool isReady;

    protected Rigidbody2D _rigidbody;
    protected SpriteRenderer _spriteRenderer;



    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    protected virtual void Update()
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

    protected void OnTriggerEnter2D(Collider2D collision)
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

    protected bool IsLayerMatched(int layerMask, int objectLayer)
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

        transform.up = this.direction;

        isReady = true;
    }

    protected void UpdateProjectileSprite()
    {
        transform.localScale = Vector3.one * attackData.size;
    }
    protected void DestroyProjectile()
    {
        gameObject.SetActive(false);
    }
}
