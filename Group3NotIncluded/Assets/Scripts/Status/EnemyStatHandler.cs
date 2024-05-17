using UnityEngine;

public class EnemyStatHandler : UnitStatHandler<EnemyStat>
{
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void UpdateStat()
    {
        base.UpdateStat();
        // 여기에 추가적인 EnemyStat 초기화 로직이 필요하면 추가합니다.
    }
}