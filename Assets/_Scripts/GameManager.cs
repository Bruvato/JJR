using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
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

    private void Start()
    {
        Player.Instance.OnScaleChanged += Instance_OnScaleChanged; ;
    }

    private void Instance_OnScaleChanged(object sender, IScalable.OnScaleChangedEventArgs e)
    {
        Vector3 playerScale = e.scale;
        if (playerScale.x * playerScale.y * playerScale.z == 0)
        {
            //GAME OVER
            TurnManager.Instance.UpdateGameState(GameState.End);
        }
    }



}
