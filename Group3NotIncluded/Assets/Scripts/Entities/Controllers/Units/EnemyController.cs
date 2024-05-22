using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : Controller
{
    private EnemySpawnController enemySpawnController;

    private EnemyManager enemyManager;

    protected EnemyStatHandler stats { get; private set; }
    protected Transform ClosestTarget { get; private set; }

    private float angryTime = 0;        // �г� üũ�� �ð�
    private float angryLimit = 20;      // �г���� �ɸ��� �ð�
    private bool angry = false;         // �г� �ߴ���
    private float angrySpeed = 1.4f;      // �г� ������ �پ��� ���� �ӵ�
    private Animator _animator;         // �г� �ִϸ��̼� ������



    // ���� ��������� üũ��
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

        // �ִϸ��̼� �������� �ʿ������
        //Invoke("OnEnemyColor", 0.2f);               // �����ǰ� 0.2�� �� ���� ���� �ø���
    }

    protected override void Update()
    {
        base.Update(); // �θ� Ŭ������ Update �޼��� ȣ��

        // ���� ����� �÷��̾� ã��
        SetClosestTarget();

        AngryEnemy();


        // ��������� üũ
        if (LateObjectCheckTime >= 1) return;        //  �������� 1�� �����ٸ� ����
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
        // ����
        if (timeSinceLastAttack > stats.currentStat.attackSO.delay)
        {
            timeSinceLastAttack = 0;
            CallAttackEvent(stats.currentStat.attackSO);
        }
    }

    public void SetClosestTarget()
    {
        Transform target1 = enemyManager.CallPlayerPos(0);
        Transform target2 = enemyManager.CallPlayerPos(1);

        if (target1 == null)
        {
            ClosestTarget =  target2;
            return;
        }
        else if (target2 == null)
        {
            ClosestTarget = target1;
            return;
        }

        float distanceToTarget1 = Vector3.Distance(transform.position, target1.position);
        float distanceToTarget2 = Vector3.Distance(transform.position, target2.position);

        if (distanceToTarget1 < distanceToTarget2)
        {
            ClosestTarget = target1;
        }
        else
        {
            ClosestTarget = target2;
        }

        //Transform player1Pos = enemyManager.CallPlayerPos(0);

        //if (enemyManager.CallPlayerPos(1) == null)
        //{
        //    ClosestTarget = player1Pos;
        //    return;
        //}

        //Transform player2Pos = enemyManager.CallPlayerPos(1);

        //float? distanceToPlayer1 = Vector2.Distance(transform.position, player1Pos.position);
        //float? distanceToPlayer2 = Vector2.Distance(transform.position, player2Pos.position);

        //ClosestTarget = distanceToPlayer1 < distanceToPlayer2 ? player1Pos : player2Pos;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LateObjectCheckTime >= 1) return; //�������� 1�� �����ٸ� ����

        if (collision.CompareTag("BE")
            || collision.CompareTag("MSE")
            || collision.CompareTag("GSE"))  // ���� ���ƴ��� üũ
        {
            if (gameObject.tag == "MSE")
            {
                Destroy(gameObject);
                enemySpawnController.SpawnMultipleShotEnemy();
                return;
            }
            else if (gameObject.tag == "GSE")
            {
                Destroy(gameObject);
                enemySpawnController.SpawnGuidedShotEnemy();
                return;
            }
            else
            {
                Destroy(gameObject);
                enemySpawnController.SpawnEnemy();
                return;
            }

        }
    }
}
