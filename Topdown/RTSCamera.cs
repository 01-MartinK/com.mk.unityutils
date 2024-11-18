using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSCamera : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    public float rotationSpeed;
    public float lerpSpeed;

    private Vector2 input;
    private Vector3 updatedPosition;

    private void Update()
    {
        GetInput();
        transform.position = Vector3.Lerp(transform.position, updatedPosition, lerpSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        updatedPosition += new Vector3(input.x, 0, input.y) * speed;
    }

    private void GetInput()
    {
        input.x = InputManager.Movement.Horizontal.ReadValue<float>();
        input.y = InputManager.Movement.Vertical.ReadValue<float>();
    }
}
