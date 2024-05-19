using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;

    public ObjectPool ObjectPool { get; private set; }  // 오브젝트 풀

    // 플레이어 위치
    [SerializeField] private Transform[] playerPos = new Transform[2];

    // 플레이어1 체력바 배열
    public GameObject[] player1HP = new GameObject[3];

    // 적 파괴 점수
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

        // 플레이어 위치 담기
        int playerCount = GameObject.FindGameObjectsWithTag("Player").Length;
        playerPos[0] = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        if (playerCount >= 2)
        {
            playerPos[1] = GameObject.FindGameObjectsWithTag("Player")[1].transform;
        }

        // 플레이어1 HP 수집
        player1HP = GameObject.FindGameObjectsWithTag("Player1HP");
        // 플레이어1 HP 정렬 (오른쪽부터 0)
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

    // 플레이어 위치 반환
    public Transform CallPlayerPos(int num = 0)
    {
        return playerPos[num];
    }

    public void SetPlayer1HP(GameObject[] HP)
    {
        //게임 오브젝트를 오른쪽에 있는 것 부터 정렬
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


    // 점수 추가
    public void AddScore(int score)
    {
        this.score += score;
    }


    // 현재 점수 반환
    public int CallCurrentScore()
    {
        return score;
    }
}
