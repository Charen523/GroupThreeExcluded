public class EnemyHealthSystem : HealthSystem
{
    protected EnemyStatHandler enemyStatHandler; 

    public override float MaxHealth => enemyStatHandler.currentStat.maxHealth;

    protected override void Awake()
    {
        enemyStatHandler = GetComponent<EnemyStatHandler>();
    }

    protected override void Start()
    {
        CurrentHealth = enemyStatHandler.currentStat.maxHealth;

        OnDeath += TestGameEnd;
    }

    protected override void Update()
    {
        base.Update();
    }

    public void SetHealth(float health)
    {
        CurrentHealth = health;
    }

    protected override void TestGameEnd()
    {
        Destroy(gameObject);
    }
}
