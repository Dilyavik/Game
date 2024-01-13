using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverManager : MonoBehaviour
{

    public int enemiesRemaining;
    public GameOverUIManager gameOverUiManager;


    void Start()
    {
        enemiesRemaining = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesRemaining == 0)
            gameOverUiManager.ShowVictory();
    }
}
