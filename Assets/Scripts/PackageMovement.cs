using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageMovement : MonoBehaviour
{
    private float horizontalSpeed;    // Horizontal speed
    private float wobbleMagnitude;    // Vertical wobble magnitude
    private float wobbleFrequency;    // Vertical wobble frequency

    private float originalYPosition;
    private float wobbleTimer = 0.0f;

    void Start()
    {
        originalYPosition = transform.position.y;

        // Randomize movement parameters
        horizontalSpeed = Random.Range(0.5f, 1.5f); // Adjust range as needed
        wobbleMagnitude = Random.Range(0.2f, 1.0f); // Adjust range as needed
        wobbleFrequency = Random.Range(1.0f, 5.0f); // Adjust range as needed
    }

    void Update()
    {
        // Randomized leftward movement
        transform.position += Vector3.left * horizontalSpeed * Time.deltaTime;

        // Randomized wobbly movement
        wobbleTimer += Time.deltaTime;
        float wobbleEffect = Mathf.Sin(wobbleTimer * wobbleFrequency) * wobbleMagnitude;
        transform.position = new Vector3(transform.position.x, originalYPosition + wobbleEffect, transform.position.z);
    }
}


