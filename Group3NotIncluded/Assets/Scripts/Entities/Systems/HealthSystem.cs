using UnityEngine;

public abstract class HealthSystem : MonoBehaviour 
{
    /*체력변수*/
    [SerializeField] protected int StartHealth; //게임 시작시
    [SerializeField] protected float healthChangeDelay = 0.5f; // 체력이 변할 때까지의 딜레이
    protected int MaxHealth; //최대 체력
    protected int CurrentHealth;

    /*무적변수*/
    protected float hitDuration = float.MaxValue; // 마지막 체력 변화 이후의 시간
    protected bool isInvincible = false;
    
    //체력변화 추상클래스
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
        if (isInvincible && hitDuration < healthChangeDelay)
        {
            hitDuration += Time.deltaTime;
            if (hitDuration >= healthChangeDelay)
            {
                isInvincible = false;
            }
        }
    }
}
