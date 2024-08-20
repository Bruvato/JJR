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
        CardManager.Instance
    }

    
}
