using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targetPrefabs;
    public float spawnDelaySeconds = 2f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    private bool isGameOver = false;

    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnRandomTarget());
        AddToScore(0);
    }
    public bool IsGameOver()
    {
        return isGameOver;
    }
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameOver = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    IEnumerator spawnRandomTarget()
    {
        while(!isGameOver)
        {
            yield return new WaitForSecondsRealtime(spawnDelaySeconds);
            Instantiate(targetPrefabs[Random.Range(0, targetPrefabs.Count)]);
        }
    }

    public void AddToScore(int addScore)
    {
        score += addScore;
        if (score < 0) score = 0;
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
