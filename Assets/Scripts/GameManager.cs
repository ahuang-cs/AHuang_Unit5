using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targetPrefabs;
    public float spawnDelaySeconds = 2f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnRandomTarget());
    }

    IEnumerator spawnRandomTarget()
    {
        while(true)
        {
            yield return new WaitForSecondsRealtime(spawnDelaySeconds);
            Instantiate(targetPrefabs[Random.Range(0, targetPrefabs.Count)]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
