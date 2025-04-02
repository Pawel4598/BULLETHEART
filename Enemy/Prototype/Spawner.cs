using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; 
    public float[] spawnWeights; 
    public Transform[] spawnPoints; 
    public int enemiesPerWave = 5; 
    public float spawnCooldown = 5f; 
    public float spawnDelay = 0.5f; 

    private int currentWave = 0;
    private bool isSpawning = false;
    public bool playerInRoom = false; 
    private float remainingCooldown;
    private Coroutine spawning;

    void Start()
    {
        if (spawnWeights.Length != enemyPrefabs.Length)
        {
            Debug.LogError("Spawn weights array length must match enemy prefabs array length.");
        }
        remainingCooldown = spawnCooldown;
    }

    void Update()
    {
        if (!isSpawning && AreAllEnemiesDead() && playerInRoom)
        {
            spawning = StartCoroutine(SpawnWave());
        }
    }

    public bool AreAllEnemiesDead()
    {
        return GameObject.FindGameObjectsWithTag("Enemy").Length == 0;
    }

    IEnumerator SpawnWave()
    {
        isSpawning = true;

        while (remainingCooldown > 0)
        {
            if (playerInRoom)
            {
                remainingCooldown -= Time.deltaTime;
            }
            yield return null;
        }

        currentWave++;
        Debug.Log("Spawning wave " + currentWave);

        for (int i = 0; i < enemiesPerWave; i++)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject enemyPrefab = GetRandomEnemyPrefab();
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(spawnDelay); 
        }

        remainingCooldown = spawnCooldown;
        isSpawning = false;
    }

    GameObject GetRandomEnemyPrefab()
    {
        float totalWeight = 0f;
        foreach (float weight in spawnWeights)
        {
            totalWeight += weight;
        }

        float randomValue = Random.Range(0, totalWeight);
        float cumulativeWeight = 0f;

        for (int i = 0; i < enemyPrefabs.Length; i++)
        {
            cumulativeWeight += spawnWeights[i];
            if (randomValue < cumulativeWeight)
            {
                return enemyPrefabs[i];
            }
        }

        return enemyPrefabs[0]; 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRoom = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRoom = false;
            DestroyAllEnemies();
            if (spawning != null)
            {
                StopCoroutine(spawning);
                isSpawning = false;
            }
        }
    }
    void DestroyAllEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
    }
}
