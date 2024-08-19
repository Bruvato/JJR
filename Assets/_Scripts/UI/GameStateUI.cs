using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStateUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameStateText;

    private void Awake()
    {

    }

    private void Start()
    {
        TurnManager.Instance.OnStateChanged += Instance_OnStateChanged;
    }

    private void Instance_OnStateChanged(object sender, TurnManager.OnStateChangedEventArgs e)
    {
        UpdateGameStateText(e.state.ToString());
    }

    private void UpdateGameStateText(string state)
    {
        gameStateText.text = state;
    }

}
