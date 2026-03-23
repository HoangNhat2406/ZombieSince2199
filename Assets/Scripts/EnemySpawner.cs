using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
   // Fixed "GameObjec" to "GameObject" and renamed "enemiesPrefab" to "enemies" 
   // to match your Coroutine logic.
   [SerializeField] private GameObject[] enemies; 
   
   // Fixed "Tranform" to "Transform"
   [SerializeField] private Transform[] spawnPoints; 
   
   [SerializeField] private float timebetweenSpawns = 2f;

   void Start()
   {
       StartCoroutine(SpawnEnemyCoroutine());
   }

    private IEnumerator SpawnEnemyCoroutine()
    {
         while(true)
         {
            yield return new WaitForSeconds(timebetweenSpawns);
            
            // Randomly pick an enemy and a spawn point
            GameObject enemy = enemies[Random.Range(0, enemies.Length)];
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            
            // Spawn the enemy
            Instantiate(enemy, spawnPoint.position, Quaternion.identity);
         }
    }
}