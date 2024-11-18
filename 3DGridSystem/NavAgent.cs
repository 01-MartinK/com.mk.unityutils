using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavAgent : MonoBehaviour
{
    private enum STATES
    {
        IDLE = 0,
        MOVING = 1,
    }

    private STATES state = 0;

    [SerializeField] private List<Vector3> path;

    [Header("Navigation")]
    public float NextPointDistance = 1f;
    public float LastPointDistance = 1f;

    private CharacterController characterController;
    public float Speed = 1f;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void MoveToPosition(Vector3 position)
    {
        path = AStarPathfinding.Instance.FindPath(transform.position, position);

        if (path == null || path.Count == 0)
        {
            print("No path found");
            return;
        }

        state = STATES.MOVING;
    }

    private void Update()
    {
        if (state == STATES.MOVING && path.Count != 0)
        {
            Vector3 direction = GetDirection(transform.position, path[0]);
            Vector3 correctedPoint = new Vector3(path[0].x, transform.position.y, path[0].y);
            characterController.Move(direction * Speed * Time.deltaTime);

            if (path.Count == 1 && Vector3.Distance(transform.position, correctedPoint) < LastPointDistance)
            {
                path.RemoveAt(0);
                if (path.Count == 0)
                {
                    FinishNavigation();
                }
            }

            if (Vector3.Distance(transform.position, correctedPoint) < NextPointDistance)
            {
                path.RemoveAt(0);
            }
        }
    }

    private void FinishNavigation()
    {
        state = STATES.IDLE;
    }

    public Vector3 GetDirection(Vector3 from, Vector3 to)
    {
        return (new Vector3(to.x, 0, to.y) - new Vector3(from.x, 0, from.z)).normalized;
    }
}
