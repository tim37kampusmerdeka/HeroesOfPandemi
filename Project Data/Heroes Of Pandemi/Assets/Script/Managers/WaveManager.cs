using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public Wave[] waves;
    public Transform[] enemySpawnPoints;
    public float timeBetweenWave = 5;
    private float timer;

    private Wave currentWave;
    private int currentWaveIndex;
    private bool canSpawnEnemy = true;
    private float rateSpawnEnemy;

    private void Start()
    {
        timer = timeBetweenWave;
    }
    void Update()
    {
        currentWave = waves[currentWaveIndex];
        timeBetweenWave -= Time.deltaTime;
        SpawnWave();
        NextWave();
    }

    void SpawnWave()
    {
        if (canSpawnEnemy && rateSpawnEnemy < Time.time)
        {
            // Membuat random Enemy dan posisi randown spawn
            GameObject randomEnemy = currentWave.enemiesType[Random.Range(0, currentWave.enemiesType.Length)];
            Transform randomPoint = enemySpawnPoints[Random.Range(0, enemySpawnPoints.Length)];

            // Instantiate Enemy
            Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);

            // Setiap instantiate enemy, kurangi total enemy untuk menghitung jumlah spawn enemy
            currentWave.totalEnemyWave--;

            // Membuat interval antar spawn
            rateSpawnEnemy = Time.time + currentWave.spawnInterval;
            if (currentWave.totalEnemyWave == 0)
            {
                canSpawnEnemy = false;
            }
        }
    }
    void NextWave()
    {
        GameObject[] countEnemisNow = GameObject.FindGameObjectsWithTag("Enemy");

        if (countEnemisNow.Length == 0 && !canSpawnEnemy && timeBetweenWave <= 0f && currentWaveIndex + 1 != waves.Length)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                currentWaveIndex++;
                canSpawnEnemy = true;
                timer = timeBetweenWave;
            }
        }
        else
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
    public GameObject[] enemiesType;
    public float spawnInterval;
}
