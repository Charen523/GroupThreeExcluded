using UnityEngine;

public class EnemyHealthSystem : HealthSystem
{
    private EnemyStatHandler statHandler;

    [SerializeField] [Range(1, 5)] private int score = 1;

    protected void Awake()
    {
        statHandler = GetComponent<EnemyStatHandler>();
    }

    protected override void Start()
    {
        //비어있는 상태 override.
    }

    protected override void Update()
    {
        base.Update();
    }

    public void SetHealth(int health)
    {
        CurrentHealth = health;
    }

    protected override void DestroyEntity()
    {
        base.DestroyEntity();
        Managers.Instance.OnEnemyDead(gameObject);
    }

    public override bool ChangeHealth(float damage)
    {
        DestroyEntity();

        return true;
    }

    public int CallScore()
    {
        return score;
    }
}
