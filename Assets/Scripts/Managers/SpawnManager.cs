using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager spawnManagerInstance;

    [SerializeField]
    private GameObject[] enemies;
    [SerializeField]
    private Transform[] spawnSpots;

    public int maxEnemies = 5, enemiesAmount = 0;

    private void Awake()
    {
        if (spawnManagerInstance == null)
            spawnManagerInstance = this;
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if(maxEnemies > enemiesAmount)
            {
                int currentEnemy = Random.Range(0, enemies.Length);
                int currentSpot = Random.Range(0, spawnSpots.Length);

                enemiesAmount += 1;
                Instantiate(enemies[currentEnemy], spawnSpots[currentSpot].position, enemies[currentEnemy].transform.rotation);
            }

            yield return new WaitForSeconds(GameManager.gameManagerInstance.spawnTime);
        }
    }
}
