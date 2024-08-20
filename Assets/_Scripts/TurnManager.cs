using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public enum GameState
{
    PickCard,
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


    private float _turnCount;
    public float TurnCount
    {
        get
        {
            return _turnCount;
        }
        set
        {
            _turnCount = value;

            OnTurnCountChanged?.Invoke(this, new OnTurnCountChangedEventArgs
            {
                turnCount = value
            });
        }
    }
    public event EventHandler<OnTurnCountChangedEventArgs> OnTurnCountChanged;
    public class OnTurnCountChangedEventArgs : EventArgs
    {
        public float turnCount;
    }

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

    [SerializeField] private float _cycleTimerMax = 3f;
    private float _cycleTimer;
    public float CycleTimer
    {
        get
        {
            return _cycleTimer;
        }
        set
        {
            _cycleTimer = value;

            OnCycleTimerChanged?.Invoke(this, new OnCycleTimerChangedEventArgs
            {
                cycleTimer = value
            });
        }
    }

    public event EventHandler<OnCycleTimerChangedEventArgs> OnCycleTimerChanged;
    public class OnCycleTimerChangedEventArgs : EventArgs
    {
        public float cycleTimer;
    }


    private void Start()
    {
        PlayerController.OnPlayerPositionChanged += TurnManager_OnPlayerPositionChanged;
        EnemyMove.OnAnyEnemyPositionChanged += EnemyMove_OnEnemyPositionChanged;
        CardManager.Instance.OnCardsChanged += Instance_OnCardsChanged;


        UpdateGameState(GameState.PickCard);

        SoundManager.Instance.Play("BGM");

    }

    private void Instance_OnCardsChanged(object sender, EventArgs e)
    {
        if (CardManager.Instance.GetCards().Count != 0)
        {
            return;
        }

        UpdateGameState(nextState);
    }
    private void TurnManager_OnPlayerPositionChanged(object sender, EventArgs e)
    {
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
        //if (Input.GetKeyUp(KeyCode.F))
        //{
        //    UpdateGameState(nextState);
        //}
        switch (_state)
        {
            case GameState.PickCard:
                
                break;
            case GameState.PlayerTurn:
                
                break;
            case GameState.EnemyTurn:
                
                break;
            case GameState.Cycle:
                CycleTimer -= Time.deltaTime;
                if (CycleTimer <= 0)
                {
                    UpdateGameState(nextState);
                }
                break;
            case GameState.End:

                break;
        }
        

        
    }
    public void UpdateGameState(GameState newState)
    {
        //Debug.Log(newState);
        _state = newState;

        OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
        {
            state = newState
        });

        switch (newState)
        {
            case GameState.PickCard:
                HandlePickCard();
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
    private void HandlePickCard()
    {
        nextState = GameState.PlayerTurn;

    }

    private void HandlePlayerActions()
    {
        nextState = GameState.EnemyTurn;
    }
    private void HandleEnemyActions()
    {
        nextState = GameState.Cycle;

        if (EnemyManager.Instance.GetEnemies().Count == 0)
        {
            UpdateGameState(nextState);
        }

        EnemyManager.Instance.EnemyShoot();
        EnemyManager.Instance.EnemyMove();


    }
    private void HandleCycle()
    {
        nextState = GameState.PlayerTurn;

        _cycleTimer = _cycleTimerMax;

        TurnCount++;

        if (TurnCount % 5 == 0)
        {
            nextState = GameState.PickCard;
        }

        EnemyManager.Instance.Spawn();
        EnemyManager.Instance.EnemyAim();
        EnemyManager.Instance.EnemyPreMove();

        SoundManager.Instance.Play("Turn");

    }

}
