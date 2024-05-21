using System;
using System.Runtime.CompilerServices;
using System.Xml;
using UnityEngine;

public class GuidedBulletController : ProjectileController
{
    // 생성되었을 때 가장 가까운 플레이어를 쫓아가는 총알

    // 유도탄 회전 속도
    [SerializeField] private float RotationSpeed = 0.1f;

    public Transform front;
    public Transform back;

    protected override void Awake()
    {
        base.Awake();
        //SetTarget();
        front = GameObject.Find("FrontPosition").transform;
        back = GameObject.Find("BackPosition").transform;
    }

    protected override void Update()
    {
        if (!isReady)
        {
            return;
        }

        currentDuration += Time.deltaTime;

        if (currentDuration >= attackData.duration)
        {
            DestroyProjectile();
        }
        
        // TODO : 타겟을 가장 가까운 타겟으로 설정하는 메커니즘 필요
        Transform P1Pos = Managers.Instance.enemyManager.CallPlayerPos(0);
        Transform P2Pos = Managers.Instance.enemyManager.CallPlayerPos(1);

        Transform target = ClosestTarget(P1Pos, P2Pos);
        SetDirection(target);

        _rigidbody.velocity = direction * attackData.speed;

    }

    private Transform ClosestTarget(Transform target1 = null, Transform target2 = null)
    {
        // 오브젝트와 target1과 target2의 거리 중 짧은 것을 반환
        if (target1 == null && target2 == null)
        {
            return null;
        }
        else if (target1 == null)
        {
            return target2;
        }
        else if (target2 == null)
        {
            return target1;
        }

        float distanceToTarget1 = Vector3.Distance(transform.position, target1.position);
        float distanceToTarget2 = Vector3.Distance(transform.position, target2.position);

        if (distanceToTarget1 < distanceToTarget2)
        {
            return target1;
        }
        else
        {
            return target2;
        }
    }

    private void SetDirection(Transform target)
    {
        if (target == null)
        {
            return;
        }

        // 현재 위치에서 타겟 위치로 향하는 방향
        direction = (target.position - transform.position).normalized;


        // 타겟 위치로 향하는 방향으로 회전
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion from = transform.rotation;
        Quaternion to = Quaternion.Euler(0, 0, rotZ - 90);

        transform.localRotation = Quaternion.Slerp(from, to, Time.deltaTime * RotationSpeed);

        // 회전 속도로 결정된 방향으로 총알 방향 설정
        direction = (front.position - back.position).normalized;

    }

} 