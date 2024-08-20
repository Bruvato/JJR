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
    }

    private void Instance_OnTurnCountChanged(object sender, TurnManager.OnTurnCountChangedEventArgs e)
    {
        turnCountText.text = "TURN COUNT : " + e.turnCount;
    }

    private void Instance_OnStateChanged(object sender, TurnManager.OnStateChangedEventArgs e)
    {
        UpdateGameStateText(e.state.ToString());
    }

    private void UpdateGameStateText(string state)
    {
        turnStateText.text = state;
    }
}
