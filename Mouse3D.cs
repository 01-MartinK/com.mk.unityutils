using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

public class Mouse3D : MonoBehaviour
{
    public static Mouse3D instance;

    public static RaycastHit GetMouseHit() => instance.Instance_GetMousePos();
    public void Awake()
    {
        instance = this;
    }

    public LayerMask mouseLayer;
    public RaycastHit Instance_GetMousePos()
    {
        Vector2 mousePos = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePos);

        if (Physics.Raycast(ray, out RaycastHit hit, 1000))
        {
            return hit;
        }

        return default(RaycastHit);
    }
}
