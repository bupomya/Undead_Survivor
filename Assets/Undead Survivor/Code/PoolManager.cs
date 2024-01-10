using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // 프리펩들을 보관할 변수
    public GameObject[] prefabs;

    // 풀 담당을 하는 리스트들 
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
        // 선택한 비활성화 되어 있는 게임오브젝트 접근


        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                // 발견하면 select 변수에 할당
                select = item;
                select.SetActive(true);
                break;
            }
        }

        // 전부 활성화 되었을 경우
        if(!select)
        {
            // 새로운 GameObject 생성 후 select 변수에 할당
            select = Instantiate(prefabs[index], transform);
            //instantiate(Object, poolManager에 자식으로 들어감);

            pools[index].Add(select);
        }

        return select;
    }

}
