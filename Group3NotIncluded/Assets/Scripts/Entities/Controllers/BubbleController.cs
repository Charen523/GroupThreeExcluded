
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
        //score�� ���� ������ �޾� ����� ���ʹ� ������ Ȯ�� ���̱�?

        int randomNum = Random.Range(0, 4);
        if (randomNum == 4)
        {
            Instantiate(gameObject);
        }
    }
}