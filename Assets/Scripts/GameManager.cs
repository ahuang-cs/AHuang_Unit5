using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targetPrefabs;
    public float baseSpawnDelaySeconds = 2f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public GameObject titleScreen;
    private bool isGameOver = true;

    private int score = 0;
    private float spawnDelaySeconds;

    // Start is called before the first frame update
    void Start()
    {

    }
    public bool IsGameOver()
    {
        return isGameOver;
    }

    public void StartGame(int difficulty)
    {
        isGameOver = false;
        score = 0;
        spawnDelaySeconds = baseSpawnDelaySeconds / difficulty;
        StartCoroutine(spawnRandomTarget());
        AddToScore(0);
        gameOverText.gameObject.SetActive(false);
        titleScreen.SetActive(false);
    }
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        titleScreen.gameObject.SetActive(true);
        isGameOver = true;
        StopCoroutine(spawnRandomTarget());
        DestroyAllTargets();
    }

    private void DestroyAllTargets()
    {
        foreach (GameObject target in GameObject.FindGameObjectsWithTag("Target").Union<GameObject>(GameObject.FindGameObjectsWithTag("Hazard")))
        {
            target.GetComponent<Target>().DestroyTarget();
        }
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
            if (!isGameOver)
            {
                Instantiate(targetPrefabs[Random.Range(0, targetPrefabs.Count)]);
            }
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
