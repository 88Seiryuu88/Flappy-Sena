using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;

    private float spawnTop = -4.81f;
    private float spawnBottom = -8.52f;
    private float spawnPosX = 13;
    private float startDelay = 1;
    private float spawnInterval = 2.0f;

    private float startSpeed = 5f;
    private float speedIncrease = 0.1f;
    private float maxSpeed = 10f;
    private float currentSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentSpeed = startSpeed; // En başta tekrar ilk hıza atar
        InvokeRepeating("SpawnRandomObstacle", startDelay, spawnInterval);
        
    }

    
    void SpawnRandomObstacle() 
    {
            Vector2 spawnPos = new Vector2(spawnPosX, Random.Range(spawnBottom, spawnTop)) ;
            GameObject newObstacle = Instantiate(obstaclePrefabs[0], spawnPos, obstaclePrefabs[0].transform.rotation);

            MoveForward moveScript = newObstacle.GetComponent<MoveForward>();

            if (moveScript != null) {

                moveScript.speed = currentSpeed;
            }
            currentSpeed = Mathf.Min(currentSpeed + speedIncrease, maxSpeed);

    }
}
