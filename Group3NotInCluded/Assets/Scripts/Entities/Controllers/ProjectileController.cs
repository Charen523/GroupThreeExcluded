using System;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
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
            DestoryProjectile();
        }

        _rigidbody.velocity = direction * attackData.speed;
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
    private void DestoryProjectile()
    {
        gameObject.SetActive(false);
    }
}