using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Improve this to cut down on the code with a GameManager Script 
    private float spawnDelay = 1.5f;
    private float spawnInterval = 3f;
    private float powerupSpawnDelay = 3f;
    private float powerupSpawnInterval = 4f;
    private float cloudSpawnDelay = 4f;
    private float cloudSpawnInterval = 5f; 
    private float xSpawn = 50;
    private float ySpawnRange = 11;

    public GameObject[] objects;
    public GameObject[] clouds;
    public GameObject powerup;
    private PlayerController playerScript;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval);
        InvokeRepeating("SpawnPowerup", powerupSpawnDelay, powerupSpawnInterval);
        InvokeRepeating("SpawnClouds", cloudSpawnDelay, cloudSpawnInterval);
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObjects()
    {
        Vector3 randomSpawn = new Vector3(xSpawn, Random.Range(-ySpawnRange, ySpawnRange), 0);
        int index = Random.Range(0, objects.Length);

        Instantiate(objects[index], randomSpawn, objects[index].transform.rotation);
    }

    void SpawnPowerup()
    {
        Vector3 randomSpawn = new Vector3(xSpawn, Random.Range(-ySpawnRange, ySpawnRange), 0);

        Instantiate(powerup, randomSpawn, powerup.transform.rotation);


    }

    void SpawnClouds()
    {
        Vector3 randomSpawn = new Vector3(xSpawn, Random.Range(-ySpawnRange, ySpawnRange), 10);
        int index = Random.Range(0, clouds.Length);

        Instantiate(clouds[index], randomSpawn, objects[index].transform.rotation);

    }

    public void GameOver()
    {

    }
}
