using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    float spawnPointX;
    float spawnPointY;
    float rotationZ;
    int spawnWall;

    [SerializeField] [Range(1, 10)] private int StartEnemyCount;

    [SerializeField] private GameObject basicEnemy;

    // 적 생성 시간
    private float time;
    [SerializeField] private float spawnTime = 3;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < StartEnemyCount; i++)
        {
            SpawnEnemy();
        }
    }

    private void Update()
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
        SetSpawnPoint();
        Instantiate(basicEnemy, new Vector3( spawnPointX, spawnPointY, 0), Quaternion.Euler(0, 0, rotationZ) ,transform);
    }

    public float CallSpawnPointX()
    {
        return spawnPointX;
    }

    public float CallSpawnPointY()
    {
        return spawnPointY;
    }

    public float CallRotationZ()
    {
        return rotationZ;
    }

    public void SetSpawnPoint()
    {
        spawnWall = Random.Range(0, 6);

        // 0~1 = 바닥, 2~3 = 천장, 4 = 왼쪽 벽, 5 = 오른쪽 벽
        switch ((SpawnWall)spawnWall)
        {
            case SpawnWall.Floor:
                spawnPointX = Random.Range(-8f, 8f);
                spawnPointY = -3.5f;
                //spawnPointY = -4.855f;
                rotationZ = 0;
                break;
            case SpawnWall.FloorAdd:
                spawnPointX = Random.Range(-8f, 8f);
                spawnPointY = -3.5f;
                //spawnPointY = -4.855f;
                rotationZ = 0;
                break;
            case SpawnWall.Ceiling:
                spawnPointX = Random.Range(-8f, 8f);
                spawnPointY = 3.2f;
                //spawnPointY = -4.855f;
                rotationZ = 180;
                break;
            case SpawnWall.CeilingAdd:
                spawnPointX = Random.Range(-8f, 8f);
                spawnPointY = 3.2f;
                //spawnPointY = -4.855f;
                rotationZ = 180;
                break;
            case SpawnWall.LeftWall:
                spawnPointX = -8.75f;
                spawnPointY = Random.Range(-3.3f, 3f);
                //spawnPointY = Random.Range(-4f, 4f);
                rotationZ = 270;
                break;
            case SpawnWall.RightWall:
                spawnPointX = 8.75f;
                spawnPointY = Random.Range(-3.3f, 3f);
                //spawnPointY = Random.Range(-4f, 4f);
                rotationZ = 90;
                break;
        }
    }
}
