using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class RankingManager : MonoBehaviour
{
    // 현재는 Inspector에서 오브젝트(RankPanel의 SoloRank, CoopRank)를 수동으로 넣어주는 형식. 
    // SoloScene으로 이동하면 오브젝트가 소멸되는 문제가 있음. 
    // StartScene이 시작될때 자동으로 오브젝트를 넣어주도록 수정 필요

    public GameObject RankPanel;
    //배열로 바꾸거나 해서 랭킹 개수가 일정 이상 넘어가면 사라지게 할 필요있음. 모르면 튜터 찾아가셈.
    //private List<float> soloRankTime; // 시간 기록들 저장할 리스트
    //private List<int> soloRankScore; // 점수 기록들 저장할 리스트
    //private Dictionary<string, int> soloRankData = new Dictionary<string, int>(); //이름, 점수 저장하는 딕셔너리
    private Dictionary<string, List<int>> soloRankData = new Dictionary<string, List<int>>(); //이름, 점수 저장하는 딕셔너리
    public GameObject SoloRankBox;
    private List<TextMeshProUGUI> soloRankDataList; // 기록 출력하는 텍스트 프리펩 모아놓을 리스트

    //위와 마찬가지. 그리고 데이터 관리를 할 때 list가 아니라 dictionary로 해서 우리가 입력받을 이름과 점수데이터 연결 필요.
    //private List<float> coopRankTime; // 시간 기록들 저장할 리스트
    //private List<int> coopRankScore; // 점수 기록들 저장할 리스트
    private Dictionary<string, List<int>> coopRankData = new Dictionary<string, List<int>>(); //이름, 점수 저장하는 딕셔너리
    public GameObject CoopRankBox;
    private List<TextMeshProUGUI> coopRankDataList; // 기록 출력하는 텍스트 프리펩 모아놓을 리스트

    public TextMeshProUGUI RankData; // 기록 출력하는 텍스트 프리펩


 
    private void Start()
    {


        //soloRankTime = new List<float>();
        //soloRankScore = new List<int>();

        soloRankDataList = new List<TextMeshProUGUI>();

        //coopRankTime = new List<float>();
        //coopRankScore = new List<int>();
        coopRankDataList = new List<TextMeshProUGUI>();

        //출력 확인용
        //SetRankData("kim", 1);
        //SetRankData("park", 6);
        //SetRankData("lee", 2);
        //SetRankData("kim", 4);
        //SetRankData("kim", 5);
        //SetRankData("kang", 9);
        //SetRankData("lee", 7);
        //SetRankData("default", 6);

        //출력 확인용, 실제로는 RankPanel이 활성화 될 때 실행
        //PrintSoloRankList();
        //PrintCoopRankList();
    }



    // 이름, 점수 기록 저장 함수
    public void SetRankData(string playerName, int score)
    {
        if (soloRankData.ContainsKey(playerName))
        {
            // 이미 존재하는 키에 값을 추가
            soloRankData[playerName].Add(score);
        }
        else
        {
            // 새로운 키-값 쌍 추가
            soloRankData.Add(playerName, new List<int> { score });
        }

    }

    public void PrintSoloRankList()
    {
        RankPanel = GameObject.Find("Canvas").transform.Find("RankPanel").gameObject;
        SoloRankBox = RankPanel.transform.Find("SoloRank").transform.Find("Scroll View").transform.Find("Viewport").transform.Find("Content").gameObject;


        // 모든 점수와 플레이어 이름을 쌍으로 저장할 리스트 생성
        List<KeyValuePair<string, int>> allScores = new List<KeyValuePair<string, int>>();

        // 딕셔너리에서 모든 플레이어와 점수를 리스트에 추가
        foreach (var entry in soloRankData)
        {
            foreach (var score in entry.Value)
            {
                allScores.Add(new KeyValuePair<string, int>(entry.Key, score));
            }
        }

        // 점수를 내림차순으로 정렬
        var sortedScores = allScores.OrderByDescending(score => score.Value);


        // 정렬된 점수 출력
        int i = 0;
        foreach (var score in sortedScores)
        {
            if (soloRankDataList.Count > 7) break;

                Vector3 position = new Vector3(20, 250 - i * 100, 0);
                Quaternion rotation = Quaternion.Euler(0, 0, 0);
                RankData.text = "name: " + score.Key + "\n" + "score: " + score.Value.ToString();

                TextMeshProUGUI data = Instantiate(RankData, position, rotation);
                data.transform.SetParent(SoloRankBox.transform, false); //프리펩 위치를 SoloRank의 자식으로 이동
                soloRankDataList.Add(data);

                i++;
        }
    }

    public void PrintCoopRankList()
    {

        RankPanel = GameObject.Find("Canvas").transform.Find("RankPanel").gameObject;
        CoopRankBox = RankPanel.transform.Find("CoopRank").transform.Find("Scroll View").transform.Find("Viewport").transform.Find("Content").gameObject;

        // 모든 점수와 플레이어 이름을 쌍으로 저장할 리스트 생성
        List<KeyValuePair<string, int>> allScores = new List<KeyValuePair<string, int>>();

        // 딕셔너리에서 모든 플레이어와 점수를 리스트에 추가
        foreach (var entry in coopRankData)
        {
            foreach (var score in entry.Value)
            {
                allScores.Add(new KeyValuePair<string, int>(entry.Key, score));
            }
        }

        // 점수를 내림차순으로 정렬
        var sortedScores = allScores.OrderByDescending(score => score.Value);


        // 정렬된 점수 출력
        int i = 0;
        foreach (var score in sortedScores)
        {
            if (coopRankDataList.Count > 7) break;

            Vector3 position = new Vector3(20, 250 - i * 100, 0);
            Quaternion rotation = Quaternion.Euler(0, 0, 0);
            RankData.text = "name: " + score.Key + "\n" + "score: " + score.Value.ToString();

            TextMeshProUGUI data = Instantiate(RankData, position, rotation);
            data.transform.SetParent(SoloRankBox.transform, false); //프리펩 위치를 SoloRank의 자식으로 이동
            soloRankDataList.Add(data);

            i++;
        }
    }

    public void DestroyRankList()
    {
        //soloRank 
        soloRankDataList.Clear();
        Transform solo = RankPanel.transform.Find("SoloRank").transform.Find("Scroll View").transform.Find("Viewport").transform.Find("Content");
        // SoloRank의 자식 오브젝트들 찾기
        foreach (Transform child in solo)
        {
            // rankdata 태그가 붙은 자식 오브젝트를 찾아서 삭제
            if (child.CompareTag("rankdata"))
            {
                Destroy(child.gameObject);
            }
        }

        //coopRank
        coopRankDataList.Clear();
        Transform coop = RankPanel.transform.Find("CoopRank").transform.Find("Scroll View").transform.Find("Viewport").transform.Find("Content");
        // SoloRank의 자식 오브젝트들 찾기
        foreach (Transform child in coop)
        {
            // rankdata 태그가 붙은 자식 오브젝트를 찾아서 삭제
            if (child.CompareTag("rankdata"))
            {
                Destroy(child.gameObject);
            }
        }
    }
}
