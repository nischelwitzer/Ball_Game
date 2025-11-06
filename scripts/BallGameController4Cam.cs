// using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallGameController4Cam : MonoBehaviour
{
    public float jumpForce = 10.0f;
    public float moveForce = 10.0f;

    private float movementX;
    private float movementY;
    private float jumping;

    private Rigidbody rb;
    private GameObject myPlatform; // Referenz auf die Plattform

    private bool isGrounded = false; // Überprüft, ob der Ball den Boden berührt

    private void Start()
    {
        Debug.Log("BallGameController Start");
        rb = GetComponent<Rigidbody>();
        myPlatform = GameObject.Find("Platform");
    }

    public void OnBallJump() // Action BallJump
    {
        if (isGrounded)
        {
            // Vector3 jump = new Vector3(0, jumpForce, 0);
            GetComponents<AudioSource>()[0].Play();
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        Debug.Log("Jumping with force: " + jumpForce);
    }

    public void OnBallMove(InputValue moveInput)
    {
        Vector2 movementVector = moveInput.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
        // Debug.Log("Moving Changevector: " + movementVector);
    }

    private void FixedUpdate()
    {
        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0f;
        cameraForward.Normalize();

        Vector3 movementDirection = cameraForward * movementY + Camera.main.transform.right * movementX;

        Vector3 movement = new Vector3(movementDirection.x, 0, movementDirection.z);
        rb.AddForce(movement * moveForce);

        // jumping = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Prüfen, ob der Ball den Boden berührt (mit dem Tag)
        if (collision.gameObject.CompareTag("isGroundedTag"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Boden verlassen
        if (collision.gameObject.CompareTag("isGroundedTag"))
        {
            isGrounded = false;
        }
    }





    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("BallGameController OnTriggerEnter: " + other.gameObject.tag);
        if (other.gameObject.CompareTag("PickMe"))
        {
            // increase the collecting counter
            // GetComponent<AudioSource>().Play();
            GetComponents<AudioSource>()[1].Play();
            DMT.StaticStore.myPoints++;
            Debug.Log("MyPoints: " + DMT.StaticStore.myPoints);
            other.gameObject.SetActive(false);
        }
    }
}
