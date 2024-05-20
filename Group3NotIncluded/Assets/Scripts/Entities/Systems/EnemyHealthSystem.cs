using UnityEngine;

public class EnemyHealthSystem : HealthSystem
{
    protected EnemyStatHandler enemyStatHandler;

    [SerializeField] [Range(1, 5)] private int score = 1;

    public override float MaxHealth => enemyStatHandler.currentStat.maxHealth;

    protected override void Awake()
    {
        enemyStatHandler = GetComponent<EnemyStatHandler>();
    }

    protected override void Start()
    {
        CurrentHealth = enemyStatHandler.currentStat.maxHealth;

        OnDeath += DestroyEnemy;
        OnDeath += AddScore;
    }

    protected override void Update()
    {
        base.Update();
    }

    public void SetHealth(float health)
    {
        CurrentHealth = health;
    }

    protected override void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    protected void AddScore()
    {
        EnemyManager.Instance.AddScore(score);
        Debug.Log(EnemyManager.Instance.CallCurrentScore());
    }
}
