using UnityEngine;

public class PlayerHealthSystem : HealthSystem
{
    public GameObject[] PlayerHealthUI;

    private PlayerStatHandler statHandler;

    protected void Awake()
    {
        statHandler = GetComponent<PlayerStatHandler>();
    }

    protected override void Start()
    {
        base.Start();

        StartHealth = 3;
        CurrentHealth = StartHealth;
        MaxHealth = statHandler.currentStat.maxHealth;
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void DestroyEntity()
    {
        base.DestroyEntity();
        Managers.Instance.OnGameOverEvent();

        //TODO: 모든 플레이어가 파괴됐을 때.
    }

    protected void DisableHP()
    {
        PlayerHealthUI[CurrentHealth].SetActive(false);
    }

    public override void EnableHP()
    {
        Debug.Log("전 "+ CurrentHealth);
        if (CurrentHealth < MaxHealth)
        {
            PlayerHealthUI[CurrentHealth].SetActive(true);
            CurrentHealth += 1;
        }
        Debug.Log("후 " + CurrentHealth);
    }

    public override bool ChangeHealth(float change)
    {
        if (timeSinceLastChange < healthChangeDelay)
        {
            return false;
        }

        timeSinceLastChange = 0f;
        CurrentHealth += (int)change;

        // 최솟값과 최댓값을 설정
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);

        if (CurrentHealth <= 0)
        {
            DisableHP();
            DestroyEntity();
            return true;
        }
        else
        {
            DisableHP();
            isInvincible = true;
        }

        return true;
    }

    
}
