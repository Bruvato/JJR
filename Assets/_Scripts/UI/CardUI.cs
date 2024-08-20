using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    [SerializeField] private Button cardButton;
    [SerializeField] private TextMeshProUGUI cardText;


    private void Awake()
    {
        cardButton.onClick.AddListener(() =>
        {
            CardManager.Instance.GetCards().Clear();
        });
    }

    public void SetCardText(string text)
    {
        cardText.text = text;
    }
}
