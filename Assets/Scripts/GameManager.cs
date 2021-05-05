﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targetPrefabs;
    public float spawnDelaySeconds = 2f;
    public TextMeshProUGUI scoreText;

    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnRandomTarget());
        AddToScore(0);
    }

    IEnumerator spawnRandomTarget()
    {
        while(true)
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
