using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float spawnDelay = 1.5f;
    private float spawnInterval = 2f;
    private float powerupSpawnDelay = 3f;
    private float powerupSpawnInterval = 4f;
    private float xSpawnLimit = 38;
    private float xPowerupSpawn = 20;
    private float ySpawnRange = 11;
    public GameObject[] obstacleOrGifts;
    public GameObject powerup;
    private PlayerController playerScript;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval);
        InvokeRepeating("SpawnPowerup", powerupSpawnDelay, powerupSpawnInterval);
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObjects()
    {
        Vector3 randomSpawn = new Vector3(xSpawnLimit, Random.Range(-ySpawnRange, ySpawnRange), 0);
        int index = Random.Range(0, obstacleOrGifts.Length);

        Instantiate(obstacleOrGifts[index], randomSpawn, obstacleOrGifts[index].transform.rotation);
    }

    void SpawnPowerup()
    {
        Vector3 randomSpawn = new Vector3(xPowerupSpawn, Random.Range(-ySpawnRange, ySpawnRange), 0);

        Instantiate(powerup, randomSpawn, powerup.transform.rotation);


    }
}
