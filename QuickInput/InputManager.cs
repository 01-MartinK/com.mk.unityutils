using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerControls inputActions;

    public static PlayerControls.MovementActions Movement;
    public static PlayerControls.ActionsActions Actions;

    private void Awake()
    {
        inputActions = new PlayerControls();
        inputActions.Enable();
        Movement = inputActions.Movement;
        Actions = inputActions.Actions;
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
}
