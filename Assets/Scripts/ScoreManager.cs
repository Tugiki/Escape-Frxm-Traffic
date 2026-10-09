
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;

    public float scoreSpeed = 20f;

    //COMBO BÝLGÝLERÝ
    public int combo = 0;

    void Update()
    {
        // Oyun devam ederken puan artýr
        score += Mathf.RoundToInt(scoreSpeed * Time.deltaTime);
    }

    public void AddScore(int amount)
    {
        score += amount;

        Debug.Log("BONUS! +" + amount + " puan");
    }

    public void CarPassed()
    {
        combo++;

        //HER BAÞARILI GEÇÝÞTE BONUS ARTIYOR
        int bonus = 100 + ((combo - 1) * 50);

        score += bonus;

        Debug.Log(
            "COMBO x" + combo + 
            "    BONUS +" + bonus
            );

        AudioManager audioManager =
                    FindFirstObjectByType<AudioManager>();

        if (audioManager != null)
        {
            if (combo >= 2)
            {
                audioManager.PlayComboSound();
            }
            else
            {
                audioManager.PlayScoreSound();
            }
        }
    }

    public void ResetCombo()
    {
        combo = 0;

        Debug.Log("COMBO SIFIRLANDI!");
    }
}

