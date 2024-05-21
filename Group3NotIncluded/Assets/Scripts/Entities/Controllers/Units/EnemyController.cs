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

    private float angryTime = 0;        // 분노 체크용 시간
    private float angryLimit = 20;      // 분노까지 걸리는 시간
    private bool angry = false;         // 분노 했는지
    private float angrySpeed = 1.4f;      // 분노 했을때 줄어드는 공격 속도
    private Animator _animator;         // 분노 애니메이션 설정용



    // 새로 생성됬는지 체크용
    private float LateObjectCheckTime;
    private SpriteRenderer _renderer;


    protected void Awake()
    {   
        stats = GetComponent<EnemyStatHandler>();
        _renderer = GetComponentInChildren<SpriteRenderer>();
        enemySpawnController = Managers.Instance.enemyManager.enemySpawnController;
        _animator = GetComponentInChildren<Animator>();
    }
    // Start is called before the first frame update
    protected virtual void Start()
    {
        enemyManager = Managers.Instance.enemyManager;

        // 애니메이션 도입으로 필요없어짐
        //Invoke("OnEnemyColor", 0.2f);               // 생성되고 0.2초 뒤 색깔 투명도 올리기
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
        
        float? distanceToPlayer1 = Vector2.Distance(transform.position, player1Pos.position);
        float? distanceToPlayer2 = Vector2.Distance(transform.position, player2Pos.position);

        ClosestTarget = distanceToPlayer1 < distanceToPlayer2 ? player1Pos : player2Pos;
    }

    public void AngryEnemy()
    {
        angryTime += Time.deltaTime;

        if (angry) return;

        if (angryTime >= angryLimit)
        {
            angry = true;
            _animator.SetBool("isAngry", true);
            stats.currentStat.attackSO.delay -= angrySpeed;
        }
    }

    // 애니메이션 도입으로 필요없어짐
    private void OnEnemyColor()
    {
        _renderer.color =
            new Color(_renderer.color.r, _renderer.color.g, _renderer.color.b, 1f);
            // 색깔 투명도 올리기
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LateObjectCheckTime >= 1) return;        //  생성된지 1초 지났다면 무시

        if (collision.CompareTag("BE")
            || collision.CompareTag("MSE")
            || collision.CompareTag("GSE"))  // 적과 겹쳤는지 체크
        {
            if (gameObject.tag == "MSE")
            {
                Debug.Log("재생성2");

                Destroy(gameObject);
                enemySpawnController.SpawnMultipleShotEnemy();
                return;
            }
            else if (gameObject.tag == "GSE")
            {
                Debug.Log("재생성3");

                Destroy(gameObject);
                enemySpawnController.SpawnGuidedShotEnemy();
                return;
            }
            else
            {
                Debug.Log("재생성1");                   // 재생성 디버그

                Destroy(gameObject);
                enemySpawnController.SpawnEnemy();
                return;
            }

        }
    }
}
