using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public enum GameState
{
    Start,
    PlayerTurn,
    EnemyTurn,
    Cycle,
    End
}

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance { get; private set; }
    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    private float turnCount;

    private GameState _state;
    public GameState GetState()
    {
        return _state;
    }
    private GameState nextState;

    public event EventHandler<OnStateChangedEventArgs> OnStateChanged;
    public class OnStateChangedEventArgs : EventArgs
    {
        public GameState state;
    }

    private void Start()
    {
        PlayerController.OnPlayerPositionChanged += TurnManager_OnPlayerPositionChanged;
        EnemyMove.OnAnyEnemyPositionChanged += EnemyMove_OnEnemyPositionChanged;


        UpdateGameState(GameState.PlayerTurn);
    }


    private void TurnManager_OnPlayerPositionChanged(object sender, EventArgs e)
    {
        // when player moves change state from playerTurn to enemyTurn
        // lets just say pressing a movment key regardless of if player shot or not ends the turn
        if (_state != GameState.PlayerTurn)
        {
            return;
        }

        UpdateGameState(nextState);
    }
    private void EnemyMove_OnEnemyPositionChanged(object sender, EventArgs e)
    {
        // when enemy moves change state from enemyTurn to Cycle
        if (_state != GameState.EnemyTurn)
        {
            return;
        }

        UpdateGameState(nextState);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            UpdateGameState(nextState);
        }
    }
    public void UpdateGameState(GameState newState)
    {
        _state = newState;

        OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
        {
            state = newState
        });

        switch (newState)
        {
            case GameState.Start:
                break;
            case GameState.PlayerTurn:
                HandlePlayerActions();
                break;
            case GameState.EnemyTurn:
                HandleEnemyActions();
                break;
            case GameState.Cycle:
                HandleCycle();
                break;
            case GameState.End:
                break;
        }

    }

    private void HandlePlayerActions()
    {
        if (turnCount % 5 == 0)
        {
            //power up / reward
        }

        nextState = GameState.EnemyTurn;
    }
    private void HandleEnemyActions()
    {
        List<Enemy> enemyList = EnemyManager.Instance.getEnemies();
        foreach (Enemy e in enemyList)
        {
            e.GetComponent<EnemyMove>().Move();
        }
        
        nextState = GameState.Cycle;
    }
    private void HandleCycle()
    {
        turnCount++;

        EnemyManager.Instance.Spawn();

        nextState = GameState.PlayerTurn;
    }

}
