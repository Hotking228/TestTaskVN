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

    private void Start()
    {
        UIChangeScore();
    }

    private void UIChangeScore()
    {
        if(scoreText != null)
        scoreText.text = "Score : " + score.ToString();
    }

    public bool CheckScore(int check)
    {
        return score >= check;
    }


    public void ShowScore()
    {
        scoreText.transform.parent.gameObject.SetActive(true);
    }

    public void HideScore()
    {
        scoreText.transform.parent.gameObject.SetActive(false);
    }
}
