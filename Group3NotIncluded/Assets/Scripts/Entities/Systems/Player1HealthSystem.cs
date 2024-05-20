public class Player1HealthSystem : HealthSystem
{
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void DestroyEnemy()
    {
        base.DestroyEnemy();
    }

    protected override void DisabledHP()
    {
        int num = (int)(CurrentHealth);

        EnemyManager.Instance.player1HP[num].SetActive(false);
    }
}
