using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //Pool 정의
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab; //저장할 게임 오브젝트: bullet 종류당 1풀.
        public int size; //오브젝트 개수: 너무 많이 하지 말 것.
    }

    public List<Pool> Pools; //Bullet 종류의 개수만큼.
    public Dictionary<string, Queue<GameObject>> PoolDictionary;

    private void Awake()
    {
        // 오브젝트풀 단위: 오브젝트당.
        // pool개수를 넘어가면 강제로 끄고 새로운 오브젝트에게 할당.
        PoolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (var pool in Pools)
        {
            Queue<GameObject> queue = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab, transform);
                obj.SetActive(false);
                queue.Enqueue(obj);
            }
            //Dictionary에 등록
            PoolDictionary.Add(pool.tag, queue);
        }
    }

    public GameObject SpawnFromPool(string tag)
    {
        // Pool 없을 때 예외처리
        if (!PoolDictionary.ContainsKey(tag))
            return null;

        //가장 오래된 것부터 꺼내기.
        GameObject obj = PoolDictionary[tag].Dequeue(); //TODO:사용중일 때 예외처리.
        PoolDictionary[tag].Enqueue(obj);
        obj.SetActive(true);
        return obj;
    }
}