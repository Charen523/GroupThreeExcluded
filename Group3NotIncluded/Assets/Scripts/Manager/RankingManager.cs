using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RankingManager : MonoBehaviour
{
    // 현재는 Inspector에서 오브젝트(RankPanel의 SoloRank, CoopRank)를 수동으로 넣어주는 형식. 
    // SoloScene으로 이동하면 오브젝트가 소멸되는 문제가 있음. 
    // StartScene이 시작될때 자동으로 오브젝트를 넣어주도록 수정 필요


    private List<float> soloRankTime; // 시간 기록들 저장할 리스트
    private List<int> soloRankScore; // 점수 기록들 저장할 리스트
    public GameObject SoloRankBox;
    private Queue<TextMeshProUGUI> soloRankDataQueue; // 기록 출력하는 텍스트 프리펩 모아놓을 큐

    private List<float> coopRankTime; // 시간 기록들 저장할 리스트
    private List<int> coopRankScore; // 점수 기록들 저장할 리스트
    public GameObject CoopRankBox;
    private Queue<TextMeshProUGUI> coopRankDataQueue; // 기록 출력하는 텍스트 프리펩 모아놓을 큐

    public TextMeshProUGUI RankData; // 기록 출력하는 텍스트 프리펩


    private void Start()
    {
        soloRankTime = new List<float>();
        soloRankScore = new List<int>();
        soloRankDataQueue = new Queue<TextMeshProUGUI>();

        coopRankTime = new List<float>();
        coopRankScore = new List<int>();
        coopRankDataQueue = new Queue<TextMeshProUGUI>();

        //출력 확인용
        SetRankTime(10);
        SetRankScore(155);

        //출력 확인용, 실제로는 RankPanel이 활성화 될 때 실행
        PrintSoloRankList();
        PrintCoopRankList();
    }

    // 시간 기록 저장 함수. GameOver에 실행
    public void SetRankTime(float time)
    {
        //테스트용
        soloRankTime.Add(time);
        coopRankTime.Add(time);
    }

    // 점수 기록 저장 함수. GameOver에 실행
    public void SetRankScore(int score)
    {
        //테스트용
        soloRankScore.Add(score);
        coopRankScore.Add(score);
    }


    public void PrintSoloRankList()
    {
        for (int i = 0; i < 5; i++) //for (int i = 0; i < ranktime.Count; i++), 현재는 출력 확인용 5번반복
        {
            Vector3 position = new Vector3(0, 200 - i * 100, 0);
            Quaternion rotation = Quaternion.Euler(0, 0, 0);
            RankData.text = "time: "+ soloRankTime[0].ToString() + "\n" +  "score: " + soloRankScore[0].ToString(); 

            TextMeshProUGUI data = Instantiate(RankData, position, rotation);
            data.transform.SetParent(SoloRankBox.transform, false); //프리펩 위치를 SoloRank의 자식으로 이동
            soloRankDataQueue.Enqueue(data);
        }
    }

    public void PrintCoopRankList()
    {
        
        for (int i = 0; i < 5; i++) //for (int i = 0; i < ranktime.Count; i++), 현재는 출력 확인용 5번반복
        {
            Vector3 position = new Vector3(0, 200 - i * 100, 0);
            Quaternion rotation = Quaternion.Euler(0, 0, 0);
            RankData.text = "time: "+ soloRankTime[0].ToString() + "\n" +  "score: " + soloRankScore[0].ToString(); 

            TextMeshProUGUI data = Instantiate(RankData, position, rotation);
            data.transform.SetParent(CoopRankBox.transform, false); //프리펩 위치를 CoopRank의 자식으로 이동
            coopRankDataQueue.Enqueue(data);
        }
    }
}
