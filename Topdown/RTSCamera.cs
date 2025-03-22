using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RTSCamera : MonoBehaviour
{
    [Header("Input")]
    public InputAction Movement;
    public InputAction Rotation;

    [Header("Movement")]
    public float speed;
    public float rotationSpeed;
    public float lerpSpeed;

    private Vector2 input;
    private Vector3 updatedPosition;
    private float updatedRotation;

    private void OnEnable()
    {
        Movement.Enable();
        Rotation.Enable();
    }

    private void OnDisable()
    {
        Movement.Disable();
        Rotation.Disable();
    }

    private void Awake()
    {
        updatedPosition = transform.position;
    }

    private void Update()
    {
        GetInput();
        transform.position = Vector3.Lerp(transform.position, updatedPosition, lerpSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, updatedRotation, 0), lerpSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        updatedPosition += (transform.forward * input.y + transform.right * input.x) * speed;
    }

    private void GetInput()
    {
        input = Movement.ReadValue<Vector2>();
        updatedRotation -= Rotation.ReadValue<float>() * rotationSpeed;
    }
}
