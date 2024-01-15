using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    private int loseCount;
    private int winCount;


    public void SaveWin()
    {
        bool isExist = PlayerPrefs.HasKey("win");

        if(isExist )
        {
            winCount = PlayerPrefs.GetInt("win", 0);
            winCount++;
            PlayerPrefs.SetInt("win", winCount);
            PlayerPrefs.Save();
        }
    }

    public void SaveLose()
    {
        bool isExist = PlayerPrefs.HasKey("lose");

        if(isExist )
        {
            winCount = PlayerPrefs.GetInt("lose", 0);
            winCount++;
            PlayerPrefs.SetInt("lose", loseCount);
            PlayerPrefs.Save();
        }
    }

}
