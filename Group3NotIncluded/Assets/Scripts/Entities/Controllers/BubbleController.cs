using System;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    [Header("Players")]
    public GameObject[] players;

    [Header("ItemPrefab")]
    [SerializeField] private GameObject itemBubble;

    private Managers managers;

    private void Start()
    {
        managers = Managers.Instance;
        managers.OnEnemyDie += MakeBubble;
    }

    private void OnDisable()
    {
        managers.OnEnemyDie -= MakeBubble;
    }

    public void MakeBubble(GameObject enemy)
    {
        Vector3 instantiatePos = AdjustPosition(enemy.transform.position);
        GameObject newBubble = Instantiate(itemBubble, instantiatePos, Quaternion.identity);
        int randomItemNum = UnityEngine.Random.Range(0, 5);
        SpriteRenderer spriteRenderer = newBubble.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Resources.Load<Sprite>($"beffio/Icons/Icon{randomItemNum}");
    }

    private Vector3 AdjustPosition(Vector3 position)
    {
        if (position.y < -3f) position.y += 0.5f;
        else if (position.y > 3f) position.y -= 0.5f;
        else if (position.x < -8.5f) position.x += 0.5f;
        else position.x -= 0.5f;

        return position;
    }
}