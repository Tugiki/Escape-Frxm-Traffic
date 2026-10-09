using UnityEngine;
using TMPro;

public class ComboUI : MonoBehaviour
{
    public ScoreManager scoreManager;
    public TMP_Text comboText;

    private int lastCombo = 0;

    private Vector3 normalScale;
    private float animationTimer = 0f;

    void Start()
    {
        normalScale = comboText.transform.localScale;
    }

    void Update()
    {
        int currentCombo = scoreManager.combo;

        // Combo deðiþtiyse
        if (currentCombo != lastCombo)
        {
            lastCombo = currentCombo;

            comboText.text = "COMBO x" + currentCombo;

            // Yeni combo geldiðinde animasyonu baþlat
            animationTimer = 0.25f;
        }

        // Büyüme animasyonu
        if (animationTimer > 0f)
        {
            animationTimer -= Time.deltaTime;

            float scale = 1f + animationTimer * 2f;

            comboText.transform.localScale =
                normalScale * scale;
        }
        else
        {
            comboText.transform.localScale = normalScale;
        }
    }
}
