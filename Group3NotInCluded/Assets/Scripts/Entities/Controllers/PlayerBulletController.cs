using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�����ϸ� ProjectileController�� ��ġ�ų� ��ӹޱ�!
//�켱 conflict ���������� �ϳ� ����.
public class PlayerBulletController : MonoBehaviour
{
    [SerializeField] private LayerMask levelCollisionLayer;

    private AttackSO attackData;
    //private float bulletDurationTime; //�Ѿ��� �� �� ���� �ð�
    //private float nextBulletTime; //�Ѿ� ��
    private Vector2 direction; //���ư��� ����
    private bool isReady; //���� �߻�?

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    //private TrailRenderer trailRenderer; //�Ƹ� �Ѿ� �˵��� ������ UI?

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        //nextBulletTime = playerStatHandler.currentStat.bulletFrequency;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isReady)
        {
            return;
        }

        //��ġ ���� �Ǽ�. ���� �Ѿ��� �߻��ϰ� �ϴ� �������� �̻簡�� ��.
        //bulletDurationTime += Time.deltaTime;
        //if (bulletDurationTime > nextBulletTime)
        //{
        //    bulletDurationTime = 0;
        //}

        rb.velocity = direction * attackData.speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // levelCollisionLayer�� ���ԵǴ� ���̾����� Ȯ���մϴ�.
        if (IsLayerMatched(levelCollisionLayer.value, collision.gameObject.layer))
        {
            // �������� �浹�� �������κ��� �ణ �� �ʿ��� �߻�ü�� �ı��մϴ�.
            Vector2 destroyPosition = collision.ClosestPoint(transform.position) - direction * 0.2f;
            DestroyProjectile(destroyPosition);
        }
        // _attackData.target�� ���ԵǴ� ���̾����� Ȯ���մϴ�.
        else if (IsLayerMatched(attackData.target.value, collision.gameObject.layer))
        {
            // �ƾ�! �ǰ� �������� �߰� ����
            // �浹�� �������� �߻�ü�� �ı��մϴ�.
            DestroyProjectile(collision.ClosestPoint(transform.position));
        }
    }

    // ���̾ ��ġ�ϴ��� Ȯ���ϴ� �޼ҵ��Դϴ�.
    private bool IsLayerMatched(int layerMask, int objectLayer)
    {
        return layerMask == (layerMask | (1 << objectLayer));
    }

    public void InitializeAttack(Vector2 direction, AttackSO attackData)
    {
        this.attackData = attackData;
        this.direction = direction;

        UpdateProjectileSprite();
        currentDuration = 0;
        spriteRenderer.color = attackData.projectileColor;

        transform.right = this.direction;

        isReady = true;
    }

    private void UpdateProjectileSprite()
    {
        transform.localScale = Vector3.one * attackData.size;
    }

    private void DestroyProjectile(Vector3 position)
    {
        gameObject.SetActive(false);
    }
}
