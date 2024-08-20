using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager Instance { get; private set; }
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

    private List<Card> _cards = new List<Card>();
    public List<Card> GetCards()
    {
        return _cards;
    }

    public event EventHandler OnCardsChanged;


    private void Start()
    {
        TurnManager.Instance.OnTurnCountChanged += Instance_OnTurnCountChanged;
    }

    private void Instance_OnTurnCountChanged(object sender, TurnManager.OnTurnCountChangedEventArgs e)
    {
        if (e.turnCount % 5 == 0)
        {
            SpawnNewCard();
        }
    }

    private void SpawnNewCard()
    {
        Card newCard = new Card("+", "x", 5);
        _cards.Add(newCard);

        OnCardsChanged?.Invoke(this, EventArgs.Empty);
    }
}
