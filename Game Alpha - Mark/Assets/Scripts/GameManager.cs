using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float objectSpawnRate = 3.0f;
    private float xSpawn = 50;
    private float ySpawnRange = 11;

    public List<GameObject> objects;
    public List<GameObject> clouds;
    // Use for beta
    //public GameObject powerup;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(objectSpawnRate);
            Vector3 randomSpawn = new Vector3(xSpawn, Random.Range(-ySpawnRange, ySpawnRange), 0);

            int objectIndex = Random.Range(0, objects.Count);
            int cloudIndex = Random.Range(0, clouds.Count);

            Instantiate(objects[objectIndex], randomSpawn, objects[objectIndex].transform.rotation);
            Instantiate(clouds[cloudIndex], randomSpawn, objects[cloudIndex].transform.rotation);

        }
    }
}
