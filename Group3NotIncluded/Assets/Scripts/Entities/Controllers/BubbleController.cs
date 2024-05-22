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
        Vector3 instantiatePos = enemy.transform.position;

        if (instantiatePos.y < -3f)
            instantiatePos.y += 0.5f;
        else if (instantiatePos.y > 3f)
            instantiatePos.y -= 0.5f;
        else if (instantiatePos.x < -8.5f)
            instantiatePos.x += 0.5f;
        else
            instantiatePos.x -= 0.5f;

        GameObject newBubble = Instantiate(itemBubble);

        int randomItemNum = UnityEngine.Random.Range(0, 5);

        SpriteRenderer spriteRenderer = newBubble.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Resources.Load<Sprite>($"beffio/Icons/Icon{randomItemNum}");

        newBubble.transform.position = instantiatePos;
    }
}