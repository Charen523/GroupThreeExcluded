using UnityEngine;

public abstract class HealthSystem : MonoBehaviour 
{
    /*ü�º���*/
    [SerializeField] protected int StartHealth; //���� ���۽�
    [SerializeField] protected float healthChangeDelay = 0.5f; // ü���� ���� �������� ������
    protected int MaxHealth; //�ִ� ü��
    protected int CurrentHealth;

    /*��������*/
    protected float hitDuration = float.MaxValue; // ������ ü�� ��ȭ ������ �ð�
    protected bool isInvincible = false;
    
    //ü�º�ȭ �߻�Ŭ����
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
