using System;
using System.Collections;
using UnityEngine;

public class HealthSystem : MonoBehaviour 
{
    [SerializeField] protected float healthChangeDelay = 0.5f; // ü���� ���� �������� ������

    protected float timeSinceLastChange = float.MaxValue; // ������ ü�� ��ȭ ������ �ð�
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
    
    //�ڱ��ڽ� �ı�.
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
