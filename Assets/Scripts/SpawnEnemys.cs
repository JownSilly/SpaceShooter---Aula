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
    private CameraAreaAction mainCamera;
    private float rangeMinX, rangeMaxX;

    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    private void Start()
    {
        mainCamera = GetComponent<CameraAreaAction>();
        rangeMinX = mainCamera.GetMinX();
        rangeMaxX = mainCamera.GetMaxX();
        InvokeRepeating("Spawn", initialDelay, spawnDelay);
    }

    private void Spawn()
    {
        var randomX = Random.Range(rangeMinX, rangeMaxX);
        //var randomY = Random.Range(rangeY.min, rangeY.max);
        var position = new Vector2(transform.position.x + randomX, transform.position.y /*+ randomY*/);
        Instantiate(enemyPrefab, position, transform.rotation);
    }

}
