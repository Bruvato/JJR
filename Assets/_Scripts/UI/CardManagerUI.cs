using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManagerUI : MonoBehaviour
{
    [SerializeField] private Transform container;
    [SerializeField] private GameObject cardUI;

    
    private void Start()
    {
        CardManager.Instance.OnCardsChanged += Instance_OnCardsChanged;
    }

    private void Instance_OnCardsChanged(object sender, EventArgs e)
    {
        foreach (Transform child in container)
        {
            Destroy(child.gameObject);
        }

        foreach (Card card in CardManager.Instance.GetCards())
        {
            
            Instantiate(cardUI, container).GetComponent<CardUI>().SetCardText(card);
            
        }
    }
}
