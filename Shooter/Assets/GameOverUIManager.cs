using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUIManager : MonoBehaviour
{
    public Text victoryText;
    public Text gameOverText;



    void Start()
    {
        victoryText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
    }


    public void ShowVictory()
    {
        victoryText.gameObject.SetActive(true);
    }

    public void ShowGameOver()
    {
        gameOverText.gameObject.SetActive(true);
    }
}
