using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class PlayerController : MonoBehaviour
{
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
        if (PlayerPrefs.GetInt("Score") >= 500)
        {
            SideMove();
        }
        else
        {
            Move();
        }
       CheckBounds();
    }

    public void Move()
    {
        float horiz = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(horiz, 0);
        rBody.velocity = movement * speed;
        Debug.Log("Aye");
    }

    public void SideMove()
    {
        // Reads input
        float vert = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(0, vert);
        rBody.velocity = movement * speed;
    }

    public void CheckBounds()
    {
        rBody.position = new Vector2(
                  Mathf.Clamp(rBody.position.x, boundary.Left, boundary.Right), // Restricts on the X postition to xMin and xMax
                  Mathf.Clamp(rBody.position.y, boundary.Bottom, boundary.Top)); // Restricts on the Y postition to yMin and yMax
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch(other.gameObject.tag)
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
