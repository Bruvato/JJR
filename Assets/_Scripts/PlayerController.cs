using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const int MOVE_DISTANCE = 1;

    [SerializeField] private Transform cameraTransform;

    public void Update()
    {
        Vector3 newPosition = transform.position;

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (Mathf.Abs(forward.x) > Mathf.Abs(forward.z))
            {
                newPosition.x += Mathf.Round(forward.x) * MOVE_DISTANCE;
            }
            else
            {
                newPosition.z += Mathf.Round(forward.z) * MOVE_DISTANCE;
            }
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (Mathf.Abs(forward.x) > Mathf.Abs(forward.z))
            {
                newPosition.x -= Mathf.Round(forward.x) * MOVE_DISTANCE;
            }
            else
            {
                newPosition.z -= Mathf.Round(forward.z) * MOVE_DISTANCE;
            }
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (Mathf.Abs(right.x) > Mathf.Abs(right.z))
            {
                newPosition.x -= Mathf.Round(right.x) * MOVE_DISTANCE;
            }
            else
            {
                newPosition.z -= Mathf.Round(right.z) * MOVE_DISTANCE;
            }
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (Mathf.Abs(right.x) > Mathf.Abs(right.z))
            {
                newPosition.x += Mathf.Round(right.x) * MOVE_DISTANCE;
            }
            else
            {
                newPosition.z += Mathf.Round(right.z) * MOVE_DISTANCE;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            newPosition.y += MOVE_DISTANCE;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.LeftControl))
        {
            newPosition.y -= MOVE_DISTANCE;
        }

        newPosition.x = Mathf.Round(newPosition.x);
        newPosition.y = Mathf.Round(newPosition.y);
        newPosition.z = Mathf.Round(newPosition.z);

        transform.position = newPosition;
    }
}