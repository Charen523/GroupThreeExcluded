using System;

using UnityEngine;
using UnityEngine.Experimental.XR.Interaction;

public abstract class HealthSystem : MonoBehaviour 
{
    [SerializeField] protected float healthChangeDelay = 0.5f; // ü���� ���� �������� ������

    protected float timeSinceLastChange = float.MaxValue; // ������ ü�� ��ȭ ������ �ð�
    public bool isInvincible = false;

    

    public int StartHealth;
    public int MaxHealth;
    public int CurrentHealth { get; protected set; }

    public abstract bool ChangeHealth(float damage);
    //�ڱ��ڽ� �ı�.
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
