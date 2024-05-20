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

    // ���� ��������� üũ��
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
            // ���� ���� �ø���
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LateObjectCheckTime >= 1) return;        //  �������� 1�� �����ٸ� ����

        if (collision.CompareTag("Enemy1"))
        {
            Debug.Log("�����1");                   // ����� �����

            Destroy(gameObject);
            Managers.Instance.enemyManager.enemySpawnController.SpawnEnemy();
            return;
        }

        //else if (collision.CompareTag("Enemy2"))
        //{
        //    Debug.Log("�����2");                  

        //    Destroy(gameObject);
        //Managers.Instance.enemyManager.enemySpawnController.SpawnMultipleShotEnemy();
        //    return;
        //}

        else
        {
            Debug.Log("�����3");              

            Destroy(gameObject);
            Managers.Instance.enemyManager.enemySpawnController.SpawnGuidedShotEnemy();
            return;
        }
    }
}
