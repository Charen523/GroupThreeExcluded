using UnityEngine;

public class PlayerHealthSystem : HealthSystem
{
    public GameObject[] PlayerHealthUI;

    private PlayerStatHandler statHandler;

    protected void Awake()
    {
        statHandler = GetComponent<PlayerStatHandler>();
    }

    protected void Start()
    {
        MaxHealth = statHandler.currentStat.maxHealth;
        CurrentHealth = statHandler.currentStat.maxHealth;
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

    protected void DisabledHP()
    {
        int num = CurrentHealth;
        PlayerHealthUI[num].SetActive(false);
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
            DisabledHP();
            DestroyEntity();
            return true;
        }

        if (change > 0)
        {
            OnHealEvent();
        }
        else
        {
            DisabledHP();
            isAttacked = true;
        }

        return true;
    }
}
