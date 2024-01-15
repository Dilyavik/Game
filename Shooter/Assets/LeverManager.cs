using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeverManager : MonoBehaviour
{

    private int enemiesRemaining;
    public GameOverUIManager gameOverUiManager;


    void Start()
    {
        Enemies();
    }

    // Update is called once per frame
    void Update()
    {
        Enemies();
        if (enemiesRemaining == 0)
        {
            gameOverUiManager.ShowVictory();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void Enemies()
    {
        enemiesRemaining = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }
}
