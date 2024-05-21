using System;
using System.Collections;
using UnityEngine;

public class HealthSystem : MonoBehaviour 
{
    [SerializeField] protected float healthChangeDelay = 0.5f; // 체력이 변할 때까지의 딜레이

    protected float timeSinceLastChange = float.MaxValue; // 마지막 체력 변화 이후의 시간
    protected bool isInvincible = false;

    public int StartHealth;
    public int MaxHealth;
    public int CurrentHealth { get; protected set; }

    protected virtual void Start()
    {
        StartCoroutine(OnInvincibleEvent());
    }

    protected virtual void Update()
    {
        if (isInvincible && timeSinceLastChange < healthChangeDelay)
        {
            timeSinceLastChange += Time.deltaTime;
            if (timeSinceLastChange >= healthChangeDelay)
            {
                isInvincible = false;
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

    public virtual void EnableHP()
    {
        
    }

    public IEnumerator OnInvincibleEvent()
    {
        isInvincible = true;

        yield return new WaitForSeconds(3);
        
        isInvincible = false;
    }
}
