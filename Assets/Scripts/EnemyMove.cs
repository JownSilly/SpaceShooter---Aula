using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    private Vector2 direction;
    [SerializeField]
    private float moveSpeed = 1f;
    [SerializeField]
    private bool isZigZag;
    private bool isMovingRight = true;
    private Coroutine zigZagCoroutine;
    [SerializeField]
    [Range(0,1f)]
    private float zigzagTimer;

    // Start is called before the first frame update
    void Start()
    {
        if (isZigZag)
        {
            zigZagCoroutine = StartCoroutine(MoveZigZag());
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isZigZag)
        {
            MoveLinear(direction);
        }else
        {
            MoveLinear(direction);
        }
        
    }
    private void MoveLinear(Vector2 moveDirection)
    {
        transform.Translate(moveDirection * (moveSpeed * Time.deltaTime));
    }
    IEnumerator MoveZigZag()
    {
        while (true)
        {
            if (isMovingRight)
            {
                direction = new Vector2(1f, -1f);
            }
            else
            {
                direction = new Vector2(-1, -1f);
            }
            yield return new WaitForSeconds(zigzagTimer);
            isMovingRight = !isMovingRight;
        }
    }
    private void OnDestroy()
    {
        if(zigZagCoroutine != null)
        {
            StopCoroutine(zigZagCoroutine);
        }
    }
}
