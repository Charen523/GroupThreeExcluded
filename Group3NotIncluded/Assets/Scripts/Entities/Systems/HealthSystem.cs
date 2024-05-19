using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] protected float healthChangeDelay = 0.5f; // 체력이 변할 때까지의 딜레이

    protected PlayerStatHandler playerStatHandler;
    protected float timeSinceLastChange = float.MaxValue;         // 마지막 체력 변화 이후의 시간
    protected bool isAttacked = false;

    // 체력이 변했을 때 할 행동들을 정의
    public event Action OnDamage;
    public event Action OnHeal;
    public event Action OnDeath;
    public event Action OnInvincibilityEnd;
    

    // TODO : 플레이어 스탯 핸들러와 에너미 스탯 핸들러를 통합해야 할듯?
    public virtual float MaxHealth => playerStatHandler.currentStat.maxHealth;
    
    public float CurrentHealth { get; protected set; }

    protected virtual void Awake()
    {

        // TODO : 플레이어 스탯 핸들러와 에너미 스탯 핸들러를 통합해야 할듯?
        playerStatHandler = GetComponent<PlayerStatHandler>();
    }

    protected virtual void Start()
    {
        CurrentHealth = playerStatHandler.currentStat.maxHealth;

        // TODO : 지우기
        // 테스트 용
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

        // 최솟값과 최댓값을 설정
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

    // 테스트용
    protected virtual void TestGameEnd()
    {
        //Destroy(gameObject);
    }
}
