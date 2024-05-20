
using Unity.VisualScripting;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    [SerializeField] private GameObject itemBubble;

    private Managers managers;

    private void Start()
    {
        managers = Managers.Instance;

        managers.OnEnemyDie += MakeBubble;
    }

    public void MakeBubble(int score)
    {
        //score로 몬스터 종류를 받아 어려운 몬스터는 아이템 확률 높이기?

        int randomNum = Random.Range(0, 4);
        if (randomNum == 4)
        {
            Instantiate(gameObject);
        }
    }
}