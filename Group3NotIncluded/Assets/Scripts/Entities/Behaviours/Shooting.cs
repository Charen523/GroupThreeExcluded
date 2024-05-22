using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform projectileSpawnPosition;
    private Vector2 aimDirection = Vector2.zero;

    private Controller controller;

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
        if (attackSO == null || aimDirection == Vector2.zero)
        {
            return;
        }

        // �Ѿ� �߻� ���� ȿ������ ����մϴ�.
        AudioManager.Instance.PlaySFX(6);

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
        GameObject bullet = Managers.Instance.enemyManager.ObjectPool.SpawnFromPool(attackSO.bulletNameTag);

        bullet.transform.position = projectileSpawnPosition.position;
        ProjectileController projectileController = bullet.GetComponent<ProjectileController>();
        projectileController.InitializeAttack(RotateVector2(aimDirection, angle), attackSO);
    }

    private static Vector2 RotateVector2(Vector2 aimDirection, float angle)
    {
        // ���� ȸ���ϱ� : ���ʹϾ� * ���� ��
        return Quaternion.Euler(0, 0, angle) * aimDirection;
    }

    private void OnAim(Vector2 newAimDirection)
    {
        // �Ѿ� �߻� ���� ����
        aimDirection = newAimDirection;
    }
}