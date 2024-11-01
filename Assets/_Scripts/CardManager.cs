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
    public void ClearCards()
    {
        _cards.Clear();
        OnCardsChanged?.Invoke(this, EventArgs.Empty);
    }
    public void ApplyCard(Card card)
    {

        Vector3 playerScale = Player.Instance.GetScale();

        FunctionApplier.Function func = FunctionApplier.Function.Add;
        switch (card.function)
        {
            case "+":
                func = FunctionApplier.Function.Add;
                break;
            case "�":
                func = FunctionApplier.Function.Multiply;
                break;
            case "<sup>":
                func = FunctionApplier.Function.Power;
                break;
        }

        Vector3 newScale = FunctionApplier.ApplyFunctionOnVecComponents(func, playerScale, card.adjustmentValue, card.axis == "x", card.axis == "y", card.axis == "z");
        Player.Instance.SetScale(newScale);
    }

    public event EventHandler OnCardsChanged;

    private int cardAmount = 3;


    private void Start()
    {
        TurnManager.Instance.OnTurnCountChanged += Instance_OnTurnCountChanged;
        TurnManager.Instance.OnStateChanged += Instance_OnStateChanged;

        SpawnNewCard();
    }

    private void Instance_OnStateChanged(object sender, TurnManager.OnStateChangedEventArgs e)
    {
        if (TurnManager.Instance.GetState() != GameState.PickCard)
        {
            return;
        }

        if (TurnManager.Instance.TurnCount % 5 == 0)
        {
            SpawnNewCard();
        }



    }

    private void Instance_OnTurnCountChanged(object sender, TurnManager.OnTurnCountChangedEventArgs e)
    {

    }

    private void SpawnNewCard()
    {
        for (int i = 1; i <= cardAmount; i++)
        {
            Card newCard = new Card(null, null, 0);

            switch (i)
            {
                case 1:
                    newCard.axis = "x";
                    break;
                case 2:
                    newCard.axis = "y";
                    break;
                case 3:
                    newCard.axis = "z";
                    break;
            }

            int randomFunc = UnityEngine.Random.Range(0, 100);

            if (randomFunc <= 80)
            {
                newCard.function = "+";
                newCard.adjustmentValue = UnityEngine.Random.Range(1, 11);
            }
            else if (randomFunc <= 95)
            {
                newCard.function = "�";
                newCard.adjustmentValue = UnityEngine.Random.Range(2, 4);
            }
            else
            {
                newCard.function = "<sup>";
                newCard.adjustmentValue = UnityEngine.Random.Range(2, 3);
            }

            //switch (randomFunc)
            //{
            //    case 1:
            //        //add
            //        newCard.function = "+";
            //        break;
            //    case 2:
            //        //multiply
            //        newCard.function = "�";
            //        break;
            //    case 3:
            //        //power
            //        newCard.function = "<sup>";
            //        break;
            //}

            int randomAdjustmentVal = UnityEngine.Random.Range(1, 11);



            //newCard.adjustmentValue = randomAdjustmentVal;

            _cards.Add(newCard);
            CameraSystem.LockCursor(false);

            OnCardsChanged?.Invoke(this, EventArgs.Empty);
        }

    }
}
