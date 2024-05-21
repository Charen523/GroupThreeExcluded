using System;

using UnityEngine;
using UnityEngine.Experimental.XR.Interaction;

public abstract class HealthSystem : MonoBehaviour 
{
    [SerializeField] protected float healthChangeDelay = 0.5f; // 체력이 변할 때까지의 딜레이

    protected float timeSinceLastChange = float.MaxValue; // 마지막 체력 변화 이후의 시간
    public bool isInvincible = false;

    

    public int StartHealth;
    public int MaxHealth;
    public int CurrentHealth { get; protected set; }

    public abstract bool ChangeHealth(float damage);
    //자기자신 파괴.
    protected virtual void DestroyEntity()
    {
        Destroy(gameObject);
    }

    protected virtual void Start()
    {
        
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
}
