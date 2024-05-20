using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour 
{
    [SerializeField] protected float healthChangeDelay = 0.5f; // 체력이 변할 때까지의 딜레이

    protected float timeSinceLastChange = float.MaxValue; // 마지막 체력 변화 이후의 시간
    protected bool isAttacked = false;

    // 체력이 변했을 때 할 행동들을 정의
    public event Action OnHeal;
    public event Action OnInvincibilityEnd;

    public int MaxHealth;
    
    public int CurrentHealth { get; protected set; }

    protected virtual void Update()
    {
        if (isAttacked && timeSinceLastChange < healthChangeDelay)
        {
            timeSinceLastChange += Time.deltaTime;
            if (timeSinceLastChange >= healthChangeDelay)
            {
                isAttacked = false;
                OnInvincibilityEnd?.Invoke();
            }
        }
    }

    public virtual bool ChangeHealth(float damage)
    {
        CurrentHealth += (int)damage;

        return true;
    }
    
    //자기자신 파괴.
    protected virtual void DestroyEntity()
    {
        Destroy(gameObject);
    }

    protected void OnHealEvent()
    {
        OnHeal?.Invoke();
    }
}
