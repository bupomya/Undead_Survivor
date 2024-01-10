using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // ��������� ������ ����
    public GameObject[] prefabs;

    // Ǯ ����� �ϴ� ����Ʈ�� 
    List<GameObject>[] pools;

    private void Awake()
    {
        Pooling();
    }

    void Pooling()
    {
        pools = new List<GameObject>[prefabs.Length];

        for(int i = 0; i < pools.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;
        // ������ ��Ȱ��ȭ �Ǿ� �ִ� ���ӿ�����Ʈ ����


        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                // �߰��ϸ� select ������ �Ҵ�
                select = item;
                select.SetActive(true);
                break;
            }
        }

        // ���� Ȱ��ȭ �Ǿ��� ���
        if(!select)
        {
            // ���ο� GameObject ���� �� select ������ �Ҵ�
            select = Instantiate(prefabs[index], transform);
            //instantiate(Object, poolManager�� �ڽ����� ��);

            pools[index].Add(select);
        }

        return select;
    }

}
