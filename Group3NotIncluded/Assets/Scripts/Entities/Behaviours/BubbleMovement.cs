using System;
using UnityEngine;

public class BubbleMovement : MonoBehaviour
{
    private BubbleController bubbleController;

    private Transform closestPlayer;
    private Rigidbody2D rb;
    private Vector2 targetDirection;

    /*��������� ���*/
    private float speed = 1.5f;
    private float wobbleIntensity = 0.7f;
    private float wobbleSpeed = 5f;

    private void Start()
    {
        bubbleController = FindObjectOfType<BubbleController>(); 

        // Rigidbody2D ������Ʈ ��������
        rb = GetComponent<Rigidbody2D>();

        FindClosestPlayer();

        if (closestPlayer != null)
        {
            // Player�� ���� ���� ���
            targetDirection = (closestPlayer.position - transform.position).normalized;
        }
    }

    private void Update()
    {
        // ��Ʋ�Ÿ� �߰�
        float wobbleAngle = Mathf.Sin(Time.time * wobbleSpeed) * wobbleIntensity;
        Vector2 wobbleOffset = new Vector2(Mathf.Cos(wobbleAngle), Mathf.Sin(wobbleAngle)) * wobbleIntensity;

        // ���� ���� ����
        Vector2 finalDirection = (targetDirection + wobbleOffset).normalized;

        // Rigidbody2D�� ����Ͽ� �̵�
        rb.velocity = finalDirection * speed;
    }

    private void FindClosestPlayer()
    {
        // �±װ� "Player"�� ��� ���� ������Ʈ ã��
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        //�÷��̾ �ϳ��϶�.
        if (players.Length == 1)
        {
            closestPlayer = players[0].transform;
            return; //�Ʒ� ����.
        }

        //�÷��̾ ���϶�.
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
                bubbleController.InvokeItem0();
                break;
            case "Icon1":
                bubbleController.InvokeItem1();
                break;
            case "Icon2":
                bubbleController.InvokeItem2();
                break;
            case "Icon3":
                bubbleController.InvokeItem3();
                break;
            case "Icon4":
                bubbleController.InvokeItem4();
                break;
            default:
                break;
        }

    }
}
