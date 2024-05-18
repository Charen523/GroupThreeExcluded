using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //위치 UI스크립트 쪽으로 바꿔야 함.
    //[Header ("UI")]
    //public TextMeshProUGUI gameScore;
    //public GameObject[] playerHpUI; 
    //public int playerHpCount;

    //[Header("PanelList")]
    //public GameObject menuPanel;
    //public GameObject endPanel;

    //[Header("EndPanel")] //EndPanel에 들어갈 정보
    //public TextMeshProUGUI totalScore;
    //public TextMeshProUGUI endTime;

    //totalScore과 gameScore을 분리한 이유?

    private Managers managers;

    private bool isPaused;
    private int score;
    private float currentTime;

    private void Awake()
    {
        managers = GetComponent<Managers>();
    }

    // Start is called before the first frame update
    void Start()
    {
        managers.OnPause += GetPauseStatus;
        managers.OnGameOver += EndGame;

        Time.timeScale = 1f;
        currentTime = 0f;

        // 플레이어 생성 구현

        //플레이어 Hp 구현
        CreateHpUI();
    }


    // Update is called once per frame
    void Update()
    {
        //인게임 시간의 흐름 계산.
        currentTime += Time.deltaTime;
    }

    private void GetPauseStatus(bool pause)
    {
        isPaused = pause; //추후 필요없으면 삭제.

        if (isPaused)
        {
            Time.timeScale = 0f;
        }else
        {
            Time.timeScale = 1f;
        }
    }

    // 프리펩화 한 Hp UI를 playerHpCount수 만큼 생성
    // 특정 좌표에 프리펩 생성, n만큼 x좌표 이동
    private void CreateHpUI()
    {
        Vector3 position = new Vector3(10f, 0f, 0f); //좌표 수정 필요!
    }

    public float GetTime()
    {
        return currentTime;
    }

    // 적이 처치될 때 마다 호출
    // 점수 증가
    public void AddScore()
    {
        score++; // 점수 계산 방식에 따라 조정 필요
        //점수변화를 이벤트로 전송.
        //gameScore.text = score.ToString();
    }

    //HealthSystem과 연계하는 것으로 수정 필요.
    // 플레이어가 공격에 맞을 때 마다 호출
    // 플레이어 Hp UI 1개 소멸
    //public void DecreaseHp()
    //{
    //    Destroy(playerHpUI[playerHpCount - 1]);
    //    playerHpCount--;
    //}


    //게임종료 이벤트.
    public void EndGame()
    {
        Time.timeScale = 0f;
        //totalScore.text = gameScore.text;
        //endPanel.SetActive(true);
    }
}
