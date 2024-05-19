using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] protected float healthChangeDelay = 0.5f; // ü���� ���� �������� ������

    protected PlayerStatHandler playerStatHandler;
    protected float timeSinceLastChange = float.MaxValue;         // ������ ü�� ��ȭ ������ �ð�
    protected bool isAttacked = false;

    // ü���� ������ �� �� �ൿ���� ����
    public event Action OnDamage;
    public event Action OnHeal;
    public event Action OnDeath;
    public event Action OnInvincibilityEnd;
    

    // TODO : �÷��̾� ���� �ڵ鷯�� ���ʹ� ���� �ڵ鷯�� �����ؾ� �ҵ�?
    public virtual float MaxHealth => playerStatHandler.currentStat.maxHealth;
    
    public float CurrentHealth { get; protected set; }

    protected virtual void Awake()
    {

        // TODO : �÷��̾� ���� �ڵ鷯�� ���ʹ� ���� �ڵ鷯�� �����ؾ� �ҵ�?
        playerStatHandler = GetComponent<PlayerStatHandler>();
    }

    protected virtual void Start()
    {
        CurrentHealth = playerStatHandler.currentStat.maxHealth;

        // TODO : �����
        // �׽�Ʈ ��
        OnDeath += TestGameEnd;
    }

    protected virtual void Update()
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
    protected virtual void TestGameEnd()
    {
        //Destroy(gameObject);
    }
}
