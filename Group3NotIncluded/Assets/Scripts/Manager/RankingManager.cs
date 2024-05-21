using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class RankingManager : MonoBehaviour
{

    private GameObject RankPanel;
    private Dictionary<string, List<int>> soloRankData = new Dictionary<string, List<int>>(); //이름, 점수 저장하는 딕셔너리
    private GameObject SoloRankBox;
    private List<TextMeshProUGUI> soloRankDataList; // 기록 출력하는 텍스트 프리펩 모아놓을 리스트

    private Dictionary<string, List<int>> coopRankData = new Dictionary<string, List<int>>(); //이름, 점수 저장하는 딕셔너리
    private GameObject CoopRankBox;
    private List<TextMeshProUGUI> coopRankDataList; // 기록 출력하는 텍스트 프리펩 모아놓을 리스트

    public TextMeshProUGUI RankData; // 기록 출력하는 텍스트 프리펩


 
    private void Start()
    {
        soloRankDataList = new List<TextMeshProUGUI>();
        coopRankDataList = new List<TextMeshProUGUI>();

        // 데이터 로드
        LoadDictionaryFromPlayerPrefs();
    }

    public void SaveDictionaryToPlayerPrefs()
    {
        string json = JsonConvert.SerializeObject(soloRankData);
        PlayerPrefs.SetString("SoloRankData", json);
        PlayerPrefs.Save();
    }

    private void LoadDictionaryFromPlayerPrefs()
    {
        string json = PlayerPrefs.GetString("SoloRankData", "{}");
        soloRankData = JsonConvert.DeserializeObject<Dictionary<string, List<int>>>(json);
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

        // 데이터 저장
        SaveDictionaryToPlayerPrefs();

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
