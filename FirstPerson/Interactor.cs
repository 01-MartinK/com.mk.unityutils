using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    public float interactDistance = 2.0f;
    public LayerMask interactionLayer;

    private void Update()
    {
        if (InputManager.Actions.Interact.triggered)
        {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, interactDistance, interactionLayer))
            {
                if (hit.transform != null)
                {
                    Interact(hit.point, hit.transform);
                }
            }
        }
    }

    public void Interact(Vector3 hitPoint, Transform hitTransform)
    {
        if (hitTransform.GetComponent<IInteractable>() != null)
        {
            hitTransform.GetComponent<IInteractable>().Interact();
        }
    }
}