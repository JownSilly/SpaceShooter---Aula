using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAreaAction : MonoBehaviour
{
    [Header("AreaAction")]
    [SerializeField]
    private float marginX = 0; // Margem do eixo X da área de ação em relação às bordas da tela
    [SerializeField]
    private float marginY = 0; // Margem do eixo Y da área de ação em relação às bordas da tela
    private Camera mainCamera;
    private float minX, maxX, minY, maxY;
    private void Awake()
    {
        mainCamera = Camera.main;
        CalculateBounds();
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
    public float GetMinX()
    {
        return minX;
    }
    public float GetMaxX()
    {
        return maxX;
    }
    public float GetMinY()
    {
        return minY;
    }
    public float GetMaxY()
    {
        return maxY;
    }
}
