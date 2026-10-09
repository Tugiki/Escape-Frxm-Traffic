
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public ScoreManager scoreManager;
    public TMP_Text scoreText;

    void Update()
    {
        scoreText.text = "SCORE: " + scoreManager.score;
    }
}

