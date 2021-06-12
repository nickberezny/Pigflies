using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : Singleton<HUD>
{
    [SerializeField] Text _scoreText;

    public void SetScoreText(int score)
    {
        _scoreText.text = "Pigs x " + score.ToString();
        
    }
}
