using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalObsSpawner : MonoBehaviour
{
    public float d1;
    public float d2;
    public float minSpawnTime;
    public float maxSpawnTime;
    [SerializeField] private float actualSpawnTime;
    public GameObject verticalObsPrefab;

    public List<Sprite> obstacleSprites;

    void Start()
    {
        ChangeGameDifficulty(50);
        Invoke("SpawnVerticalObstacle", actualSpawnTime);
    }

    public void ChangeGameDifficulty(float difficuty)
    {
        actualSpawnTime = difficuty / 100 * maxSpawnTime;
        Debug.Log("Spawn Time: " + actualSpawnTime);
        if(actualSpawnTime < minSpawnTime)
        {
            actualSpawnTime = minSpawnTime;
        }
    }

    private void SpawnVerticalObstacle()
    {
        Vector2 pos = Random.insideUnitCircle * Random.Range(d1, d2);
        Vector2 spawnPoint = (Vector2)transform.position + new Vector2(pos.x, pos.y);
        VerticalObsBehaviour obstacle = Instantiate(verticalObsPrefab, spawnPoint, Quaternion.identity).GetComponent<VerticalObsBehaviour>();
        obstacle.gameObject.GetComponent<SpriteRenderer>().sprite = obstacleSprites[Random.Range(0, obstacleSprites.Count)];
        
        Invoke("SpawnVerticalObstacle", actualSpawnTime);
    }
}
