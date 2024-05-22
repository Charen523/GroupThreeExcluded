using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BubbleMovement : MonoBehaviour
{
    private BubbleController bubbleController;

    private Transform closestPlayer;
    private Rigidbody2D rb;
    private Vector2 targetDirection;

    /*버블움직임 상수*/
    private float speed = 1.5f;
    private float wobbleIntensity = 0.7f;
    private float wobbleSpeed = 5f;

    // 플레이어 객체 저장용
    private GameObject player;

    private void Start()
    {
        bubbleController = FindObjectOfType<BubbleController>();
        

        // Rigidbody2D 컴포넌트 가져오기
        rb = GetComponent<Rigidbody2D>();

        FindClosestPlayer();

        if (closestPlayer != null)
        {
            // Player를 향한 방향 계산
            targetDirection = (closestPlayer.position - transform.position).normalized;
        }
    }

    private void Update()
    {
        // 비틀거림 추가
        float wobbleAngle = Mathf.Sin(Time.time * wobbleSpeed) * wobbleIntensity;
        Vector2 wobbleOffset = new Vector2(Mathf.Cos(wobbleAngle), Mathf.Sin(wobbleAngle)) * wobbleIntensity;

        // 최종 방향 설정
        Vector2 finalDirection = (targetDirection + wobbleOffset).normalized;

        // Rigidbody2D를 사용하여 이동
        rb.velocity = finalDirection * speed;
    }

    private void FindClosestPlayer()
    {
        // players 참조로 받아오기.
        GameObject[] players = bubbleController.players;

        //플레이어가 하나일때.
        //if (players.Length == 1)
        //{
        //    closestPlayer = players[0].transform;
        //    return; //아래 생략.
        //}

        if (players[0] == null && players[1] == null)
        {
            return;
        }
        else if (players[1] == null)
        {
            closestPlayer = players[0].transform;
            return;
        }
        else if (players[0] == null)
        {
            closestPlayer = players[1].transform;
            return;
        }

        //플레이어가 둘일때.
        float distance1 = Vector2.Distance(transform.position, players[0].transform.position);
        float distance2 = Vector2.Distance(transform.position, players[1].transform.position);

        int playerNum = distance1 > distance2? 1 : 0;

        if (playerNum == 0)
            closestPlayer = players[0].transform;
        else
            closestPlayer = players[1].transform;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string eventName = "";

        if (collision.CompareTag("Player"))
        {
            player = collision.gameObject; // 플레이어 오브젝트 가져오기
            eventName = gameObject.GetComponentInChildren<SpriteRenderer>().sprite.name;
            Destroy(gameObject);
        }
        else if (collision.gameObject.layer == 6 || collision.gameObject.layer == 7)
        {
            Destroy(gameObject);
            return;
        }

        switch(eventName)
        {
            case "Icon0":
                player.GetComponent<Animator>().SetTrigger("NoBullet");
                GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
                foreach (GameObject bullet in bullets)
                {
                    bullet.SetActive(false);
                }
                    AudioManager.Instance.PlaySFX(11);
                break;
            case "Icon1":
                player.GetComponent<PlayerHealthSystem>().EnableHP();
                AudioManager.Instance.PlaySFX(8);
                break;
            case "Icon2":
                player.GetComponent<PlayerHealthSystem>().OnInvincibleEvent();
                AudioManager.Instance.PlaySFX(10);
                break;
            case "Icon3":
                player.GetComponent<BoostSystem>().OnBoostFullEvent();
                AudioManager.Instance.PlaySFX(7);
                break;
            case "Icon4":
                player.GetComponent<PlayerStatHandler>().GetMultiShot();
                AudioManager.Instance.PlaySFX(9);
                break;
            default:
                break;
        }

    }
}
