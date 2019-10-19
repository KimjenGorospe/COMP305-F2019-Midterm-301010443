using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class SidePlayerController : MonoBehaviour
{
    // Determines the player movement speed
    [Header("Movement Settings")]
    public float speed;
    public Boundary boundary;

    public GameController gameController;

    // private instance variables
    private AudioSource _thunderSound;
    private AudioSource _yaySound;
    public Rigidbody2D rBody;

    // Start is called before the first frame update
    void Start()
    {
        _thunderSound = gameController.audioSources[(int)SoundClip.THUNDER];
        _yaySound = gameController.audioSources[(int)SoundClip.YAY];
    }

    // Update is called once per frame
    void Update()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Reads input
        float vert = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(0, vert);

        //Moves the Player
        rBody.velocity = movement * speed;

        rBody.position = new Vector2(
           Mathf.Clamp(rBody.position.x, boundary.Left, boundary.Right), // Restricts on the X postition to xMin and xMax
           Mathf.Clamp(rBody.position.y, boundary.Bottom, boundary.Top)); // Restricts on the Y postition to yMin and yMax
    }
    /*public void Move()
{
    Vector2 newPosition = transform.position;

    if (Input.GetAxis("Vertical") > 0.0f)
    {
        newPosition += new Vector2(speed.max, 0.0f);
    }

    if (Input.GetAxis("Vertical") < 0.0f)
    {
        newPosition += new Vector2(speed.min, 0.0f);
    }

    transform.position = newPosition;
}

public void CheckBounds()
{
    // check Bottom boundary
    if (transform.position.x > boundary.Bottom)
    {
        transform.position = new Vector2(boundary.Bottom, transform.position.y);
    }

    // check Top boundary
    if (transform.position.x < boundary.Top)
    {
        transform.position = new Vector2(boundary.Top, transform.position.y);
    }
}
*/
    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Cloud":
                _thunderSound.Play();
                gameController.Lives -= 1;
                break;
            case "Island":
                _yaySound.Play();
                gameController.Score += 100;
                break;
        }
    }

}

