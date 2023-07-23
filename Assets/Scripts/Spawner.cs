using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] _spawnPoint;
    public SpawnData[] spawnData;
    public WaveData[] waveData;
    public BossData[] bossData;

    float _timer;
    int spawnLevel = 0; // 플레이어 레벨
    int waveLevel = 0;
    int bossLevel = 0;

    void Awake()
    {
        _spawnPoint = GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        if (!Managers.instance.isLive) 
            return;

        _timer += Time.deltaTime;

        if (Managers.instance._gameTime > spawnData[spawnLevel].waveTime * 60)
        {
            spawnLevel++;
        }

        if (Managers.instance._gameTime > waveData[waveLevel].waveTime * 60f)
        {
            SpawnWave();
        }

        if (Managers.instance._gameTime > bossData[bossLevel].spawnTime * 60f)
        {
            GameObject boss = Instantiate(bossData[bossLevel].monster);
            boss.transform.position = _spawnPoint[UnityEngine.Random.Range(1, _spawnPoint.Length)].position;
            boss.GetComponent<EnemyController>().Init();
        }

        if (_timer > 1.5f)
        {
            _timer = 0f;
            Spawn();
        }
    }

    void Spawn()
    {
        GameObject enemy = Managers.instance.Pool.Get(UnityEngine.Random.Range(spawnData[spawnLevel].firstIndex, spawnData[spawnLevel].lastIndex + 1));
        enemy.transform.position = _spawnPoint[UnityEngine.Random.Range(1, _spawnPoint.Length)].position;
        enemy.GetComponent<EnemyController>().Init();
    }

    void SpawnWave()
    {
        Debug.Log(1);
        Vector3 randPos = _spawnPoint[UnityEngine.Random.Range(1, _spawnPoint.Length)].position;
        for (int i = 0; i < waveData[waveLevel].monsterIndexes.Length; i++)
        {
            for (int j = 0; j < waveData[waveLevel].monsterCounts[i]; j++)
            {
                GameObject enemy = Managers.instance.Pool.Get(waveData[waveLevel].monsterIndexes[i]);
                enemy.transform.position = randPos;
                enemy.GetComponent<EnemyController>().Init();
            }
        }
        waveLevel++;
    }
}

[System.Serializable]
public class SpawnData
{
    public float waveTime;
    public int firstIndex;
    public int lastIndex;
}

[System.Serializable]
public class WaveData
{
    public float waveTime;
    public int[] monsterIndexes;
    public int[] monsterCounts;
}

[System.Serializable]
public class BossData
{
    public float spawnTime;
    public GameObject monster;
}
