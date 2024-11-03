using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Naninovel;

public class PlayerBag : MonoSingleton<PlayerBag>
{
    [SerializeField] private int score;
    public int Score => score;
    [SerializeField] private TextMeshProUGUI scoreText;

    public void ChangeScore(int change)
    {
        score += change;
        UIChangeScore();
    }
   


    private void UIChangeScore()
    {
        if(scoreText != null)
        scoreText.text = score.ToString();
    }

    public bool CheckScore(int check)
    {
        return score >= check;
    }
}
