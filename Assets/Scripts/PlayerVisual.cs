using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerVisual : MonoBehaviour
{
    public float tiltAngle = 12f;
    public float tiltSpeed = 10f;

    private float targetTilt = 0f;

    public void TiltLeft()
    {
        targetTilt = tiltAngle;
    }

    public void TiltRight()
    {
        targetTilt = -tiltAngle;
    }

    void Update()
    {
        // Klavye ile test
        if (Keyboard.current != null)
        {
            if (Keyboard.current.leftArrowKey.wasPressedThisFrame ||
                Keyboard.current.aKey.wasPressedThisFrame)
            {
                TiltLeft();
            }

            if (Keyboard.current.rightArrowKey.wasPressedThisFrame ||
                Keyboard.current.dKey.wasPressedThisFrame)
            {
                TiltRight();
            }
        }

        // Zamanla düz konuma dön
        targetTilt = Mathf.Lerp(
            targetTilt,
            0f,
            5f * Time.deltaTime
        );

        Quaternion targetRotation =
            Quaternion.Euler(0f, 0f, targetTilt);

        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            targetRotation,
            tiltSpeed * Time.deltaTime
        );
    }
}

