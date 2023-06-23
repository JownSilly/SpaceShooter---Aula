using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private NavesModel navePlayer;
    [SerializeField]
    private float speedControl;
    [Header("AreaAction")]
    [SerializeField]
    private float marginX = 0; // Margem do eixo X da área de ação em relação às bordas da tela
    [SerializeField]
    private float marginY = 0; // Margem do eixo Y da área de ação em relação às bordas da tela
    private Camera mainCamera;
    private float minX, maxX, minY, maxY;

    // Start is called before the first frame update
    void Start()
    {
        speedControl = navePlayer.GetSpeedPoints();
        mainCamera = Camera.main;
        CalculateBounds();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        ActionArea();
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
    private void CalculateBounds()
    {
        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found!");
            return;
        }

        float cameraHeight = mainCamera.orthographicSize * 2f;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        float marginOffsetX = cameraWidth * marginX;
        float marginOffsetY = cameraHeight * marginY;

        minX = mainCamera.transform.position.x - cameraWidth / 2f + marginOffsetX;
        maxX = mainCamera.transform.position.x + cameraWidth / 2f - marginOffsetX;
        minY = mainCamera.transform.position.y - cameraHeight / 2f + marginOffsetY;
        maxY = mainCamera.transform.position.y + cameraHeight / 2f - marginOffsetY;
    }
}
