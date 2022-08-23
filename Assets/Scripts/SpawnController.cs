using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject catchPrefab;

    private float spawnInterval = 2.0f;
    public Transform leftWall;
    public Transform rightWall;

    private Vector2 spawnRange;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnEnemy", 0, spawnInterval);
        InvokeRepeating("spawnCatch", 0, spawnInterval + Random.Range(6f, 20f));
        spawnRange[0] = leftWall.localPosition.x / 2;
        spawnRange[1] = rightWall.localPosition.x / 2;
    }

    private void LateUpdate()
    {
        spawnRange[0] = leftWall.localPosition.x / 2;
        spawnRange[1] = rightWall.localPosition.x / 2;
    }

    private void spawnEnemy()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(spawnRange[0], spawnRange[1]),
            enemyPrefab.transform.position.y,
            enemyPrefab.transform.position.z
            );
        
        Instantiate(enemyPrefab, spawnPosition, enemyPrefab.transform.rotation);
    }

    private void spawnCatch()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(spawnRange[0], spawnRange[1]),
            catchPrefab.transform.position.y,
            catchPrefab.transform.position.z);

        Instantiate(catchPrefab, spawnPosition, catchPrefab.transform.rotation);
    }
}
