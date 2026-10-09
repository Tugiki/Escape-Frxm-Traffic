using UnityEngine;

public class TrafficCar : MonoBehaviour
{
    public float speed = 3f;

    public int laneIndex;

    private bool passedPlayer = false;
    private void Start()
    {
        ScoreManager scoreManager = 
            FindFirstObjectByType<ScoreManager>();

        if (scoreManager != null)
        {
            int score = scoreManager.score;

            if (score < 500)
            {
                speed = Random.Range(3f, 5f);
            }
            else if (score < 1000)
            {
                speed = Random.Range(3.5f, 5.5f);
            }
            else if (score < 2000)
            {
                speed = Random.Range(4f, 6f);
            }
            else
            {
                speed = Random.Range(4.5f, 6.5f);
            }
        }
        else
        {
            speed = Random.Range(3f, 5f);
        }
    }
    void Update()
    {
        //ARABAYI AÞAÐI HAREKET ETTÝR
        transform.position += 
            Vector3.down * speed * Time.deltaTime;


        //OYUNCU GEÇTÝ MÝ
        if (!passedPlayer && transform.position.y < -3f)
        {
            passedPlayer = true;

            ScoreManager scoreManager = 
                FindFirstObjectByType<ScoreManager>();

            if (scoreManager != null)
            {
                scoreManager.CarPassed(); // Puaný artýr

            }

        }



        //EKRANIN ALTINA VARINCA YOK ET
        if (transform.position.y < -8f)
        {
            Destroy(gameObject);
        }
    }
}

