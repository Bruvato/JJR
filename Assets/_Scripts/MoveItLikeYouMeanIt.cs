using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveItLikeYouMeanIt : MonoBehaviour
{
    private int heLikeToMoveitMoveIt = 1;
    private int movementCounter = 4;
    public void Update(){
            


        Vector3 newPosition = transform.position;
        if(movementCounter!=0){
            if (Input.GetKeyDown(KeyCode.W)){
                newPosition += Vector3.forward * heLikeToMoveitMoveIt;
            }
            if (Input.GetKeyDown(KeyCode.S)){
                newPosition += Vector3.back * heLikeToMoveitMoveIt;
            }
            if (Input.GetKeyDown(KeyCode.A)){
                newPosition += Vector3.left * heLikeToMoveitMoveIt;
            }
            if (Input.GetKeyDown(KeyCode.D)){
                newPosition += Vector3.right * heLikeToMoveitMoveIt;
            }
            if (Input.GetKeyDown(KeyCode.Space)){
                newPosition += Vector3.up * heLikeToMoveitMoveIt;
            }
            if (Input.GetKeyDown(KeyCode.LeftShift)||Input.GetKeyDown(KeyCode.LeftControl)){
                newPosition += Vector3.down * heLikeToMoveitMoveIt;
            }

            transform.position = newPosition;
        }
    }


}
