using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] protected float healthChangeDelay = 0.5f; // ü���� ���� �������� ������

    protected PlayerStatHandler statsHandler;
    protected float timeSinceLastChange = float.MaxValue;         // ������ ü�� ��ȭ ������ �ð�
    protected bool isAttacked = false;

    // ü���� ������ �� �� �ൿ���� ����
    public event Action OnDamage;
    public event Action OnHeal;
    public event Action OnDeath;
    public event Action OnInvincibilityEnd;

    public float MaxHealth => statsHandler.currentStat.maxHealth;
    
    public float CurrentHealth { get; protected set; }

    protected void Awake()
    {

        // TODO : �÷��̾� ���� �ڵ鷯�� ���ʹ� ���� �ڵ鷯�� �����ؾ� �ҵ�?
        statsHandler = GetComponent<PlayerStatHandler>();
    }

    void Start()
    {
        CurrentHealth = statsHandler.currentStat.maxHealth;

        // TODO : �����
        // �׽�Ʈ ��
        OnDeath += TestGameEnd;
    }

    void Update()
    {
        if (isAttacked && timeSinceLastChange < healthChangeDelay)
        {
            timeSinceLastChange += Time.deltaTime;
            if (timeSinceLastChange >= healthChangeDelay)
            {
                isAttacked = false;
            }
        }
    }

    public bool ChangeHealth(float change)
    {
        if (timeSinceLastChange < healthChangeDelay)
        {
            return false;
        }

        timeSinceLastChange = 0f;
        CurrentHealth += change;

        // �ּڰ��� �ִ��� ����
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);

        if (CurrentHealth <= 0)
        {
            CallDeath();
            return true;
        }

        if (change >= 0)
        {
            OnHeal?.Invoke();
        }
        else
        {
            OnDamage?.Invoke();
            isAttacked = true;
        }

        return true;
    }

    protected void CallDeath()
    {
        OnDeath?.Invoke();
    }

    // �׽�Ʈ��
    protected void TestGameEnd()
    {
        Destroy(gameObject);
    }
}
