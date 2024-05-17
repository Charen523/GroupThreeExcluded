using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//가능하면 ProjectileController과 합치거나 상속받기!
//우선 conflict 방지용으로 하나 만듦.
public class PlayerBulletController : MonoBehaviour
{
    [SerializeField] private LayerMask levelCollisionLayer;

    private AttackSO attackData;
    //private float bulletDurationTime; //총알을 쏜 후 지난 시간
    //private float nextBulletTime; //총알 빈도
    private Vector2 direction; //날아가는 방향
    private bool isReady; //다음 발사?

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    //private TrailRenderer trailRenderer; //아마 총알 궤도를 보여줄 UI?

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

        //위치 선정 실수. 다음 총알을 발사하게 하는 로직으로 이사가야 함.
        //bulletDurationTime += Time.deltaTime;
        //if (bulletDurationTime > nextBulletTime)
        //{
        //    bulletDurationTime = 0;
        //}

        rb.velocity = direction * attackData.speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // levelCollisionLayer에 포함되는 레이어인지 확인합니다.
        if (IsLayerMatched(levelCollisionLayer.value, collision.gameObject.layer))
        {
            // 벽에서는 충돌한 지점으로부터 약간 앞 쪽에서 발사체를 파괴합니다.
            Vector2 destroyPosition = collision.ClosestPoint(transform.position) - direction * 0.2f;
            DestroyProjectile(destroyPosition);
        }
        // _attackData.target에 포함되는 레이어인지 확인합니다.
        else if (IsLayerMatched(attackData.target.value, collision.gameObject.layer))
        {
            // 아야! 피격 구현에서 추가 예정
            // 충돌한 지점에서 발사체를 파괴합니다.
            DestroyProjectile(collision.ClosestPoint(transform.position));
        }
    }

    // 레이어가 일치하는지 확인하는 메소드입니다.
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
