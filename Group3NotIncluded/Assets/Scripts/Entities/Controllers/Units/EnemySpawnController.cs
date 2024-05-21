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
    [SerializeField] private GameObject multipleShotEnemy;
    [SerializeField] private GameObject guidedShotEnemy;

    // 난이도 보정
    private int multiEnemyCount = 0;     // 몇번째 스폰인지 카운트
    private int guidedEnemyCount = 0;    // 몇번째 스폰인지 카운트
    [SerializeField] private int HowOftenMultiEnemy = 5;  // 몇번째 스폰 타이밍마다 생성할 것인지
    [SerializeField] private int HowOftenGuidedEnemy = 10;  // 몇번째 스폰 타이밍마다 생성할 것인지
    
    // 적 생성 시간
    private float time;
    [SerializeField] private float spawnTime = 3;


    // 기본 적 생성 시간 : 2초, 멀티샷 적 5번째마다 생성, 유도샷 적 10번째마다 생성
    //멀티샷 적 생성할 때마다 1번 감소 생성, 유도샷 적은 2번 감소
    // 5 -> 4 -> 3 -> 2 -> 1,  10 -> 8 -> 6 -> 4 -> 2
    // 최소 1, 2까지만 감소

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

            CheckCreateMultiEnemy();
            CheckCreateGuidedEnemy();
        }


    }

    public void SpawnEnemy()
    {
        SetSpawnPoint();
        Instantiate(basicEnemy, new Vector3( spawnPointX, spawnPointY, 0), Quaternion.Euler(0, 0, rotationZ) ,transform);
    }

   public void SpawnMultipleShotEnemy()
    {
        SetSpawnPoint();
        Instantiate(multipleShotEnemy, new Vector3(spawnPointX, spawnPointY, 0), Quaternion.Euler(0, 0, rotationZ), transform);
    }

    public void SpawnGuidedShotEnemy()
    {
        SetSpawnPoint();
        Instantiate(guidedShotEnemy, new Vector3(spawnPointX, spawnPointY, 0), Quaternion.Euler(0, 0, rotationZ), transform);
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
                //spawnPointY = -3.5533f;  // -3.5f
                spawnPointY = -3.52f;
                rotationZ = 0;
                break;
            case SpawnWall.FloorAdd:
                spawnPointX = Random.Range(-8f, 8f);
                spawnPointY = -3.52f;
                rotationZ = 0;
                break;
            case SpawnWall.Ceiling:
                spawnPointX = Random.Range(-8f, 8f);
                spawnPointY = 3.22f; // 3.2534
                rotationZ = 180;
                break;
            case SpawnWall.CeilingAdd:
                spawnPointX = Random.Range(-8f, 8f);
                spawnPointY = 3.22f;
                rotationZ = 180;
                break;
            case SpawnWall.LeftWall:
                spawnPointX = -8.75f;    // -8.79f
                spawnPointY = Random.Range(-3.3f, 3f);
                rotationZ = 270;
                break;
            case SpawnWall.RightWall:
                spawnPointX = 8.75f;     // 8.75f
                spawnPointY = Random.Range(-3.3f, 3f);
                rotationZ = 90;
                break;
        }
    }
    

    private void CheckCreateMultiEnemy()
    {
        if (multiEnemyCount >= HowOftenMultiEnemy)
        {
            SpawnMultipleShotEnemy();

            multiEnemyCount = 0;

            HowOftenMultiEnemy = Mathf.Max(1, HowOftenMultiEnemy--);  // 얼마나 자주 생성할지 1 감소
        }

        multiEnemyCount++;
    }

    private void CheckCreateGuidedEnemy()
    {
        if (guidedEnemyCount >= HowOftenGuidedEnemy)
        {
            SpawnGuidedShotEnemy();

            guidedEnemyCount = 0;

            HowOftenGuidedEnemy = Mathf.Max(2, HowOftenGuidedEnemy - 2);  // 얼마나 자주 생성할지 1 감소
        }

        guidedEnemyCount++;
    }
}
