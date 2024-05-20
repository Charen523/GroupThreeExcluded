using System;
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
        Transform target = Managers.Instance.enemyManager.CallPlayerPos(0);

        SetDirection(target);

        _rigidbody.velocity = direction * attackData.speed;

    }

    private void SetDirection(Transform target)
    {

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