using UnityEngine;

public class TrafficManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject trafficCarPrefab;

    public float spawnInterval = 1.8f;

    private float spawnTimer = 0f;

    private float[] lanePositions = { -3f, -1f, 1f, 3f };

    private ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = FindFirstObjectByType<ScoreManager>();
    }


    void Update()
    {
        spawnTimer += Time.deltaTime;

        // Skora göre trafik sýklýðýný artýr
        UpdateDifficulty();

        if (spawnTimer >= spawnInterval)
        { 
            CreateCar();
            spawnTimer = 0f; 
        }
    }

    void UpdateDifficulty()
    {
        if (scoreManager != null)
            return;

        int score = scoreManager.score;

        if (score < 500)
        {
            spawnInterval = 1.5f;
        }
        else if (score < 1000)
        {
            spawnInterval = 1.2f;
        }
        else if (score < 2000)
        {
            spawnInterval = 0.8f;
        }
        else
        {
            spawnInterval = 0.5f;
        }
    }
    void CreateCar()
    {

        int[] lanes = { 0, 1, 2, 3 };

        for (int i = 0; i < lanes.Length; i++)
        {
            int randomIndex = Random.Range(i, lanes.Length);
            int temporary = lanes[i];
            lanes[i] = lanes[randomIndex];
            lanes[randomIndex] = temporary;
        }

        // UYGUN ÞERÝTÝ BULMAYA ÇALIÞIYORUZ
        for (int i = 0; i < lanes.Length; i++)
        {
            int selectedLane = lanes[i];

            if (IsLaneClear(selectedLane))
            {
                SpawnCar(selectedLane);
                return;
            }
        }
    }

    bool IsLaneClear(int laneIndex)
    {
        GameObject[] cars = GameObject.FindGameObjectsWithTag("Traffic");

        foreach (GameObject car in cars)
        {
            TrafficCar trafficCar = car.GetComponent<TrafficCar>();

            if(trafficCar != null)
            {

                // AYNI ÞERÝTTE YUKARIDA ARABA VARSA YENÝ ARABA ÇIKARMA
                if(trafficCar.laneIndex == laneIndex &&
                    car.transform.position.y > 1.5f)
                {
                    return false;
                }
            }
        }

        return true;
    }

    void SpawnCar(int laneIndex)
    {
        float spawnX = lanePositions[laneIndex];
        float spawnY = 7f;

        Vector3 spawnPosition = new Vector3(
            spawnX,
            spawnY,
            -0.2f
        );

        GameObject newCar = Instantiate(
            trafficCarPrefab,
            spawnPosition,
            Quaternion.identity
            );

        TrafficCar trafficCar = 
            newCar.GetComponent<TrafficCar>();

        if (trafficCar != null)
        {
            trafficCar.laneIndex = laneIndex;
        }
    }
}
