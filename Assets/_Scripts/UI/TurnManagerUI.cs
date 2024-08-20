using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TurnManagerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI turnCountText;
    [SerializeField] private TextMeshProUGUI turnStateText;

    private void Start()
    {
        TurnManager.Instance.OnTurnCountChanged += Instance_OnTurnCountChanged;
        TurnManager.Instance.OnStateChanged += Instance_OnStateChanged;
        TurnManager.Instance.OnCycleTimerChanged += Instance_OnCycleTimerChanged;
    }

    private void Instance_OnCycleTimerChanged(object sender, TurnManager.OnCycleTimerChangedEventArgs e)
    {
        UpdateTurnStateText((e.cycleTimer).ToString("F2"));
    }

    private void Instance_OnTurnCountChanged(object sender, TurnManager.OnTurnCountChangedEventArgs e)
    {
        turnCountText.text = "TURN COUNT : " + e.turnCount;
    }

    private void Instance_OnStateChanged(object sender, TurnManager.OnStateChangedEventArgs e)
    {
        string text = "";

        switch (e.state)
        {
            case GameState.PickCard:
                text = "PICK A CARD";
                break;
            case GameState.PlayerTurn:
                text = "CLICK TO AIM" + System.Environment.NewLine + "MOVE TO CONFIRM";
                break;
            case GameState.EnemyTurn:
                text = "ENEMY TURN";
                break;
            case GameState.Cycle:
                text = "";
                break;
            case GameState.End:
                text = "GAME OVER";
                break;
        }


        UpdateTurnStateText(text);
    }

    public void UpdateTurnStateText(string text)
    {
        turnStateText.text = text;
    }


}
