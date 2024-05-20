using System;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    public event Action OnBulletElliminate;
    public event Action OnHealthIncrease;
    public event Action OnInvincible;
    public event Action OnBoostFull;
    public event Action OnMultishot;

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
        spriteRenderer.sprite = Resources.Load<Sprite>($"beffio/Icons/Icon{0}");

        newBubble.transform.position = instantiatePos;
    }

    public void InvokeItem0()
    {
        OnBulletElliminate?.Invoke();

        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach(GameObject bullet in bullets)
        {
            bullet.SetActive(false);
        }
    }

    public void InvokeItem1()
    {
        OnHealthIncrease?.Invoke();
    }

    public void InvokeItem2()
    {
        OnInvincible?.Invoke();
    }

    public void InvokeItem3()
    {
        OnBoostFull?.Invoke();
    }

    public void InvokeItem4()
    {
        OnMultishot?.Invoke();
    }
}