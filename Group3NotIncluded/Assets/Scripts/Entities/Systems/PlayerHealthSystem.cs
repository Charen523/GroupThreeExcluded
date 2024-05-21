using System.Collections;
using UnityEngine;

public class PlayerHealthSystem : HealthSystem
{
    public GameObject[] PlayerHealthUI;

    private PlayerStatHandler statHandler;

    private Coroutine invincibleCoroutine;

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

    public void EnableHP()
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
        else if (isInvincible)
        {
            Debug.Log("Currently invincible, no damage taken.");
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

    private IEnumerator StatusToggle()
    {
        isInvincible = true;
        Debug.Log("Invincibility started");

        yield return new WaitForSeconds(3);

        isInvincible = false;
        invincibleCoroutine = null;
        Debug.Log("Invincibility ended");
    }

    public void OnInvincibleEvent()
    {
        //이미 실행중인 코루틴이 있으면 중지.
        if (invincibleCoroutine != null)
        {
            StopCoroutine(invincibleCoroutine);
        }

        //새로 3초 무적시간 적용.
        invincibleCoroutine = StartCoroutine(StatusToggle());
    }
}
