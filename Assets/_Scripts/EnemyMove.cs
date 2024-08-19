
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private Dictionary<Vector3, float> trajectoryMatch = new Dictionary<Vector3, float>();

    // invoke when any enemy moves
    public static event EventHandler OnAnyEnemyPositionChanged;


    private void Update()
    {
        if (TurnManager.Instance.GetState() != GameState.EnemyTurn)
        {
            return;
        }

        //for testing
        transform.position += Vector3.up;

        OnAnyEnemyPositionChanged.Invoke(this, EventArgs.Empty);
    }
    private Vector3 findTrajectory(){
        Vector3 toPlayer = Vector3.Normalize(Player.Instance.transform.position - transform.position);

        trajectoryMatch.Add(Vector3.down, Vector3.Dot(toPlayer, Vector3.down));
        trajectoryMatch.Add(Vector3.up, Vector3.Dot(toPlayer, Vector3.up));
        trajectoryMatch.Add(Vector3.left, Vector3.Dot(toPlayer, Vector3.left));
        trajectoryMatch.Add(Vector3.right, Vector3.Dot(toPlayer, Vector3.right));
        trajectoryMatch.Add(Vector3.back, Vector3.Dot(toPlayer, Vector3.back));
        trajectoryMatch.Add(Vector3.forward, Vector3.Dot(toPlayer, Vector3.forward));

        return trajectoryMatch.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
    }

    private void moveClose(){

    }

    private void moveAway(){

    }

    private void moveParallel(){

    }

}