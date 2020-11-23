using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private float objectSpawnRate = 3.0f;
    private float xSpawn = 50;
    private float ySpawnRange = 11;
    private int score;
    public bool isGameActive;

    public List<GameObject> objects;
    public List<GameObject> clouds;
    public GameObject powerup;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

    public Button restartButton;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        StartCoroutine(Spawner());
        score = 0;
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Spawner()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(objectSpawnRate);
            Vector3 randomSpawn = new Vector3(xSpawn, Random.Range(-ySpawnRange, ySpawnRange), 0);
            Vector3 cloudRandomSpawn = new Vector3(xSpawn, Random.Range(-ySpawnRange, ySpawnRange), 10);
            Vector3 powerupRandomSpawn = new Vector3(xSpawn, Random.Range(-ySpawnRange, ySpawnRange), 0);

            int objectIndex = Random.Range(0, objects.Count);
            int cloudIndex = Random.Range(0, clouds.Count);

            Instantiate(objects[objectIndex], randomSpawn, objects[objectIndex].transform.rotation);
            Instantiate(clouds[cloudIndex], cloudRandomSpawn, objects[cloudIndex].transform.rotation);            
            Instantiate(powerup, powerupRandomSpawn, powerup.transform.rotation);

        }

    }

    
   public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    
    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Test");
    }   
    
}
