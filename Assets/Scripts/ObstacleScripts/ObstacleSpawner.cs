using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
   [SerializeField] private GameObject spikePrefab,swingingObstaclePrefab,wolfPrefab;

   [SerializeField] private GameObject[] rotatingObstaclePrefabs;

   [SerializeField] private float spikeYpos = -2.83f;
   [SerializeField] private float wolfYpos = -2.54f;
   [SerializeField] private float rotatingObstacleMinY = -2.91f, rotatingObstacleMaxY = -0.6f;
   [SerializeField] private float swingObstacleMinY = 1.11f, swingObstacleMaxY = 3.3f;

   [SerializeField] private float minSpawnWaitTime = 2f, maxSpawnWaitTime = 3.5f;
   private float spawnWaitTime;

   private int obstacleTypeCount = 4;//спайк свинг волк ротат

   private int obstacleToSpawn;

   private Camera mainCam;
   
   private Vector3 obstacleSpawnPos=Vector3.zero;

   private GameObject newObstacle;

   [SerializeField] private GameObject healthPrefab;
   
   private Vector3 healthSpawnPos = Vector3.zero;

   [SerializeField] private float minHealthY = -3.3f, maxHealthY = 1f;

   private void Awake()
   {
      mainCam=Camera.main;
   }

   private void Update()
   {
      HandleObstacleSpawning();
   }

   private void HandleObstacleSpawning()
   {
      if (Time.time > spawnWaitTime)
      {
         spawnWaitTime = Time.time + Random.Range(minSpawnWaitTime, maxSpawnWaitTime);
         SpawnObstacle();
         SpawnHealth();
      }
   }

   private void SpawnObstacle()
   {
      obstacleToSpawn = Random.Range(0, obstacleTypeCount);
      obstacleSpawnPos.x = mainCam.transform.position.x + 20f;
      
      switch (obstacleToSpawn)
      {
         case 0:
            newObstacle = Instantiate(spikePrefab);
            obstacleSpawnPos.y = spikeYpos;
            break;
         case 1:
            newObstacle = Instantiate(swingingObstaclePrefab);
            obstacleSpawnPos.y = Random.Range(swingObstacleMinY,swingObstacleMaxY);
            break;
         case 2:
            newObstacle = Instantiate(wolfPrefab);
            obstacleSpawnPos.y = wolfYpos;
            break;
         case 3:
            newObstacle = Instantiate(rotatingObstaclePrefabs[Random.Range(0, rotatingObstaclePrefabs.Length)]);
            obstacleSpawnPos.y = Random.Range(rotatingObstacleMinY, rotatingObstacleMaxY);
            break;
      }

      newObstacle.transform.position = obstacleSpawnPos;
   }

   private void SpawnHealth()
   {
      if (Random.Range(0, 10) > 7)
      {
         healthSpawnPos.x = mainCam.transform.position.x + 30f;
         healthSpawnPos.y = Random.Range(minHealthY, maxHealthY);
         Instantiate(healthPrefab, healthSpawnPos, Quaternion.identity);
      }
   }
}
