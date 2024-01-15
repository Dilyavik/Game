using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStatistic : MonoBehaviour
{
    public int LossesCount;
    public int WinsCount;

    public TextMeshProUGUI lossTextMeshPro;
    public TextMeshProUGUI winTextMeshPro;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void WinPlayer()
    {
        WinsCount++;
        winTextMeshPro.text = "Побед: " + WinsCount;
    }


    public void LossPlayer()
    {
        WinsCount++;
        lossTextMeshPro.text = "Поражений: " + LossesCount;
    }
}
