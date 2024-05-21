using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RankingManager : MonoBehaviour
{

    private GameObject RankPanel;
    private List<KeyValuePair<string, int>> soloRankList = new List<KeyValuePair<string, int>>();//이름, 점수 저장하는 리스트
    private GameObject SoloRankBox;
    private List<TextMeshProUGUI> soloRankDataList; // 기록 출력하는 텍스트 프리펩 모아놓을 리스트

    private List<KeyValuePair<string, int>> coopRankList = new List<KeyValuePair<string, int>>();//이름, 점수 저장하는 리스트
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
        string json = JsonConvert.SerializeObject(soloRankList);
        PlayerPrefs.SetString("SoloRankData", json);

        string coopjson = JsonConvert.SerializeObject(coopRankList);
        PlayerPrefs.SetString("CoopRankData", coopjson);

        PlayerPrefs.Save();
    }

    private void LoadDictionaryFromPlayerPrefs()
    {
        string json = PlayerPrefs.GetString("SoloRankData", "{}");
        if(json != "{}") soloRankList = JsonConvert.DeserializeObject<List<KeyValuePair<string, int>>>(json);

        string coopjson = PlayerPrefs.GetString("CoopRankData", "{}");
        if(coopjson != "{}") coopRankList = JsonConvert.DeserializeObject<List<KeyValuePair<string, int>>>(coopjson);
    }


    // 이름, 점수 기록 저장 함수
    public void SetRankData(string playerName, int score)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if(currentScene.name == "SoloScene")
        {
            soloRankList.Add(new KeyValuePair<string, int>(playerName, score));
        }
        else if (currentScene.name == "CoopScene")
        {
            coopRankList.Add(new KeyValuePair<string, int>(playerName, score));
        }


        // 데이터 저장
        SaveDictionaryToPlayerPrefs();

    }

    public void PrintSoloRankList()
    {
        RankPanel = GameObject.Find("Canvas").transform.Find("RankPanel").gameObject;
        SoloRankBox = RankPanel.transform.Find("SoloRank").transform.Find("Scroll View").transform.Find("Viewport").transform.Find("Content").gameObject;

        var sortedScores = soloRankList.OrderByDescending(score => score.Value);

        // 정렬된 점수 출력
        int i = 0;
        foreach (var score in sortedScores)
        {
            if (soloRankDataList.Count > 7) break;

            RankData.text = "name: " + score.Key + "\n" + "score: " + score.Value.ToString();
            TextMeshProUGUI data = Instantiate(RankData);
            data.transform.SetParent(SoloRankBox.transform, false); //프리펩 위치를 SoloRank의 자식으로 이동
            soloRankDataList.Add(data);
            i++;
        }

    }

    public void PrintCoopRankList()
    {

        RankPanel = GameObject.Find("Canvas").transform.Find("RankPanel").gameObject;
        CoopRankBox = RankPanel.transform.Find("CoopRank").transform.Find("Scroll View").transform.Find("Viewport").transform.Find("Content").gameObject;

        // 점수를 내림차순으로 정렬
        var sortedScores = coopRankList.OrderByDescending(score => score.Value);

        // 정렬된 점수 출력
        int i = 0;
        foreach (var score in sortedScores)
        {
            if (coopRankDataList.Count > 7) break;

            RankData.text = "name: " + score.Key + "\n" + "score: " + score.Value.ToString();

            TextMeshProUGUI data = Instantiate(RankData);
            data.transform.SetParent(CoopRankBox.transform, false); //프리펩 위치를 SoloRank의 자식으로 이동
            coopRankDataList.Add(data);

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
