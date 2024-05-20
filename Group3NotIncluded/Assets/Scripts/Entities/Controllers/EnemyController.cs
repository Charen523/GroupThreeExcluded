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

    private float angryTime = 0;
    private bool angry = false;
    private float angrySpeed = 1f;

    // 새로 생성됬는지 체크용
    private float LateObjectCheckTime;
    private SpriteRenderer _renderer;


    protected void Awake()
    {   
        stats = GetComponent<EnemyStatHandler>();
        _renderer = GetComponentInChildren<SpriteRenderer>();
    }
    // Start is called before the first frame update
    protected virtual void Start()
    {
        enemyManager = Managers.Instance.enemyManager;
        Invoke("OnEnemyColor", 0.1f);
    }

    protected override void Update()
    {
        base.Update(); // 부모 클래스의 Update 메서드 호출

        // 가장 가까운 플레이어 찾기
        SetClosestTarget();

        AngryEnemy();


        // 생성됬는지 체크
        if (LateObjectCheckTime >= 1) return;        //  생성된지 1초 지났다면 무시
        LateObjectCheckTime += Time.deltaTime;
    }




    protected virtual void FixedUpdate()
    {
        Vector2 directionToTarget = DirectionToTarget();

        TryShootAtTarget(directionToTarget);
    }

    protected Vector2 DirectionToTarget()
    {
        if (ClosestTarget == null)
        {
            return Vector2.zero;
        }
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

    public void SetClosestTarget()
    {
        Transform player1Pos = enemyManager.CallPlayerPos(0);

        if (enemyManager.CallPlayerPos(1) == null)
        {
            ClosestTarget = player1Pos;
            return;
        }

        Transform player2Pos = enemyManager.CallPlayerPos(1);
        
        float distanceToPlayer1 = Vector2.Distance(transform.position, player1Pos.position);
        float distanceToPlayer2 = Vector2.Distance(transform.position, player2Pos.position);

        ClosestTarget = distanceToPlayer1 < distanceToPlayer2 ? player1Pos : player2Pos;
    }

    public void AngryEnemy()
    {
        angryTime += Time.deltaTime;

        if (angry) return;

        if (angryTime >= 10)
        {
            angry = true;
            stats.currentStat.attackSO.delay -= angrySpeed;
        }
    }

    private void OnEnemyColor()
    {
        _renderer.color =
            new Color(_renderer.color.r, _renderer.color.g, _renderer.color.b, 1f);
            // 색깔 투명도 올리기
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LateObjectCheckTime >= 1) return;        //  생성된지 1초 지났다면 무시

        if (collision.CompareTag("Enemy1"))
        {
            Debug.Log("재생성1");                   // 재생성 디버그

            Destroy(gameObject);
            Managers.Instance.enemyManager.enemySpawnController.SpawnEnemy();
            return;
        }

        //else if (collision.CompareTag("Enemy2"))
        //{
        //    Debug.Log("재생성2");                  

        //    Destroy(gameObject);
        //Managers.Instance.enemyManager.enemySpawnController.SpawnMultipleShotEnemy();
        //    return;
        //}

        else
        {
            Debug.Log("재생성3");              

            Destroy(gameObject);
            Managers.Instance.enemyManager.enemySpawnController.SpawnGuidedShotEnemy();
            return;
        }
    }
}
