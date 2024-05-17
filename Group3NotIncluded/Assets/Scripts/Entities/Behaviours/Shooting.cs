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
        controller.OnLookEvent += OnAim;
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
        GameObject bullet = Instantiate(testBulletPrefab);

        bullet.transform.position = projectileSpawnPosition.position;
        ProjectileController projectileController = bullet.GetComponent<ProjectileController>();
        projectileController.InitializeAttack(RotateVector2(aimDirection, angle), attackSO);
    }

    private static Vector2 RotateVector2(Vector2 aimDirection, float angle)
    {
        // 벡터 회전하기 : 쿼터니언 * 벡터 순
        return Quaternion.Euler(0, 0, angle) * aimDirection;
    }

    private void OnAim(Vector2 newAimDirection)
    {
        Debug.Log("발사1");
        // 총알 발사 방향 설정
        aimDirection = newAimDirection;
    }




}