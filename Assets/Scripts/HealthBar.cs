using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PlayerController player;
    public Image healthBarFill;

    void Update()
    {
        float healthPercent = (float)player.currentHealth / player.maxHealth;

        healthBarFill.fillAmount = healthPercent;
    }
}
