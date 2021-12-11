using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public Wave[] waves;
    public Transform[] enemySpawnPoints;
    public float timeBetweenWave;
    private float timer;

    private Wave currentWave;
    private int currentWaveIndex;
    private bool canSpawnEnemy = true;
    private float rateSpawnEnemy;

    // Ubah dari script enemy factory di baris 63
    private EnemyFactory _poolEnemies;

    private void Start()
    {
        timer = timeBetweenWave;

        _poolEnemies = GameObject.FindObjectOfType<EnemyFactory>();
    }
    void Update()
    {
        currentWave = waves[currentWaveIndex];
        SpawnWave();
        NextWave();
    }

    void SpawnWave()
    {
        if (canSpawnEnemy && rateSpawnEnemy < Time.time)
        {
            //  Spawn Enemy dari enemy point
            Transform randomPoint = enemySpawnPoints[Random.Range(0, enemySpawnPoints.Length)];

            for (int i = 0; i < _poolEnemies.listEnemies.Count; i++)
            {
                if (_poolEnemies.listEnemies[i].activeInHierarchy == false)
                {
                    _poolEnemies.listEnemies[i].SetActive(true);
                    _poolEnemies.listEnemies[i].transform.position = randomPoint.position;
                    _poolEnemies.listEnemies[i].transform.rotation = Quaternion.identity;
                    currentWave.totalEnemyWave--;
                    break;
                }
            }

            // Membuat interval antar spawn
            rateSpawnEnemy = Time.time + currentWave.spawnInterval;
            if (currentWave.totalEnemyWave == 0)
            {
                canSpawnEnemy = false;
            }
            Debug.Log("Wave :" + currentWave.waveName);
        }
    }
    void NextWave()
    {
        GameObject[] countEnemisNow = GameObject.FindGameObjectsWithTag("Enemy");

        if (countEnemisNow.Length == 0 && !canSpawnEnemy && currentWaveIndex + 1 != waves.Length)
        {
            timer -= Time.deltaTime;
            Debug.Log("Timer Delay : " + timer);

            if (timer <= 0f)
            {
                currentWaveIndex++;
                canSpawnEnemy = true;
                timer = timeBetweenWave;
            }
        }
        if (countEnemisNow.Length == 0 && !canSpawnEnemy && currentWaveIndex + 1 == waves.Length)
        {
            Debug.Log("Wave Finished");
            GameManager.Instance.PlayerCondition(true);
        }
    }
}

// Wave Attribute
[System.Serializable]
public class Wave
{
    public string waveName;
    public int totalEnemyWave;
    public float spawnInterval;
}
