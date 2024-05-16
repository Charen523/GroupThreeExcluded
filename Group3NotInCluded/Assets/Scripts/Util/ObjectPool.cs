using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //Pool ����
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab; //������ ���� ������Ʈ: bullet ������ 1Ǯ.
        public int size; //������Ʈ ����: �ʹ� ���� ���� �� ��.
    }

    public List<Pool> Pools; //Bullet ������ ������ŭ.
    public Dictionary<string, Queue<GameObject>> PoolDictionary;

    private void Awake()
    {
        // ������ƮǮ ����: ������Ʈ��.
        // pool������ �Ѿ�� ������ ���� ���ο� ������Ʈ���� �Ҵ�.
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
            //Dictionary�� ���
            PoolDictionary.Add(pool.tag, queue);
        }
    }

    public GameObject SpawnFromPool(string tag)
    {
        // Pool ���� �� ����ó��
        if (!PoolDictionary.ContainsKey(tag))
            return null;

        //���� ������ �ͺ��� ������.
        GameObject obj = PoolDictionary[tag].Dequeue(); //TODO:������� �� ����ó��.
        PoolDictionary[tag].Enqueue(obj);
        obj.SetActive(true);
        return obj;
    }
}