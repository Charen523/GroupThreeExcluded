using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyController : Controller
{
    private EnemySpawnController enemySpawnController;

    private EnemyManager enemyManager;

    protected EnemyStatHandler stats { get; private set; }
    protected Transform ClosestTarget { get; private set; }

    private float positionX;
    private float positionY;
    private float rotationZ;


    protected void Awake()
    {   
        // 적 생성 위치 정해주기
        enemySpawnController = GetComponent<EnemySpawnController>();
        stats = GetComponent<EnemyStatHandler>();

        positionX = enemySpawnController.CallSpawnPointX();
        positionY = enemySpawnController.CallSpawnPointY();
        rotationZ = enemySpawnController.CallRotationZ();

        transform.position = new Vector3(positionX, positionY, 0);
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
    }
    // Start is called before the first frame update
    protected virtual void Start()
    {
        enemyManager = Managers.Instance.enemyManager;
        ClosestTarget = enemyManager.CallPlayer1Pos();
    }

    protected override void Update()
    {
        base.Update(); // 부모 클래스의 Update 메서드 호출
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

    protected override void HandleAttackDelay()
    {
        if (timeSinceLastAttack <= stats.currentStat.attackSO.delay)
        {
            timeSinceLastAttack += Time.deltaTime;
        }
        // 공격
        if (timeSinceLastAttack > stats.currentStat.attackSO.delay)
        {
            timeSinceLastAttack = 0;
            CallAttackEvent(stats.currentStat.attackSO);
        }
    }
}
