using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform projectileSpawnPosition;
    private Vector2 aimDirection = Vector2.right;

    private Controller controller;

    //TODO : 오브젝트 풀 이용
    public GameObject testBulletPrefab;

    private void Awake()
    {
        controller = GetComponent<Controller>();
    }

    private void Start()
    {
        controller.OnAttackEvent += OnShoot;
    }

    private void OnShoot(AttackSO attackSO)
    {
        if (attackSO == null)
        {
            return;
        }

        float projectilesAngleSpace = attackSO.multipleProjectilesAngle;
        int numberOfProjectilesPerShot = attackSO.numberOfProjectilesPerShot;

        float minAngle = -(numberOfProjectilesPerShot / 2f) * projectilesAngleSpace + 0.5f * attackSO.multipleProjectilesAngle;

        for (int i = 0; i < numberOfProjectilesPerShot; i++)
        {
            float angle = minAngle + projectilesAngleSpace * i;
            float randomSpread = Random.Range(-attackSO.spread, attackSO.spread);
            angle += randomSpread;
            CreateProjectile(attackSO, angle);
        }
    }

    private void CreateProjectile(AttackSO attackSO, float angle)
    {
        GameObject bullet = testBulletPrefab;

        bullet.transform.position = projectileSpawnPosition.position;
        ProjectileController projectileController = bullet.GetComponent<ProjectileController>();
    }

    private void OnAim(Vector2 newAimDirection)
    {
        // 총알 발사 방향 설정
        aimDirection = newAimDirection;
    }




}