using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] coinPrefabs;
    public GameObject obstaclePrefab;
    public GameObject player;
    public GameObject titleScreen;
    public GameObject gameOverScreen;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button playAgainButton;
    private float repeatRate = 2;
    private Vector3 obstaclespawnPos = new Vector3(25, 0, 0);
    private Vector3 coinspawnPos = new Vector3(25, 4, 0);
    private int score;
    public bool active;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnPrefabs()
    {
        // Spawn the obstacles.
        while(active)
        {
            yield return new WaitForSeconds(repeatRate);
            int index = Random.Range(0, coinPrefabs.Length);
            Instantiate(coinPrefabs[index], coinspawnPos, coinPrefabs[index].transform.rotation);
            Instantiate(obstaclePrefab, obstaclespawnPos, obstaclePrefab.transform.rotation);
        }

    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverScreen.gameObject.SetActive(true);
        active = false;
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        active = true;
        score = 0;
        StartCoroutine(SpawnPrefabs());
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
        player.gameObject.SetActive(true);
    }
}
