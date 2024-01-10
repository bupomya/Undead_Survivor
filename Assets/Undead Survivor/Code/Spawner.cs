using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public SpawnData[] spawndata;
    public float levelTime;

    int level;
    float timer;

    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
        levelTime = GameManager.instance.maxGameTime / spawndata.Length;
    }

    void Update()
    {
        if (!GameManager.instance.isLive)
            return;

        Spawn();
    }

    void Spawn()
    {
        timer += Time.deltaTime;
        level = Mathf.Min( Mathf.FloorToInt(GameManager.instance.gameTime / levelTime), spawndata.Length-1);
        // Mathf.FloorToInt : �Ҽ��� ���ϴ� int ������ ����
        // Mathf.CeilToInt() : �Ҽ��� ���ϴ� int������ �ø�


        if (timer > spawndata[level].spawnTime)
        {
            timer = 0f;
            SpawnTime();
        }
    }

    void SpawnTime()
    {
        GameObject enemy = GameManager.instance.pool.Get(0);
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        enemy.GetComponent<Enemy>().Init(spawndata[level]);
    }
}

//����ȭ
[System.Serializable]
public class SpawnData
{
    public float spawnTime;
    public int spriteType;
    public int health;
    public float speed;
}
