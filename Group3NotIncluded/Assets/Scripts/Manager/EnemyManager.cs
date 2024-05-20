using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{


    public ObjectPool ObjectPool { get; private set; }  // 오브젝트 풀

    // 플레이어 위치
    [SerializeField] private Transform[] playerPos = new Transform[2];

    // 플레이어1 체력바 배열
    public GameObject[] player1HP = new GameObject[3];

    // 에너미 스폰 컨트롤러 적용
    public EnemySpawnController enemySpawnController;

    private void Awake()
    {
        // 에너미 매니저 셋팅
        SetEnemyManager();

        ObjectPool = FindAnyObjectByType<ObjectPool>();

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

        //에너미 스폰 컨트롤러 가져오기
        enemySpawnController = GetComponent<EnemySpawnController>();

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enemySpawnController.currentTime() >= 10)
        {
            enemySpawnController.CheckMultiEnemuFlag();
        }
        
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

    public void SetEnemyManager()
    {
        this.gameObject.transform.parent = Managers.Instance.transform;
        Managers.Instance.enemyManager = this;
    }
    
    public void ClearEnemyManager()
    {
        Managers.Instance.enemyManager = null;
        Destroy(this.gameObject);
    }
}
