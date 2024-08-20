using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    private Card card;
    [SerializeField] private Button cardButton;
    [SerializeField] private TextMeshProUGUI cardText;


    private void Awake()
    {
        cardButton.onClick.AddListener(() =>
        {
            SoundManager.Instance.Play("Card");

            CardManager.Instance.ApplyCard(card);
            CardManager.Instance.ClearCards();
            CameraSystem.LockCursor(true);
        });
    }

    public void SetCardText(Card card)
    {
        this.card = card;

        string text = card.axis + card.function + card.adjustmentValue;
        cardText.text = text;

    }
}
