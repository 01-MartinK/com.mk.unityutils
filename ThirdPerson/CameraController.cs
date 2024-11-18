using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("References")]
    public Transform target;
    public Transform _camera;
    public Transform orientation;

    [Header("Sensitivity")]
    public float xSensitivity = 1.5f;
    public float ySensitivity = 1.5f;

    [Header("Camera Values")]
    public Vector3 cameraOffset = Vector3.zero;
    public float lerpSpeed = 0.1f;
    public float rotationLerp = 0.1f;
    public float leanAmount = 0f;
    Vector3 rotation;

    Vector3 velocity;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _camera.localPosition = cameraOffset;
    }

    private void Update()
    {
        if (target == null)
            return;

        transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, lerpSpeed);

        rotation.x += -Input.GetAxisRaw("Mouse Y") * ySensitivity;
        rotation.y += Input.GetAxisRaw("Mouse X") * xSensitivity;

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(rotation), rotationLerp);

        orientation.rotation = Quaternion.Euler(new Vector3(0, rotation.y, 0));
    }
}
