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
    //public TextMeshProUGUI timer;
    //public TextMeshProUGUI gameScore;
    //public GameObject[] playerHpUI; 
    //public int playerHpCount;

    //[Header("PanelList")]
    //public GameObject menuPanel;
    //public GameObject endPanel;

    //[Header("EndPanel")] //EndPanel에 들어갈 정보
    //public TextMeshProUGUI totalScore;
    //public TextMeshProUGUI endTime;

    //totalScore과 gameScore을 분리?

    private int score;
    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        // 플레이어 생성 구현

        //플레이어 Hp 구현
        CreateHpUI();
    }


    // Update is called once per frame
    void Update()
    {
        // 현재 시간 UI에 표시
        currentTime += Time.deltaTime;
        //timer.text = currentTime.ToString("N2");

        // 몬스터 생성 구현(Invoke 또는 Couroutine 사용하여 시간차 두기)

        // 특정 조건 달성(플레이어 체력 0)시 게임 종료
        //if (playerHpCount <= 0)
        //{
        //    EndGame();
        //}
    }

    // 프리펩화 한 Hp UI를 playerHpCount수 만큼 생성
    // 특정 좌표에 프리펩 생성, n만큼 x좌표 이동
    private void CreateHpUI()
    {
        Vector3 position = new Vector3(10f, 0f, 0f); //좌표 수정 필요!
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


    // 게임 종료 및 EndPanel 열기
    //Evenet로 EndPanel쪽에 신호 보내면 좋을듯?
    public void EndGame()
    {
        Time.timeScale = 0f;
        //게임종료 이벤트.
        //endTime.text = timer.text;
        //totalScore.text = gameScore.text;
        //endPanel.SetActive(true);
    }
}
