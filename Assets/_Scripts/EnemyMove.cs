
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float orbitRange, orbitWidth;
    [SerializeField] private int moveDistance;
    [SerializeField] private LineRenderer lineRenderer;
    private Vector3 prediction;
    private Dictionary<Vector3, float> trajectoryMatch = new Dictionary<Vector3, float>();
    
    // invoke when any enemy moves
    public static event EventHandler OnAnyEnemyPositionChanged;
 
    private void Awake()
    {
        prediction = transform.position; 

        lineRenderer.positionCount = moveDistance+1;
        lineRenderer.SetPosition(0, prediction);
    }
    private void Update()
    {
        
        if (TurnManager.Instance.GetState() != GameState.EnemyTurn)
        {
            return;
        }

        //for testing

        OnAnyEnemyPositionChanged.Invoke(this, EventArgs.Empty);
    }
    private Vector3 FindTrajectory(){
        Vector3 toPlayer = Vector3.Normalize(Player.Instance.transform.position - prediction);
        trajectoryMatch.Clear();
        trajectoryMatch.Add(Vector3.down, Vector3.Dot(toPlayer, Vector3.down));
        trajectoryMatch.Add(Vector3.up, Vector3.Dot(toPlayer, Vector3.up));
        trajectoryMatch.Add(Vector3.left, Vector3.Dot(toPlayer, Vector3.left));
        trajectoryMatch.Add(Vector3.right, Vector3.Dot(toPlayer, Vector3.right));
        trajectoryMatch.Add(Vector3.back, Vector3.Dot(toPlayer, Vector3.back));
        trajectoryMatch.Add(Vector3.forward, Vector3.Dot(toPlayer, Vector3.forward));

        return trajectoryMatch.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
    }

    public void PreMove()
    {        
        prediction = transform.position; 
        int steps = 0;
        lineRenderer.positionCount = moveDistance;
        lineRenderer.SetPosition(0, prediction);
        while(steps<moveDistance){
        lineRenderer.SetPosition(steps, prediction);

        float distance = Vector3.Magnitude(Player.Instance.transform.position - prediction);
        Vector3 playerScale = Player.Instance.GetScale();
        int playerRange = (int)(Mathf.Max(Mathf.Max(playerScale.x, playerScale.y), playerScale.z) / 2);
        
        if (distance>playerRange + orbitRange + orbitWidth){
            MoveClose();
        }else if(playerRange + orbitRange<distance && distance<playerRange + orbitRange + orbitWidth){
            MoveParallel();
        }else{
            MoveAway();
        }

        steps++;


        }

    }
    public void Move(){
        transform.position += prediction-transform.position;
        lineRenderer.positionCount = 0;
    }
    // {        
    //     int steps = 0;

    //     while(steps<moveDistance){
    //     float distance = Vector3.Magnitude(Player.Instance.transform.position - transform.position);
    //     Vector3 playerScale = Player.Instance.GetScale();
    //     int playerRange = (int)(Mathf.Max(Mathf.Max(playerScale.x, playerScale.y), playerScale.z) / 2);
        
    //     if (distance>playerRange + orbitRange + orbitWidth){
    //         MoveClose();
    //     }else if(playerRange + orbitRange<distance && distance<playerRange + orbitRange + orbitWidth){
    //         MoveParallel();
    //     }else{
    //         MoveAway();
    //     }
    //     steps++;
    //     }

    // }
    
    private void MoveClose(){
        prediction+=FindTrajectory();

    }

    private void MoveAway(){
        prediction+=Vector3.Scale(FindTrajectory(), new Vector3(-1,-1,-1));
    }

    private void MoveParallel(){
        prediction+=new Vector3(FindTrajectory().y, FindTrajectory().z, FindTrajectory().x);

    }

}
