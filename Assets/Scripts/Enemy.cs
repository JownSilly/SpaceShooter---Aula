using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private InimigosModel enemyModel;
    private int lifeControl;
    private int speedControl;
    private int damageControl;
    // Start is called before the first frame update
    void Start()
    {
        lifeControl = enemyModel.GetLifePoints();
        speedControl = enemyModel.GetSpeedPoints();
        damageControl = enemyModel.GetDamagePoints();
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
    private void OnTriggerEnter2D(Collider2D bullet)
    {
        if (bullet.CompareTag("BulletPlayer"))
        {
            Destroy(gameObject);
            Destroy(bullet.gameObject);
        }
    }
}
