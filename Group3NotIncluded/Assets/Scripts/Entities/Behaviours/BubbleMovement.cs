using UnityEngine;

public class BubbleMovement : MonoBehaviour
{
    public float speed = 1.5f;
    public float wobbleIntensity = 0.7f;
    public float wobbleSpeed = 5f;

    private Transform closestPlayer;
    private Rigidbody2D rb;
    private Vector2 targetDirection;

    private void Start()
    {
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
}
