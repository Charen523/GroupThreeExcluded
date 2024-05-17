using UnityEngine;

public class PlayerStatHandler : UnitStatHandler<PlayerStat>
{
    protected override void Awake()
    {
        UpdateStat();
    }

    protected override void UpdateStat()
    {
        base.UpdateStat();

        currentStat.statsChangeType = baseStats.statsChangeType;
        currentStat.speed = baseStats.speed;
        currentStat.boostGage = baseStats.boostGage;
    }
}