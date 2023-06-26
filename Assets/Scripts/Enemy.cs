using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("EnemyAtributtes")]
    [SerializeField]
    private InimigosModel enemyModel;
    [SerializeField]
    private int lifeControl;
    [SerializeField]
    private int speedControl;
    [SerializeField]
    private int damageControl;
    private int scoreValue=100;
    [Header("Prefabs")]
    [SerializeField]
    private GameObject explosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        lifeControl = enemyModel.GetLifePoints();
        speedControl = enemyModel.GetSpeedPoints();
        damageControl = enemyModel.GetDamagePoints();
        scoreValue = enemyModel.GetScoreValue();
    }
    public InimigosModel GetEnemyModel()
    {
        return enemyModel;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    //Mata Inimigo
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BulletPlayer"))
        {
            lifeControl--;
            if (lifeControl <= 0)
            {
                Instantiate(explosionPrefab, transform.position, transform.rotation);
                Destroy(gameObject);
                IncreaseScore(scoreValue);
            }
            Destroy(other.gameObject);
        }
    }
    public void IncreaseScore(int score)
    {
        GameManager.Instance.ScoreUpdate(score);
    }
}
