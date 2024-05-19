using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;

    public ObjectPool ObjectPool { get; private set; }  // ������Ʈ Ǯ

    // �÷��̾� ��ġ
    [SerializeField] private Transform[] playerPos = new Transform[2];

    // �÷��̾�1 ü�¹� �迭
    public GameObject[] player1HP = new GameObject[3];

    // �� �ı� ����
    private int score = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        ObjectPool = GetComponent<ObjectPool>();

        // �÷��̾� ��ġ ���
        int playerCount = GameObject.FindGameObjectsWithTag("Player").Length;
        playerPos[0] = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        if (playerCount >= 2)
        {
            playerPos[1] = GameObject.FindGameObjectsWithTag("Player")[1].transform;
        }

        // �÷��̾�1 HP ����
        player1HP = GameObject.FindGameObjectsWithTag("Player1HP");
        // �÷��̾�1 HP ���� (�����ʺ��� 0)
        SetPlayer1HP(player1HP);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    // �÷��̾� ��ġ ��ȯ
    public Transform CallPlayerPos(int num = 0)
    {
        return playerPos[num];
    }

    public void SetPlayer1HP(GameObject[] HP)
    {
        //���� ������Ʈ�� �����ʿ� �ִ� �� ���� ����
        for (int i = 0; i < HP.Length; i++)
        {
            for (int j = i + 1; j < HP.Length; j++)
            {
                if (HP[i].transform.position.x < HP[j].transform.position.x)
                {
                    GameObject temp = HP[i];
                    HP[i] = HP[j];
                    HP[j] = temp;
                }
            }
        }
    }


    // ���� �߰�
    public void AddScore(int score)
    {
        this.score += score;
    }


    // ���� ���� ��ȯ
    public int CallCurrentScore()
    {
        return score;
    }
}
