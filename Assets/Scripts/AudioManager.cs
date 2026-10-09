using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip scoreSound;
    public AudioClip collisionSound;
    public AudioClip comboSound;

    public void PlayScoreSound()
    {
        if (scoreSound != null)
        {
            audioSource.PlayOneShot(scoreSound);
        }
    }

    public void PlayCollisionSound()
    {
        if (collisionSound != null)
        {
            audioSource.PlayOneShot(collisionSound);
        }
    }

    public void PlayComboSound()
    {
        if (comboSound != null)
        {
            audioSource.PlayOneShot(comboSound);
        }
    }
}
