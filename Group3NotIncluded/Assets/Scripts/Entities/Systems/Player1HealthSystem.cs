public class Player1HealthSystem : HealthSystem
{
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
        OnDeath += Player1Dead;
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void DestroyEnemy()
    {
        base.DestroyEnemy();
    }

    protected void Player1Dead()
    {
        Managers.Instance.OnGameOverEvent();
    }

    protected override void DisabledHP()
    {
        int num = (int)(CurrentHealth);

        Managers.Instance.enemyManager.player1HP[num].SetActive(false);
    }
}
