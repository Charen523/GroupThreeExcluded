using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private EnemySpawnController enemySpawnController;
    
    private float positionX;
    private float positionY;
    private float rotationZ;

    private void Awake()
    {   
        // 적 생성 위치 정해주기
        enemySpawnController = GetComponent<EnemySpawnController>();

        positionX = enemySpawnController.CallSpawnPointX();
        positionY = enemySpawnController.CallSpawnPointY();
        rotationZ = enemySpawnController.CallRotationZ();

        transform.position = new Vector3(positionX, positionY, 0);
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(positionX + " " + positionY + " " + rotationZ);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
