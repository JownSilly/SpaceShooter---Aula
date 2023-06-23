using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemys : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float initialDelay = 1f;
    [SerializeField]
    private float spawnDelay = 1f;
    [SerializeField]
    private Range rangeX;
    [SerializeField]
    private Range rangeY;

    // Start is called before the first frame update
    private void Awake()
    {
        InvokeRepeating("Spawn", initialDelay, spawnDelay);
    }
    private void Spawn()
    {
        var randomX = Random.Range(rangeX.min, rangeX.max);
        var randomY = Random.Range(rangeY.min, rangeY.max);
        var position = new Vector2(transform.position.x + randomX, transform.position.y + randomY);
        Instantiate(enemyPrefab, position, transform.rotation);
    }

}
