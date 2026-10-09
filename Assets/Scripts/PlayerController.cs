
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float laneChangeSpeed = 10f;

    // CAN SÝSTEMÝ
    public int maxHealth = 100;
    public int currentHealth;

    public PlayerVisual playerVisual;

    private int currentLane = 1;

    private float[] lanePositions = { -3f, -1f, 1f, 3f };

    void Start()
    {
        currentHealth = maxHealth;

        // MOTOSIKLET HER ZAMAN DUZ DURSUN
        transform.rotation = Quaternion.identity;
    }
    void Update()
    {   //SOL VEYA SAG TUSA BASILI TUTULSA BÝLE BÝR KEZ HAREKET EDÝLMESÝ SAÐLANIYOR WASPRESSED BU ÝÞE YARIYO
        if (Keyboard.current.leftArrowKey.wasPressedThisFrame ||
            Keyboard.current.aKey.wasPressedThisFrame)
        {
            MoveLeft();
        }

        if (Keyboard.current.rightArrowKey.wasPressedThisFrame ||
            Keyboard.current.dKey.wasPressedThisFrame)
        {
            MoveRight();
        }

        MoveToLane();
    }

    //SOL BUTON
    public void MoveLeft()
    {
               ChangeLane(-1);
            
               if ( playerVisual != null )
               {
                   playerVisual.TiltLeft();
               }
    }

    //SAG BUTON
    public void MoveRight()
    {
               ChangeLane(1);

               if ( playerVisual != null )
               {
                   playerVisual.TiltRight();
               }
    }
    void ChangeLane(int direction)  // UPDATE ÝÇÝNDE ALDIÐI GÝRDÝYLE ÞERÝT ARRAYÝNÝ DEÐÝÞTÝRÝYOR
    {
        currentLane += direction;

        currentLane = Mathf.Clamp(currentLane, 0, 3); // ÞERÝTLERÝN SINIRI 0 VE 3 YAPIYOR
    }

    void MoveToLane()
    {
        float targetX = lanePositions[currentLane];

        Vector3 targetPosition = new Vector3(
            targetX,
            -3f,
            transform.position.z
        );

        transform.position = Vector3.MoveTowards( // ÞERÝTLER ARASINDA IÞINLANMAK YERÝNE HAREKET ETMEMÝZÝ SAÐÞIYOR
            transform.position,
            targetPosition,
            laneChangeSpeed * Time.deltaTime
        );
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Traffic"))
        {
            TakeDamage(25);

            ScoreManager scoreManager = FindFirstObjectByType<ScoreManager>();

            if (scoreManager != null)
            {
                scoreManager.ResetCombo();
            }

            AudioManager audioManager =
                    FindFirstObjectByType<AudioManager>();

            if (audioManager != null)
            {
                audioManager.PlayCollisionSound();
            }
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        Debug.Log("Hasar Aldýn! Can: " + currentHealth);
        
        if (currentHealth <= 0)
        {
            currentHealth = 0;

            Debug.Log("Öldün! Oyun Bitti!");

            GameManager gameManager = FindFirstObjectByType<GameManager>();

            if (gameManager != null) 
            { 
                gameManager.GameOver(); 
            }
        }
    }
}



