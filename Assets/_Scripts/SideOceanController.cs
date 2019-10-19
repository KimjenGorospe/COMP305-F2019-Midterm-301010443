using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideOceanController : MonoBehaviour
{
    public float horizontalSpeed = 0.05f;
    public float resetPosition;
    public float resetPoint;

    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        Move();
        CheckBounds();
    }

    /// <summary>
    /// This method moves the sky left of screen by horizontalSpeed
    /// </summary>
    void Move()
    {
        Vector2 newPosition = new Vector2(horizontalSpeed, 0.0f);
        Vector2 currentPosition = transform.position;

        currentPosition -= newPosition;
        transform.position = currentPosition;
    }

    /// <summary>
    /// This method resets the sky to the resetPosition
    /// </summary>
    void Reset()
    {
        transform.position = new Vector2(resetPosition, 0.0f);
    }

    /// <summary>
    /// This method checks if the sky reaches the boundary
    /// and then it Resets it
    /// </summary>
    void CheckBounds()
    {
        if (transform.position.x <= resetPoint)
        {
            Reset();
        }
    }
}

