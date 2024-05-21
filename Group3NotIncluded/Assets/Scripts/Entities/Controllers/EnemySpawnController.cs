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

    // ���̵� ����
    private int multiEnemyCount = 0;     // ���° �������� ī��Ʈ
    private int guidedEnemyCount = 0;    // ���° �������� ī��Ʈ
    [SerializeField] private int HowOftenMultiEnemy = 5;  // ���° ���� Ÿ�ָ̹��� ������ ������
    [SerializeField] private int HowOftenGuidedEnemy = 10;  // ���° ���� Ÿ�ָ̹��� ������ ������
    
    // �� ���� �ð�
    private float time;
    [SerializeField] private float spawnTime = 3;


    // �⺻ �� ���� �ð� : 2��, ��Ƽ�� �� 5��°���� ����, ������ �� 10��°���� ����
    //��Ƽ�� �� ������ ������ 1�� ���� ����, ������ ���� 2�� ����
    // 5 -> 4 -> 3 -> 2 -> 1,  10 -> 8 -> 6 -> 4 -> 2
    // �ּ� 1, 2������ ����

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

        // 0~1 = �ٴ�, 2~3 = õ��, 4 = ���� ��, 5 = ������ ��
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

            HowOftenMultiEnemy = Mathf.Max(1, HowOftenMultiEnemy--);  // �󸶳� ���� �������� 1 ����
        }

        multiEnemyCount++;
    }

    private void CheckCreateGuidedEnemy()
    {
        if (guidedEnemyCount >= HowOftenGuidedEnemy)
        {
            SpawnGuidedShotEnemy();

            guidedEnemyCount = 0;

            HowOftenGuidedEnemy = Mathf.Max(2, HowOftenGuidedEnemy - 2);  // �󸶳� ���� �������� 1 ����
        }

        guidedEnemyCount++;
    }
}
