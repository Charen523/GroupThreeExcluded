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
        // ���⿡ �߰����� EnemyStat �ʱ�ȭ ������ �ʿ��ϸ� �߰��մϴ�.
    }
}