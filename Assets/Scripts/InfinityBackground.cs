using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityBackground : MonoBehaviour
{
    [SerializeField]
    private float moveAmount = 9.36f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > moveAmount)
        {
            transform.Translate(Vector2.up * -moveAmount * 2);
        }
    }
}
