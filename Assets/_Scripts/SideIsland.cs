using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class SideIsland : MonoBehaviour {

    [Header("Speed")]
    public float horizontalSpeed = 0.05f;

    [Header("Boundary")]
    public Boundary boundary;
    public float resetPosition;
    public float resetPoint;

// Start is called before the first frame update
void Start()
{
    Reset();
}

// Update is called once per frame
void Update()
{
    Move();
    CheckBounds();
}

/// <summary>
/// This method moves the ocean down the screen by verticalSpeed
/// </summary>
void Move()
{
    Vector2 newPosition = new Vector2(horizontalSpeed, 0.0f);
    Vector2 currentPosition = transform.position;

    currentPosition -= newPosition;
    transform.position = currentPosition;
}

/// <summary>
/// This method resets the ocean to the resetPosition
/// </summary>
void Reset()
{

        float randomXPosition = Random.Range(boundary.Bottom, boundary.Top);
    transform.position = new Vector2(resetPosition, randomXPosition/*Random.Range(boundary.Right, boundary.Right + 2.0f)*/);
}

/// <summary>
/// This method checks if the ocean reaches the lower boundary
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

