using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour 
{
    [SerializeField] protected float healthChangeDelay = 0.5f; // ü���� ���� �������� ������

    protected float timeSinceLastChange = float.MaxValue; // ������ ü�� ��ȭ ������ �ð�
    protected bool isAttacked = false;

    // ü���� ������ �� �� �ൿ���� ����
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
    
    //�ڱ��ڽ� �ı�.
    protected virtual void DestroyEntity()
    {
        Destroy(gameObject);
    }

    protected void OnHealEvent()
    {
        OnHeal?.Invoke();
    }
}
