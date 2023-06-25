using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("NavesAtributes")]
    [SerializeField]
    private NavesModel navePlayer;
    [SerializeField]
    private int lifeControl;
    [SerializeField]
    private int damageControl;
    [SerializeField]
    private float speedControl;
    private CameraAreaAction mainCamera;
    private float minX, maxX, minY, maxY;
    [Header("Shoot")]
    [SerializeField]
    private GameObject shotPrefab;
    [SerializeField]
    private Transform shootPivot;

    // Start is called before the first frame update
    void Start()
    {
        
        mainCamera = GetComponent<CameraAreaAction>();
        lifeControl = navePlayer.GetLifePoints();
        speedControl = navePlayer.GetSpeedPoints();
        damageControl = navePlayer.GetDamagePoints();
        minX = mainCamera.GetMinX();
        maxX = mainCamera.GetMaxX();
        minY = mainCamera.GetMinY();
        maxY = mainCamera.GetMaxY();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        ActionArea();
        Shoot();
            
    }

    private void ActionArea()
    {
        
        var clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        var clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector2(clampedX, clampedY);
    }
    private void Move()
    {
        var side = Input.GetAxis("Horizontal");
        var up = Input.GetAxis("Vertical");
        var direction = new Vector2(side, up);
        transform.Translate(direction * speedControl*Time.deltaTime);
    }
    private void Shoot()
    {
        //Ao apertar Espace a Nave Atira
        if (Input.GetButtonDown("Jump")) 
        {
            Instantiate(shotPrefab, shootPivot.position, shootPivot.rotation);
        }
    }
    private void TakeDamage(int naveDamage)
    {
        lifeControl -= naveDamage;
        if(lifeControl < 0)
        {
            GameManager.Instance.PlayerDied();
        }
        else
        {
            GameManager.Instance.LivesUpdate(lifeControl);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        TakeDamage(collision.gameObject.GetComponent<Enemy>().GetEnemyModel().GetDamagePoints());
    }
}
