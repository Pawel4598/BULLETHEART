using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public float[] spawnWeights;
    public Transform[] spawnPoints;
    public int enemiesPerWave;
    public float spawnCooldown;
    public float spawnDelay = 0.5f;

   // private int currentWave = 0;
    private bool isSpawning = false;
    public bool playerInRoom = false;

    // Start is called before the first frame update
    void Start()
    {
        if (spawnWeights.Length != enemyPrefabs.Length)
        {
            Debug.LogError("Spawn weights array length must match enemy prefab array length");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSpawning && AreAllEnemiesDead() && playerInRoom)
            StartCoroutine(SpawnWave());
    }

    bool AreAllEnemiesDead()
    {
        return GameObject.FindGameObjectsWithTag("Enemy").Length == 0;
    }

    IEnumerator SpawnWave()
    {
        isSpawning = true;
        yield return new WaitForSeconds(spawnCooldown);

        for (int i = 0; i < enemiesPerWave; i++)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0,spawnPoints.Length)];
            GameObject enemyPrefab = GetRandomEnemyPrefab();
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(spawnDelay);
        }

        isSpawning = false;
    }

    GameObject GetRandomEnemyPrefab()
    {
        float totalWeight = 0f;
        foreach (float weight in spawnWeights)
            totalWeight =+ weight;

        float randomValue = Random.Range(0, totalWeight);
        float cumulativeWeight = 0f;

        for (int i = 0; i < enemyPrefabs.Length; i++)
        {
            cumulativeWeight += spawnWeights[i];
            if (randomValue < cumulativeWeight)
                return enemyPrefabs[i];
        }

        return enemyPrefabs[0];
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            playerInRoom = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInRoom = false;
    }
}
