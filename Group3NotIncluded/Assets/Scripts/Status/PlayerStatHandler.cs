using System;
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
        currentStat.maxBoostGage = baseStats.maxBoostGage;
    }

    public float GetSpeed()
    {
        return currentStat.speed;
    }

    public void GetMultiShot()
    {
        currentStat.attackSO.numberOfProjectilesPerShot = 3;
        Invoke("OriginShot", 5f);
    }

    private void OriginShot()
    {
        currentStat.attackSO.numberOfProjectilesPerShot = 1;
    }
}