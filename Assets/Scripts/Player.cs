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
    private BoxCollider2D areaAction;

    // Start is called before the first frame update
    void Start()
    {
        speedControl = navePlayer.GetSpeedPoints();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        ActionArea();
    }

    private void ActionArea()
    {
        var minX = -areaAction.bounds.extents.x + areaAction.offset.x;
        var maxX = areaAction.bounds.extents.x + areaAction.offset.x;

        var minY = -areaAction.bounds.extents.y + areaAction.offset.y;
        var maxY = areaAction.bounds.extents.y + areaAction.offset.y;
        transform.position = new Vector2(Math.Clamp(transform.position.x,minX,maxX), Math.Clamp(transform.position.y, minY, maxY));
    }

    private void Move()
    {
        var side = Input.GetAxis("Horizontal");
        var up = Input.GetAxis("Vertical");
        var direction = new Vector2(side, up);
        transform.Translate(direction * speedControl*Time.deltaTime);
    }
}
