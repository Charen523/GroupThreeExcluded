using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankPanelBtn : MonoBehaviour
{
    public void OpenRankPanel(GameObject obj)
    {
        Managers.Instance.rankingManager.PrintSoloRankList();
        Managers.Instance.rankingManager.PrintCoopRankList();
        obj.SetActive(!obj.activeSelf);
    }

    public void CloseRankPanel(GameObject obj)
    {
        obj.SetActive(!obj.activeSelf);
        Managers.Instance.rankingManager.DestroyRankList();
    }

}
