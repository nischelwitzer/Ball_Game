using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCameraController : MonoBehaviour
{
    // Reference to the player GameObject.
    public GameObject player;
    public Transform camPos;

    // The distance between the camera and the player.
    private Vector3 offset;

    // Start is called before the first frame update.
    void Start()
    {
        // Calculate the initial offset between the camera's position and the player's position.
        offset = camPos.position - player.transform.position;
    }

    // LateUpdate is called once per frame after all Update functions have been completed.
    void LateUpdate()
    {
        // Maintain the same offset between the camera and player throughout the game.
        camPos.position = player.transform.position + offset;
    }
}
