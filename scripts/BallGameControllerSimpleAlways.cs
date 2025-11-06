using UnityEngine;
using UnityEngine.InputSystem;

public class BallGameControllerSimpleAlways : MonoBehaviour
{
    public float jumpForce = 10.0f;
    public float moveForce = 3.0f;

    private Vector3 movement;
    private Rigidbody rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void OnJump()
    {
        // GetComponent<AudioSource>().Play();
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void OnMove(InputValue value)
    {
        Vector2 movementVector = value.Get<Vector2>();
        movement = new Vector3(movementVector.x, 0, movementVector.y);
    }

    private void FixedUpdate()
    {
        rb.AddForce(movement * moveForce);
    }
}
