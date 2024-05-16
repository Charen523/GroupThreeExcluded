using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;

    [SerializeField] private GameObject basicEnemy;

    // 적 생성 시간
    private float time;
    [SerializeField] private float spawnTime = 3;

    // 플레이어 위치
    [SerializeField] private Transform player1Pos;

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

        Time.timeScale = 1.0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= spawnTime)
        {
            SpawnEnemy();
            time = 0;
        }
        
    }

    private void SpawnEnemy()
    {
        Instantiate(basicEnemy, transform);
    }

    public Transform CallPlayer1Pos()
    {
        return player1Pos;
    }
}
