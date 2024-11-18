using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    [Header("Sensitivity")]
    public float sensitivityX = 1.0f;
    public float sensitivityY = 1.0f;

    [Header("References")]
    public Transform orientation;
    private Vector3 rotation;

    private void Update()
    {
        rotation.x += Input.GetAxis("Mouse X") * sensitivityX;
        rotation.y -= Input.GetAxis("Mouse Y") * sensitivityY;

        transform.rotation = Quaternion.Euler(rotation.y, 0, 0);

        orientation.rotation = Quaternion.Euler(0, rotation.x, 0);
    }
}
