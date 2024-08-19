using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveItLikeYouMeanIt : MonoBehaviour
{
    private int heLikeToMoveitMoveIt = 1;
    private int movementCounter = 4;
    public Transform cameramanNeverDies; 

    public void Update()
    {
        Vector3 newPosition = transform.position;
        if (movementCounter != 0){
          
            Vector3 forward = cameramanNeverDies.forward;
            Vector3 right = cameramanNeverDies.right;

            forward.y = 0;
            right.y = 0;

            forward.Normalize();
            right.Normalize();

            if (Input.GetKeyDown(KeyCode.W)){
                if (Mathf.Abs(forward.x) > Mathf.Abs(forward.z)) {
                    newPosition.x += Mathf.Round(forward.x) * heLikeToMoveitMoveIt;
                }
                else {
                    newPosition.z += Mathf.Round(forward.z) * heLikeToMoveitMoveIt;
                }
            }

            if (Input.GetKeyDown(KeyCode.S)) {
                if (Mathf.Abs(forward.x) > Mathf.Abs(forward.z)){
                    newPosition.x -= Mathf.Round(forward.x) * heLikeToMoveitMoveIt;
                }
                else {
                    newPosition.z -= Mathf.Round(forward.z) * heLikeToMoveitMoveIt;
                }
            }

            if (Input.GetKeyDown(KeyCode.A)) {
                if (Mathf.Abs(right.x) > Mathf.Abs(right.z)) {
                    newPosition.x -= Mathf.Round(right.x) * heLikeToMoveitMoveIt;
                }
                else {
                    newPosition.z -= Mathf.Round(right.z) * heLikeToMoveitMoveIt;
                }
            }

            if (Input.GetKeyDown(KeyCode.D)) {
                if (Mathf.Abs(right.x) > Mathf.Abs(right.z)) {
                    newPosition.x += Mathf.Round(right.x) * heLikeToMoveitMoveIt;
                }
                else {
                    newPosition.z += Mathf.Round(right.z) * heLikeToMoveitMoveIt;
                }
            }

            if (Input.GetKeyDown(KeyCode.Space)) {
                newPosition.y += heLikeToMoveitMoveIt;
            }

            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.LeftControl)) {
                newPosition.y -= heLikeToMoveitMoveIt;
            }

            newPosition.x = Mathf.Round(newPosition.x);
            newPosition.y = Mathf.Round(newPosition.y);
            newPosition.z = Mathf.Round(newPosition.z);

            transform.position = newPosition;
        }
    }
}