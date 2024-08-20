using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cardText;


    private void SetCardText(string text)
    {
        cardText.text = text;
    }
}
