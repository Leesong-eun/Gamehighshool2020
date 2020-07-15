using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private float width;

    private void Awake()
    {
        var collider = GetComponent<BoxCollider2D>();
        width = collider.size.x;
    }

    void Update()
    {
        var collider = GetComponent<BoxCollider2D>();
        float width = collider.size.x;

        if(transform.position.x < -10.24)
        {
            transform.position 
                += Vector3.right * 2f * width;

        }
    }
}
