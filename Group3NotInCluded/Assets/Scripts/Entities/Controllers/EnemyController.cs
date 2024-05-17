using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyController : Controller
{
    private EnemySpawnController enemySpawnController;

    private EnemyManager enemyManager;
    protected Transform ClosestTarget { get; private set; }

    private float positionX;
    private float positionY;
    private float rotationZ;


    protected override void Awake()
    {   
        base.Awake();
        // 적 생성 위치 정해주기
        enemySpawnController = GetComponent<EnemySpawnController>();

        positionX = enemySpawnController.CallSpawnPointX();
        positionY = enemySpawnController.CallSpawnPointY();
        rotationZ = enemySpawnController.CallRotationZ();

        transform.position = new Vector3(positionX, positionY, 0);
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
    }
    // Start is called before the first frame update
    protected virtual void Start()
    {
        enemyManager = EnemyManager.Instance;
        ClosestTarget = enemyManager.CallPlayer1Pos();
    }

    protected virtual void FixedUpdate()
    {
        Vector2 directionToTarget = DirectionToTarget();

        TryShootAtTarget(directionToTarget);
    }

    protected Vector2 DirectionToTarget()
    {
        return (ClosestTarget.position - transform.position).normalized;
    }

    private void TryShootAtTarget(Vector2 directionToTarget)
    {
        CallLookEvent(directionToTarget);
    }
}
