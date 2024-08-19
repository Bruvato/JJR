
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public enum GameState
    {
    START, CYCLE, PACTIONS, EACTIONS, END
    }

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance{get; private set;}
    private void Awake()
    {

        if (Instance != null)
        {
            Debug.LogError("more than one instance bruh");
        }
        Instance = this;
    }
    public GameState State;
    private GameState nextState;
    public event EventHandler<OnStateChangedEventArgs> OnStateChanged;
    public class OnStateChangedEventArgs : EventArgs{
        public GameState state;
    }
    public void UpdateGameState(GameState newState){
        State = newState;
        OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
        {
            state = newState
        });
        Debug.Log(" " + newState);
        switch (newState){
            case GameState.START:
                break;
            case GameState.PACTIONS:
                HandlePACTIONS();
                break;
            case GameState.EACTIONS:
                HandleEACTIONS();
                break;
            case GameState.CYCLE:
                HandleCYCLE();
                break;
            case GameState.END:
                break;
        }
        
    }

    private void HandlePACTIONS()
    {

        nextState = GameState.EACTIONS;
    }
    private void HandleEACTIONS()
    {

        nextState = GameState.CYCLE;
    }
    private void HandleCYCLE()
    {
        EnemyManager.Instance.Spawn();

        nextState = GameState.PACTIONS;
    }


    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)==true){
            UpdateGameState(nextState);
            Debug.Log("A");

        }

    }
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        UpdateGameState(GameState.PACTIONS);
    }
}
