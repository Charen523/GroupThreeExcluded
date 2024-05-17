using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    float spawnPointX;
    float spawnPointY;
    float rotationZ;
    int spawnWall;

    private void Awake()
    {
        spawnWall = Random.Range(0, 6);

        // 0~1 = 바닥, 2~3 = 천장, 4 = 왼쪽 벽, 5 = 오른쪽 벽
        switch ((SpawnWall)spawnWall)
        {
            case SpawnWall.Floor:
                spawnPointX = Random.Range(-8f, 8f);
                spawnPointY = -4.855f;
                rotationZ = 0;
                break;
            case SpawnWall.FloorAdd:
                spawnPointX = Random.Range(-8f, 8f);
                spawnPointY = -4.855f;
                rotationZ = 0;
                break;
            case SpawnWall.Ceiling:
                spawnPointX = Random.Range(-8f, 8f);
                spawnPointY = 4.855f;
                rotationZ = 180;
                break;
            case SpawnWall.CeilingAdd:
                spawnPointX = Random.Range(-8f, 8f);
                spawnPointY = 4.855f;
                rotationZ = 180;
                break;
            case SpawnWall.LeftWall:
                spawnPointX = -8.75f;
                spawnPointY = Random.Range(-4f, 4f);
                rotationZ = 270;
                break;
            case SpawnWall.RightWall:
                spawnPointX = 8.75f;
                spawnPointY = Random.Range(-4f, 4f);
                rotationZ = 90;
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
  
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
}
