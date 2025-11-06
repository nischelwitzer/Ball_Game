using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// https://learn.unity.com/project/roll-a-ball
// https://learn.unity.com/tutorial/moving-the-player-1

public class BallPlayerController : MonoBehaviour
{
    public float speed = 10;

    public Rigidbody rb; // GetComponent<Rigidbody>();
    
    private float movementX;
    private float movementY;
    private float jumper;

    private void OnMoving(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        // Debug.Log("Moving... " + movementVector);
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void OnJumping()
    {
        jumper = speed * 5;
        GetComponent<AudioSource>().Play();
        Debug.Log("JUMP Action done");
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, jumper, movementY);
        rb.AddForce(movement * speed);
        jumper = 0;
    }

}
