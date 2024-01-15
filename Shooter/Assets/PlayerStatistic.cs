using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStatistic : MonoBehaviour
{
    private int lossesCount;
    private int winsCount;

    public TextMeshProUGUI lossTextMeshPro;
    public TextMeshProUGUI winTextMeshPro;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WinPlayer();
        LossPlayer();
    }


    public void WinPlayer()
    {
        winsCount = PlayerPrefs.GetInt("win");
        winTextMeshPro.text = "Побед: " + winsCount;
    }


    public void LossPlayer()
    {
        lossesCount = PlayerPrefs.GetInt("lose");

        //LossesCount++;
        lossTextMeshPro.text = "Поражений: " + lossesCount;
    }
}
