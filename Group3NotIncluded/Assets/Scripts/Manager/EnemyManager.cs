using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;

    public ObjectPool ObjectPool { get; private set; }  // 오브젝트 풀

    // 플레이어 위치
    [SerializeField] private Transform[] playerPos = new Transform[2];

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
}
