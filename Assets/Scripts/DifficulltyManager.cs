using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficulltyManager : MonoBehaviour
{
    public int difficulty;

    private Button button;
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void SetDifficulty()
    {
        gm.StartGame(difficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
