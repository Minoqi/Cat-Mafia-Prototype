using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //Variables

    //Customers
    public GameObject customerPrefab; //Use if greelit

    //Enemies
    public GameObject enemyPrefab;
    public Transform[] enemySpawnPoints;

    //Spawn Timer
    public float spawnTimer;
    private float currentSpawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        currentSpawnTimer = spawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemies();
    }

    //Spawn Enemies
    void SpawnEnemies()
    {
        //Check Time Between Spawns
        if(currentSpawnTimer > 0)
        {
            currentSpawnTimer -= Time.deltaTime;
        }
        else
        {
            //Spawn Random Amount of Enemies
            int spawnAmount = Random.Range(1, enemySpawnPoints.Length);

            //Spawn Enemies
            for(int i = 0; i < spawnAmount; i ++)
            {

                //Choose Spawn Point & Spawn
                int location = Random.Range(0, enemySpawnPoints.Length);
                Instantiate(enemyPrefab, enemySpawnPoints[location].position, Quaternion.identity);
            }

            //Reset Timer
            currentSpawnTimer = spawnTimer;
        }
    }
}
